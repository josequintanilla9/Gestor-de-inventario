using CapaNegocio;
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
    public partial class frmAgregarProducto : Form
    {
        public frmAgregarProducto()
        {

            InitializeComponent();
            cargarCategorias(); // Se cargan las categorias en el combobox categorias


        }



        // METODO PARA CARGAR LAS CATEGORIAS DEL COMBOBOX CATEGORIAS
        public void cargarCategorias()
        {
            ProductosNegocio productos = new ProductosNegocio();

            DataTable dt = productos.mostrarCategorias();

            cbCategorias.ValueMember = "IdCategoria";
            cbCategorias.DisplayMember = "NombreCategoria";
            cbCategorias.DataSource = dt;
        }







        public event Action? ProductoAgregado; // Evento que se disparará al agregar el producto y notifica al formulario frmproductos

        // BOTON PARA AGREGAR UN NUEVO PRODUCTO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductosNegocio productos = new ProductosNegocio();

            string nombre = tbNombreProducto.Text;
            string descripcion = tbDescripcion.Text;
            decimal precioCompra = Convert.ToDecimal(tbPrecioCompra.Text);
            decimal precioVenta = Convert.ToDecimal(tbPrecioVenta.Text);
            int idCategoria = Convert.ToInt32(cbCategorias.SelectedValue);
            int cantidad = Convert.ToInt32(ndCantidadDisponible.Text);

            

            try
            {
                bool agregado = productos.agregarProducto(nombre, descripcion, precioCompra, precioVenta, idCategoria, cantidad, out string mensaje);

                if (agregado)
                {

                    tbNombreProducto.Text = "";
                    tbDescripcion.Text = "";
                    tbPrecioCompra.Text = "0.00";
                    tbPrecioVenta.Text = "0.00";
                    ndCantidadDisponible.Text = "0";


                    // Después de agregar el producto, disparar el evento y se notifica a frmproductos para que actualice la tabla de productos
                    ProductoAgregado?.Invoke();
                }
                else
                {
                    MessageBox.Show(mensaje, "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        // -------------------------------- VALIDACIONES DE CAMPOS ---------------------------------------------







        // EVENTO CLIC DE TEXTBOX PRECIO COMPRA: Se encarga de limpiar el textbox precio compra cuando se va ingresar un precio
        private void tbPrecioCompra_Click(object sender, EventArgs e)
        {
            tbPrecioCompra.Text = "";
        }




        // EVENTO CLIC DE TEXTBOX PRECIO VENTA: Se encarga de limpiar el textbox precio venta cuando se va ingresar un precio
        private void tbPrecioVenta_Click(object sender, EventArgs e)
        {
            tbPrecioVenta.Text = "";
        }




        // EVENTO VALIDATING DE TEXTBOX PRECIO COMPRA: Este evento se encarga de validar que el dato ingresado en el textbox precio compra sea un numero
        private void tbPrecioCompra_Validating(object sender, CancelEventArgs e)
        {
            double numero;
            if (!double.TryParse(tbPrecioCompra.Text, out numero))
            {
                MessageBox.Show("Por favor, ingrese un precio de compra válido.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPrecioCompra.Text = "0.00";
                e.Cancel = true; // Cancela la salida del campo si el valor no es válido
            }
            else if (numero < 0)
            {
                MessageBox.Show("El precio de compra no puede ser negativo.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPrecioCompra.Text = "0.00";
                e.Cancel = true; // Cancela la salida del campo si el valor es negativo
            }

        }





        // EVENTO VALIDATING DE TEXTBOX PRECIO VENTA: Este evento se encarga de validar que el dato ingresado en el textbox precio venta sea un numero
        private void tbPrecioVenta_Validating(object sender, CancelEventArgs e)
        {
            double numero;
            if (!double.TryParse(tbPrecioVenta.Text, out numero))
            {
                MessageBox.Show("Por favor, ingrese un precio de venta válido.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPrecioVenta.Text = "0.00";
                e.Cancel = true; // Cancela la salida del campo si el valor no es válido
            }
            else if (numero < 0)
            {
                MessageBox.Show("El precio de venta no puede ser negativo.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPrecioVenta.Text = "0.00";
                e.Cancel = true; // Cancela la salida del campo si el valor es negativo
            }
        }





        // EVENTO VALIDATING NUMERIC UP DOWN DE CANTIDAD DISPONIBLE: Se encarga de validar que el control de cantidad disponible no quede vacio
        private void ndCantidadDisponible_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ndCantidadDisponible.Text))
            {
                ndCantidadDisponible.Value = 0;
                ndCantidadDisponible.Text = "0";
            }
        }
    }
}
