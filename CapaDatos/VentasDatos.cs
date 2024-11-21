using CapaEntidades;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class VentasDatos
    {

        // METODO PARA REGISTRAR UNA NUEVA VENTA
        public bool registrarVenta(int idProducto, decimal precio, int cantidad, decimal total, DateTime fecha)
        {
            bool registrado = false;


            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "INSERT INTO Ventas(IdProducto, PrecioVenta, CantidadVendida, Total, FechaVenta) " +
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



        // METODO PARA CANCELAR UNA VENTA
        public bool cancelarVenta(int idVenta)
        {
            bool cancelado = false;

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            try
            {
                string sql = "UPDATE Ventas SET Activo = 0 WHERE IdVenta = @idVenta";

                // Crea un comando con la consulta SQL y la conexión
                MySqlCommand comando = new MySqlCommand(sql, conex);

                // Se utilizan parametros para evitar la inyeccion SQL
                comando.Parameters.AddWithValue("@idVenta", idVenta);

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







        // METODO PARA BUSCAR LA VENTAS DE UN PRODUCTO ESPECIFICANDO EL DIA.
        public DataTable buscarVentasDia(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM Ventas v " +
               "INNER JOIN Productos p ON v.IdProducto = p.IdProducto WHERE p.NombreProducto LIKE '%" + NombreProducto + "%' AND DATE(v.FechaVenta) = @FechaSeleccionada " +
               "AND v.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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





        // METODO PARA BUSCAR LA VENTAS DE UN PRODUCTO ESPECIFICANDO LA SEMANA.
        public DataTable buscarVentasSemana(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto LIKE '%" + NombreProducto + "%' AND WEEKOFYEAR(v.FechaVenta) = WEEKOFYEAR(@Fecha) AND v.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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






        // METODO PARA BUSCAR LA VENTAS DE UN PRODUCTO ESPECIFICANDO EL MES Y AÑO.
        public DataTable buscarVentasMesAño(string NombreProducto, int mes, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
               "WHERE p.NombreProducto  LIKE '%" + NombreProducto + "%' AND MONTH(v.FechaVenta) = @Mes AND YEAR(v.FechaVenta) = @Año AND v.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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




        // METODO PARA BUSCAR LA VENTAS DE UN PRODUCTO ESPECIFICANDO EL AÑO.
        public DataTable buscarVentasAño(string NombreProducto, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
               "WHERE  p.NombreProducto  LIKE '%" + NombreProducto + "%' AND YEAR(v.FechaVenta) = @Año AND v.Activo = 1 " +
               "GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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









        // METODO PARA MOSTRAR LAS VENTAS DEL DIA ACTUAL - ("FORMULARIO DE REGISTRAR VENTAS").
        public DataTable ConsultarVentas()
        {

            string sql = "SELECT v.IdVenta, p.IdProducto, p.NombreProducto, v.PrecioVenta, v.CantidadVendida, v.Total, v.FechaVenta FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto WHERE DATE(v.FechaVenta) = CURDATE() AND v.Activo = 1 ORDER BY IdVenta ASC;";

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





        // METODO PARA CARGAR PRODUCTOS EN UN COMBOBOX - ("FORMULARIO DE REGISTRAR VENTAS").
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










        // ------------------- FILTROS DE BUSQUEDA DE VENTAS PARA FORMULARIO VENTAS -------------------





        // METODO PARA BUSCAR VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO EL DIA QUE SE QUIERA CONSULTAR
        public DataTable filtrarFecha(DateTime fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM Ventas v " +
                "INNER JOIN Productos p ON v.IdProducto = p.IdProducto WHERE DATE(v.FechaVenta) = @FechaSeleccionada " +
                " AND v.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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




        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO LA SEMANA QUE SE QUIERA CONSULTAR
        public DataTable consultarVentasSemana(DateTime fecha)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM Ventas v " +
                "INNER JOIN Productos p ON v.IdProducto = p.IdProducto WHERE WEEKOFYEAR(v.FechaVenta) = WEEKOFYEAR(@fecha) " +
                " AND v.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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
                    cmd.Parameters.AddWithValue("@fecha", fecha);

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








        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO, SELECCIONANDO EL MES Y EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarVentasMesAño(int mes, int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM Ventas v " +
                "INNER JOIN Productos p ON v.IdProducto = p.IdProducto WHERE MONTH(v.FechaVenta) = @Mes AND YEAR(v.FechaVenta) = @Año " +
                " AND v.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

            // Crea una nueva conexión a la base de datos.
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos.
            MySqlConnection conex = conexion.getConexion();

            DataTable dt;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conex))
                {
                    // Agrega el parámetro de fecha a la consulta
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Año", año);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje de error si ocurre una excepción al consultar la base de datos.
                throw new Exception("No se pudo consultar a la base de datos, erro: " + ex.Message.ToString());
            }
            finally
            {
                conexion.cerrarConexion(conex);
            }

            return dt;

        }







        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONADO EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarVentasAño(int año)
        {

            string sql = "SELECT p.IdProducto, p.NombreProducto, SUM(v.CantidadVendida) AS CantidadVendida, SUM(v.Total) AS Total FROM Ventas v " +
                "INNER JOIN Productos p ON v.IdProducto = p.IdProducto WHERE YEAR(v.FechaVenta) = @Año " +
                " AND v.Activo = 1 GROUP BY p.IdProducto, p.NombreProducto ORDER BY SUM(v.CantidadVendida) DESC;";

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








        // ------------------- DETALLES DE LAS VENTAS -------------------









        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y EL DIA ESPECIFICIO
        public DataTable ConsultarDetalleDiaVenta(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT v.IdVenta, p.IdProducto, p.NombreProducto, v.PrecioVenta, v.CantidadVendida, v.Total, v.FechaVenta FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND DATE(v.FechaVenta) = @Fecha AND v.Activo = 1 ORDER BY v.FechaVenta DESC;";

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







        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y LA SEMANA ESPECIFICIA
        public DataTable ConsultarDetalleSemanaVenta(string NombreProducto, DateTime Fecha)
        {

            string sql = "SELECT v.IdVenta, p.IdProducto, p.NombreProducto, v.PrecioVenta, v.CantidadVendida, v.Total, v.FechaVenta FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND WEEKOFYEAR(v.FechaVenta) = WEEKOFYEAR(@Fecha) AND v.Activo = 1 ORDER BY v.FechaVenta DESC;";

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






        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO, EL MES Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleMesAñoVenta(string NombreProducto, int mes, int año)
        {

            // Consulta SQL con filtro por mes y año
            string sql = "SELECT v.IdVenta, p.IdProducto, p.NombreProducto, v.PrecioVenta, v.CantidadVendida, v.Total, v.FechaVenta " +
                "FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND MONTH(v.FechaVenta) = @Mes AND YEAR(v.FechaVenta) = @Año AND v.Activo = 1 ORDER BY v.FechaVenta DESC;";

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






        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleAñoVenta(string NombreProducto, int año)
        {
            // Consulta SQL con filtro por mes y año
            string sql = "SELECT v.IdVenta, p.IdProducto, p.NombreProducto, v.PrecioVenta, v.CantidadVendida, v.Total, v.FechaVenta " +
                "FROM ventas v INNER JOIN productos p ON v.IdProducto = p.IdProducto " +
                "WHERE p.NombreProducto = @NombreProducto AND YEAR(v.FechaVenta) = @Año AND v.Activo = 1 ORDER BY v.FechaVenta DESC;";

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










        // ------------------- METODOS PARA CONSULTAR LOS INGRESOS OBTENIDOS -------------------






        // METODO PARA CONSULTAR LOS INGRESOS POR DIA ESPECIFICO
        public decimal consultarIngresosPorDia(DateTime fecha)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GananciaTotal FROM Ventas WHERE DATE(FechaVenta) = @FechaSeleccionada AND Activo = 1;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

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
                    if (!reader.IsDBNull(reader.GetOrdinal("GananciaTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GananciaTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los ingresos: " + ex.Message);
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






        // METODO PARA CONSULTAR LOS INGRESOS POR SEMANA ESPECIFICA
        public decimal consultarIngresosPorSemana(DateTime fecha)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GananciaTotal FROM Ventas WHERE WEEKOFYEAR(FechaVenta) = WEEKOFYEAR(@Fecha) AND Activo = 1;";

            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

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
                    if (!reader.IsDBNull(reader.GetOrdinal("GananciaTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GananciaTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los ingresos: " + ex.Message);
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









        // METODO PARA CONSULTAR LOS INGRESOS POR MES Y AÑO ESPECIFICOS
        public decimal consultarIngresosPorMesAño(int mes, int año)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GananciaTotal FROM Ventas WHERE MONTH(FechaVenta) = @Mes AND YEAR(FechaVenta) = @Año AND Activo = 1;";

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
                    if (!reader.IsDBNull(reader.GetOrdinal("GananciaTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GananciaTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los ingresos: " + ex.Message);
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







        // METODO PARA CONSULTAR LOS INGRESOS POR AÑO ESPECIFICO
        public decimal consultarIngresosPorAño(int año)
        {
            MySqlDataReader reader; //Variable para leer los resultados de la consulta

            decimal gananciaTotal = 0;

            string sql = "SELECT SUM(Total) AS GananciaTotal FROM Ventas WHERE YEAR(FechaVenta) = @Año AND Activo = 1;";

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
                    if (!reader.IsDBNull(reader.GetOrdinal("GananciaTotal")))
                    {
                        gananciaTotal = reader.GetDecimal(reader.GetOrdinal("GananciaTotal"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo consultar los ingresos: " + ex.Message);
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
