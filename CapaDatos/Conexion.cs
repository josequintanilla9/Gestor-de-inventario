using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        //Metodo para obtener la conexion
        public MySqlConnection getConexion()
        {

            MySqlConnection conexion;

            try
            {
                // Lee la cadena de conexión desde el archivo app.config
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;


                //Instancia de mysqlconnection utilizando la cadena de conexion
                conexion = new MySqlConnection(connectionString);

                //Abrir conexion a la base de datos
                conexion.Open();

                //Devuelve la conexion
                return conexion;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al establecer la conexion: " + ex.Message);
            }
        }



        //Metodo para cerrar la conexion
        public void cerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                //Cierra la conexion si esta abierta
                conexion.Close();
            }
        }
    }
}
