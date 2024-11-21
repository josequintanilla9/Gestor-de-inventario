using CapaDatos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();

            conexion();
        }


        // SE CREA Y SE CIERRA UNA CONEXION A LA BD AL INICIAR EL PROGRAMA PARA QUE GUARDE EN CACHE LOS COMPONENTES NECESARIOS.
        public void conexion()
        {
            // Crea una nueva conexión a la base de datos
            //Modelo.Conexion conexion = new Conexion("localhost", "3306", "tiendaarcoiris", "root", "123456");

            Conexion conexion = new Conexion();

            // Obtiene la conexión a la base de datos
            MySqlConnection conex = conexion.getConexion();

            conexion.cerrarConexion(conex);
        }


        // VARIABLE FORMULARIO: para controlar si hay un formulario que se esta mostrando en el panel contenedor
        Form? formularioActual = null; //Inicialmente estara vacio



        //METODO PARA MOSTRAR UN FORMULARIO EN EL CONTENEDOR
        private void abrirFormulario(Form formulario) //Recibe como parametro un formulario
        {
            // Si la variable formularioActual contiene un formulario que se esta mostrando en el panel contenedor lo cerrara
            if (formularioActual != null)
            {
                formularioActual.Close();
            }

            // Aqui la variable formularioActual captura los formularios que se estan mostrando en el panel contenedor
            formularioActual = formulario;

            formulario.TopLevel = false; // convierte el formulario que se mostrara en hijo para mostrarse dentro de otro formulario
            contenedor.Controls.Add(formulario); // Añade el formulario al panel contenedor
            formulario.BringToFront(); //Lo trae al frente
            formulario.Dock = DockStyle.Fill;
            formulario.Show(); //Muestra el formulario
        }


        


        //BOTON VENTAS: Dirige a la pantalla de ventas
        private void btnVentas_Click(object sender, EventArgs e)
        {
            //Al dar clic al boton se mantiene de color gris y los otros en blanco
            btnVentas.BackColor = Color.Silver;
            btnCompras.BackColor = Color.White;
            btnProductos.BackColor = Color.White;
            abrirFormulario(new frmVentas()); //Metodo para mostrar un formulario en el contenedor

        }



        //BOTON COMPRAS: Dirige a la pantalla de compras
        private void btnCompras_Click(object sender, EventArgs e)
        {
            //Al dar clic al boton se mantiene de color gris y los otros en blanco
            btnVentas.BackColor = Color.White;
            btnCompras.BackColor = Color.Silver;
            btnProductos.BackColor = Color.White;
            abrirFormulario(new frmCompras()); //Metodo para mostrar un formulario en el contenedor

        }

        

        //BOTON PRODUCTOS: Dirige a la pantalla de productos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            //Al dar clic al boton se mantiene de color gris y los otros en blanco
            btnVentas.BackColor = Color.White;
            btnCompras.BackColor = Color.White;
            btnProductos.BackColor = Color.Silver;
            abrirFormulario(new frmProductos()); //Metodo para mostrar un formulario en el contenedor

        }
    }
}
