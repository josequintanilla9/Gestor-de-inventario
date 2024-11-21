using CapaEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CategoriasDatos
    {
        // METODO PARA CONSULTAR LAS CATEGORIAS
        public DataTable consultar()
        {

            string sql = "SELECT IdCategoria, NombreCategoria FROM Categorias WHERE Activo = 1 ORDER BY NombreCategoria ASC;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conex);

                dt = new DataTable();

                adapter.Fill(dt);

            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }




        // METODO PARA BUSCAR UNA CATEGORIAS
        public DataTable buscar(string dato)
        {

            string sql = "SELECT IdCategoria, NombreCategoria FROM Categorias WHERE NombreCategoria LIKE '%" + dato + "%' AND Activo = 1 ";

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conex);

                dt = new DataTable();

                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, erro: " + ex.Message);

            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }








        // METODO PARA GUARDAR UNA CATEGORIAS
        public bool guardar(string nombre)
        {

            bool agregado = false;

            // Crea una nueva conexión a la base de datos
            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {

                bool existeCategoria = ExisteCategoria(nombre);

                if (existeCategoria == true)
                {
                    // Ya existe una categoria con ese nombre
                    return false;
                }
                else
                {
                    string sql = "INSERT INTO Categorias(NombreCategoria) VALUES(@nombre);";

                    // Crea un comando con la consulta SQL y la conexión
                    MySqlCommand comando = new MySqlCommand(sql, conex);

                    comando.Parameters.AddWithValue("@nombre", nombre);

                    comando.ExecuteNonQuery();


                    agregado = true;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo agregar el producto a la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return agregado;
        }







        // METODO PARA VALIDAR QUE AL CREAR UNA NUEVA CATEGORIA NO EXISTA
        public bool ExisteCategoria(string nombreCategoria)
        {
            bool existe = false;

            // Conexión a la base de datos
            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();


            try
            {
                // Consulta sql
                string sql = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria = @NombreCategoria AND Activo = 1";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@NombreCategoria", nombreCategoria);

                // Cuenta los resultados de la consulta
                int count = Convert.ToInt32(comando.ExecuteScalar());

                if (count > 0)
                {
                    existe = true; // La categoria ya existe
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar si la categoria ya existe, error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return existe;
        }






        // METODO PARA EDITAR UNA CATEGORIA
        public bool editar(int id, string nombre)
        {
            // verifica si se agrego correctamente la categoria
            bool editado = false;

            // Conexión a la base de datos
            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();

            try
            {
                // Consulta sql
                string sql = "UPDATE Categorias SET NombreCategoria = @nombre WHERE IdCategoria = @id;";

                // Comando
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Parametros
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);

                // Ejecución del comando
                comando.ExecuteNonQuery();

                editado = true;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Actualizar la categoria a la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return editado;

        }






        // METODO PARA DESACTIVAR UNA CATEGORIA
        public void desactivarCategoria(int idCategoria)
        {
            // Conexión a la base de datos
            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();


            try
            {
                // Consulta sql
                string sql = "UPDATE Categorias SET Activo = 0 WHERE IdCategoria = @idCategoria";

                // Comando
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Parametros
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);

                // Ejecución del comando
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Desactivar la categoria, error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, erro: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
        }



        // METODO PARA DESACTIVAR TODOS LOS PRODUCTOS CON RELACION A UNA CATEGORIA DESACTIVADA
        public void desactivarCategoriaProductos(int idCategoria)
        {
            // Conexion a la base de datos
            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();


            try
            {
                // Consulta sql
                string sql = "UPDATE Productos SET Activo = 0 WHERE IdCategoria = @idCategoria";

                // Comando
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Parametros
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);

                // Ejecución del comando
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Desactivar la categoria, error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
        }
    }
}
