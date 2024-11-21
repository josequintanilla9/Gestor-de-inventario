using CapaEntidades;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ComprasDatos
    {


        // METODO PARA REGISTRAR UNA NUEVA COMPRA
        public bool guardar(int idProducto, decimal precio, int cantidad, decimal total, DateTime fecha)
        {
            bool registrado = false;


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "INSERT INTO Compras(IdProducto, PrecioCompra, CantidadComprada, Total, FechaCompra) " +
                    "VALUES(@idProducto, @precio, @cantidad, @total, @fecha);";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@idProducto", idProducto);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@total", total);
                comando.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));

                comando.ExecuteNonQuery();

                registrado = true;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo regristar la venta a la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return registrado;
        }




        // METODO PARA CANCELAR UNA COMPRA
        public bool cancelar(int idCompra)
        {
            bool cancelado = false;

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "UPDATE Compras SET Activo = 0 WHERE IdCompra = @idCompra";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@idCompra", idCompra);

                comando.ExecuteNonQuery();

                cancelado = true;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo cancelar la venta, error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return cancelado;
        }






        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL DIA.
        public DataTable buscarComprasDia(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c " +
               "INNER JOIN Productos p ON c.IdProducto = p.IdProducto WHERE p.NombreProducto LIKE '%" + NombreProducto + "%' AND DATE(c.FechaCompra) = @FechaSeleccionada " +
               "AND c.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@FechaSeleccionada", Fecha.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO LA SEMANA.
        public DataTable buscarComprasSemana(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto LIKE '%" + NombreProducto + "%' AND WEEKOFYEAR(c.FechaCompra) = WEEKOFYEAR(@Fecha) AND c.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL MES Y AÑO.
        public DataTable buscarComprasMesAño(string NombreProducto, int mes, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto  LIKE '%" + NombreProducto + "%' AND MONTH(c.FechaCompra) = @Mes AND YEAR(c.FechaCompra) = @Año AND c.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Año", año);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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







        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL AÑO.
        public DataTable buscarComprasAño(string NombreProducto, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
               "WHERE  p.NombreProducto  LIKE '%" + NombreProducto + "%' AND YEAR(c.FechaCompra) = @Año AND c.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Año", año);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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





        // METODO PARA MOSTRAR LAS COMPRAS DEL DIA ACTUAL - ("FORMULARIO DE REGISTRAR COMPRAS").
        public DataTable ConsultarCompras()
        {

            string sql = "SELECT c.IdCompra, p.IdProducto, p.NombreProducto, c.PrecioCompra, c.CantidadComprada, c.Total, c.FechaCompra FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto WHERE DATE(c.FechaCompra) = CURDATE() AND c.Activo = 1 ORDER BY IdCompra ASC;";

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



        

        // METODO PARA CARGAR PRODUCTOS EN UN COMBOBOX - ("FORMULARIO DE REGISTRAR COMPRAS").
        public DataTable consultarProductos()
        {
            string sql = "SELECT IdProducto, NombreProducto FROM Productos WHERE Activo = 1 ORDER BY NombreProducto ASC;";


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
        








        //METODO PARA MOSTRAR EL PRECIO DE UN PRODUCTOS
        public decimal ConsultarPrecioProducto(int id)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal precioProducto = 0;

            string sql = "SELECT PrecioCompra FROM Productos WHERE IdProducto = @idProducto;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@idProducto", id);

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    precioProducto = reader.GetDecimal(reader.GetOrdinal("PrecioCompra"));
                }

            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar el precio a la base de datos, erro: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return precioProducto;
        }





        // ------------------- FILTROS DE BUSQUEDA DE COMPRAS PARA FORMULARIO COMPRAS -------------------





        // METODO PARA BUSCAR COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO EL DIA QUE SE QUIERA CONSULTAR
        public DataTable filtrarFecha(DateTime fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c " +
                "INNER JOIN Productos p ON c.IdProducto = p.IdProducto WHERE DATE(c.FechaCompra) = @FechaSeleccionada "  +
                " AND c.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@FechaSeleccionada", fecha.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return dt;
        }






        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO LA SEMANA QUE SE QUIERA CONSULTAR
        public DataTable consultarComprasSemana(DateTime fecha)
        {
            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total " +
                         "FROM Compras c INNER JOIN Productos p ON c.IdProducto = p.IdProducto " +
                         "WHERE WEEKOFYEAR(c.FechaCompra) = WEEKOFYEAR(@Fecha) AND c.Activo = 1 " +
                         "GROUP BY p.IdProducto, p.NombreProducto " +
                         "ORDER BY SUM(c.CantidadComprada) DESC;";

            Conexion conexion = new Conexion();
            MySqlConnection conex = conexion.getConexion();
            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@Fecha", fecha);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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







        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO, SELECCIONANDO EL MES Y EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarComprasMesAño(int mes, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c " +
                "INNER JOIN Productos p ON c.IdProducto = p.IdProducto WHERE MONTH(c.FechaCompra) = "+ mes +" AND YEAR(c.FechaCompra) = "+ año  +
                " AND c.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";

            // Crea una nueva conexión a la base de datos
            // Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

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









        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONADO EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarComprasAño(int año)
        {
            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(c.CantidadComprada) AS CantidadComprada, SUM(c.Total) AS Total FROM Compras c " +
                "INNER JOIN Productos p ON c.IdProducto = p.IdProducto WHERE YEAR(c.FechaCompra) = "+ año +
                " AND c.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(c.CantidadComprada) DESC;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

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










        // ------------------- DETALLES DE LAS COMPRAS -------------------








        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y EL DIA ESPECIFICIO
        public DataTable ConsultarDetalleDiaCompra(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT c.IdCompra, p.IdProducto, p.NombreProducto, c.PrecioCompra, c.CantidadComprada, c.Total, c.FechaCompra FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND DATE(c.FechaCompra) = @Fecha AND c.Activo = 1 ORDER BY c.FechaCompra DESC;";

            // Crea una nueva conexión a la base de datos
            // Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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





        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y LA SEMANA ESPECIFICIA
        public DataTable ConsultarDetalleSemanaCompra(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT c.IdCompra, p.IdProducto, p.NombreProducto, c.PrecioCompra, c.CantidadComprada, c.Total, c.FechaCompra FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto = @NombreProducto AND WEEKOFYEAR(c.FechaCompra) = WEEKOFYEAR(@Fecha) AND c.Activo = 1 ORDER BY c.FechaCompra DESC;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
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




        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO, EL MES Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleMesAñoCompra(string NombreProducto, int mes, int año)
        {

            // Consulta SQL con filtro por mes y año
            string sql = "SELECT c.IdCompra, p.IdProducto, p.NombreProducto, c.PrecioCompra, c.CantidadComprada, c.Total, c.FechaCompra " +
               "FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto = @NombreProducto AND MONTH(c.FechaCompra) = @Mes AND YEAR(c.FechaCompra) = @Año AND c.Activo = 1 ORDER BY c.FechaCompra DESC;";


            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Año", año);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleAñoCompra(string NombreProducto, int año)
        {

            // Consulta SQL con filtro por mes y año
            string sql = "SELECT c.IdCompra, p.IdProducto, p.NombreProducto, c.PrecioCompra, c.CantidadComprada, c.Total, c.FechaCompra " +
                "FROM Compras c INNER JOIN productos p ON c.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND YEAR(c.FechaCompra) = @Año AND c.Activo = 1 ORDER BY c.FechaCompra DESC;";


            Conexion conexion = new Conexion();

            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmd.Parameters.AddWithValue("@Año", año);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;
        }







        // ------------------- METODOS PARA CONSULTAR LOS GASTOS OBTENIDOS -------------------







        // METODO PARA CONSULTAR LOS GASTOS POR DIA ESPECIFICO
        public decimal consultarGastosPorDia(DateTime fecha)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GastosTotal FROM Compras WHERE DATE(FechaCompra) = @FechaSeleccionada AND Activo = 1;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {


                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@FechaSeleccionada", fecha.ToString("yyyy-MM-dd"));

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("GastosTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GastosTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los gastos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return gananciaTotal;
        }






        // METODO PARA CONSULTAR LOS GASTOS POR SEMANA ESPECIFICA
        public decimal consultarGastosPorSemana(DateTime fecha)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GastosTotal FROM Compras WHERE WEEKOFYEAR(FechaCompra) = WEEKOFYEAR(@Fecha) AND Activo = 1;";


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {


                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd"));

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("GastosTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GastosTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los gastos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return gananciaTotal;
        }








        // METODO PARA CONSULTAR LOS GASTOS POR MES Y AÑO ESPECIFICOS
        public decimal consultarGastosPorMesAño(int mes, int año)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GastosTotal FROM Compras WHERE MONTH(FechaCompra) = @Mes AND YEAR(FechaCompra) = @Año AND Activo = 1;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {


                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@Mes", mes);
                comando.Parameters.AddWithValue("@Año", año);

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("GastosTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GastosTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los gastos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return gananciaTotal;
        }





        // METODO PARA CONSULTAR LOS GASTOS POR AÑO ESPECIFICO
        public decimal consultarGastosPorAño(int año)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GastosTotal FROM Compras WHERE YEAR(FechaCompra) = @Año AND Activo = 1;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {


                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@Año", año);

                // Ejecuta la consulta y obtiene un lector de datos
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("GastosTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GastosTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los gastos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }
            return gananciaTotal;
        }
    }

}
