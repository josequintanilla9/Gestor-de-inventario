using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProductosDatos
    {

        //METODO PARA CONSULTAR LOS PRODUCTOS
        public DataTable consultar()
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, p.Descripcion, p.PrecioCompra, p.PrecioVenta, c.NombreCategoria, c.IdCategoria, p.CantidadDisponible, p.Activo FROM Productos p INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria WHERE p.Activo = 1 ORDER BY NombreProducto ASC;";


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
                throw new Exception("No se pudo consultar a la base de datos, erro: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }





        // METODO PARA BUSCAR UN PRODUCTO
        public DataTable buscar(string dato)
        {

            //Consulta sql
            string sql = "SELECT p.IdProducto, p.NombreProducto, p.Descripcion, p.PrecioCompra, p.PrecioVenta, c.NombreCategoria, " +
                    " c.IdCategoria, p.CantidadDisponible FROM Productos p INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria WHERE NombreProducto LIKE '%" + dato + "%' AND p.Activo = 1 " +
                    "ORDER BY NombreProducto ASC";

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





        // METODO PARA CONSULTAR Y CARGAR LAS CATEGORIAS EN UN COMBOBOX
        public DataTable consultarCategorias()
        {

            string sql = "SELECT IdCategoria, NombreCategoria FROM Categorias WHERE Activo = 1 ORDER BY NombreCategoria ASC;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                MySqlDataAdapter data = new MySqlDataAdapter(comando);

                dt = new DataTable();

                data.Fill(dt);

            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, erro: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }





        // METODO PARA AGREGAR PRODUCTOS
        public bool guardar(string nombre, string descripcion, decimal precioCompra, decimal precioVenta, int idCategoria, int cantidad, out string mensaje)
        {
            bool agregado = false;

            mensaje = "";

            Conexion conexion = new Conexion();


            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                bool existeProducto = ExisteProducto(nombre);
                bool existeProductoDesactivado = ExisteProductoDesactivado(nombre);


                if (existeProducto == true)
                {
                    mensaje = "Ya existe un producto con ese nombre.";
                }
                else if (existeProductoDesactivado == true)
                {
                    string sql = "UPDATE Productos SET NombreProducto=@nombre, Descripcion=@descripcion, PrecioCompra=@precioCompra, " +
                        "PrecioVenta=@precioVenta, IdCategoria=@idCategoria, CantidadDisponible=@cantidad, Activo = 1 WHERE NombreProducto = @nombre";

                    // Crea un comando con la consulta SQL y la conexión
                    MySqlCommand comando = new MySqlCommand(sql, conex);

                    // Se utilizan parametros para evitar la inyeccion SQL
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@precioCompra", precioCompra);
                    comando.Parameters.AddWithValue("@precioVenta", precioVenta);
                    comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

                    comando.ExecuteNonQuery();


                    agregado = true;
                }
                else
                {
                    string sql = "INSERT INTO Productos(NombreProducto, Descripcion, PrecioCompra, PrecioVenta, IdCategoria, CantidadDisponible) " +
                    "VALUES(@nombre, @descripcion, @precioCompra, @precioVenta, @idCategoria, @cantidad);";

                    // Crea un comando con la consulta SQL y la conexión
                    MySqlCommand comando = new MySqlCommand(sql, conex);

                    // Se utilizan parametros para evitar la inyeccion SQL
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@precioCompra", precioCompra);
                    comando.Parameters.AddWithValue("@precioVenta", precioVenta);
                    comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

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





        // METODO PARA VALIDAR QUE AL CREAR UN NUEVO PRODUCTO NO EXISTA
        public bool ExisteProducto(string nombreProducto)
        {
            bool existe = false;


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();


            try
            {
                string sql = "SELECT COUNT(*) FROM Productos WHERE NombreProducto = @NombreProducto AND Activo = 1";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@NombreProducto", nombreProducto);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                if (count > 0)
                {
                    existe = true; // El producto ya existe
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar si el producto ya existe, error: " + ex.Message);
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






        // METODO PARA VERIFICAR SI AL CREAR UN NUEVO PRODUCTO, NO EXISTA ALGUNO DESACTIVADO CON ESE NOMBRE 
        public bool ExisteProductoDesactivado(string nombreProducto)
        {
            bool existe = false;

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();


            try
            {
                string sql = "SELECT COUNT(*) FROM Productos WHERE NombreProducto = @NombreProducto AND Activo = 0";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@NombreProducto", nombreProducto);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                if (count > 0)
                {
                    existe = true; // El producto ya existe
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar si el producto ya existe, error: " + ex.Message);
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





        // METODO PARA EDITAR LOS PRODUCTOS
        public bool editar(int id, string nombre, string descripcion, decimal precioCompra, decimal precioVenta, int idCategoria, int cantidad)
        {
            bool editado = false;

            // Crea una nueva conexión a la base de datos
            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "UPDATE Productos SET NombreProducto=@nombre, Descripcion=@descripcion, PrecioCompra=@precioCompra, PrecioVenta=@precioVenta, IdCategoria=@idCategoria, CantidadDisponible=@cantidad" +
                    " WHERE IdProducto = @ID";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@ID", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@precioCompra", precioCompra);
                comando.Parameters.AddWithValue("@precioVenta", precioVenta);
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                comando.Parameters.AddWithValue("@cantidad", cantidad);

                comando.ExecuteNonQuery();

                editado = true;


            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Actualizar el producto a la base de datos: " + ex.Message);
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




        // METODO PARA DESACTIVAR UN PRODUCTO
        public void desactivar(int id)
        {

            // Crea una nueva conexión a la base de datos
            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "UPDATE Productos SET Activo = 0 WHERE IdProducto = @ID";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@ID", id);

                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Desactivar el producto a la base de datos: " + ex.Message);
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





        // METODO PARA CONSULTAR EXISTENCIAS
        public int Existencias(int idProducto)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            int existencias = 0;

            string sql = "SELECT CantidadDisponible FROM Productos WHERE IdProducto = @idProducto";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@idProducto", idProducto);

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                // Lee los datos del lector y los agrega a la lista
                while (reader.Read())
                {
                    existencias = reader.GetInt32(reader.GetOrdinal("CantidadDisponible"));
                }
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar las existencias a la base de datos, erro: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return existencias;
        }




        // METODO PARA EDITAR EXISTENCIAS
        public void editarExistencias(int idProducto, int cantidad)
        {

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "UPDATE Productos SET CantidadDisponible = @cantidad WHERE IdProducto = @idProducto";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@idProducto", idProducto);
                comando.Parameters.AddWithValue("@cantidad", cantidad);

                comando.ExecuteNonQuery();


            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo Actualizar las existencias a la base de datos: " + ex.Message);
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
