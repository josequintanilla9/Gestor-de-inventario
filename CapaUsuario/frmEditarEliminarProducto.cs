using CapaEntidades;
using CapaNegocio;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class frmEditarEliminarProducto : Form
    {
        public frmEditarEliminarProducto()
        {
            InitializeComponent();
        }



        // CONSTRUCTO QUE RECIBE LOS PARAMETROS NECESARIOS DEL FORMULARIO PRODUCTOS PARA LLENAR LOS CAMPOS PARA EDITAR HE ELIMAR
        public frmEditarEliminarProducto(string idProducto, string nombreProducto, string? descripcion,
                                     decimal precioCompra, decimal precioVenta, int cantidadDisponible, int idCategoria)
        {
            InitializeComponent();

            cargarCategorias(); // Se cargan las categorias en el combobox categorias

            // Asignar los valores recibidos a los controles del formulario
            tbIdProducto.Text = idProducto;
            tbNombreProducto.Text = nombreProducto;
            tbDescripcion.Text = descripcion;
            tbPrecioCompra.Text = precioCompra.ToString();
            tbPrecioVenta.Text = precioVenta.ToString();
            ndCantidadDisponible.Value = cantidadDisponible;
            cbCategorias.SelectedValue = idCategoria; // Asignar la categoría al ComboBox
        }




        // METODO PARA CARGAR LAS CATEGORIA EN COMBOBOX
        public void cargarCategorias()
        {
            ProductosNegocio productos = new ProductosNegocio();

            DataTable dt = productos.mostrarCategorias();

            cbCategorias.ValueMember = "IdCategoria";
            cbCategorias.DisplayMember = "NombreCategoria";
            cbCategorias.DataSource = dt;
        }







        public event Action? ProductoEditado; // Evento que se disparará al editar el producto y notifica al formulario frmproductos

        // BOTON PARA EDITAR LA INFORMACION DE UN PRODUCTO
        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            ProductosNegocio productos = new ProductosNegocio();

            int idProducto = Convert.ToInt32(tbIdProducto.Text);
            string nombre = tbNombreProducto.Text;
            string descripcion = tbDescripcion.Text;
            decimal precioCompra = Convert.ToDecimal(tbPrecioCompra.Text);
            decimal precioVenta = Convert.ToDecimal(tbPrecioVenta.Text);
            int idCategoria = Convert.ToInt32(cbCategorias.SelectedValue);
            int cantidad = Convert.ToInt32(ndCantidadDisponible.Text);

            try
            {
                // Mostrar un cuadro de diálogo de confirmación antes de actualizar
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas editar este producto?",
                                                        "Confirmar los cambios",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Warning);

                // Verificar si el usuario presionó el botón "OK"
                if (resultado == DialogResult.OK)
                {
                    bool editado = productos.editarProducto(idProducto, nombre, descripcion, precioCompra, precioVenta, idCategoria, cantidad, out string mensaje);

                    if (editado)
                    {
                        // Después de agregar el producto, disparar el evento y se notifica a frmproductos para que actualice la tabla de productos
                        ProductoEditado?.Invoke();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        public event Action? ProductoEliminado; // Evento que se disparará al editar el producto y notifica al formulario frmproductos

        // BOTON PARA ELIMINAR UN PRODUCTO
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar un cuadro de diálogo de confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                         "Confirmar eliminación",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Warning);

                // Verificar si el usuario presionó el botón "OK"
                if (resultado == DialogResult.OK)
                {
                    ProductosNegocio productos = new ProductosNegocio();

                    int idProducto = Convert.ToInt32(tbIdProducto.Text);

                    bool desactivado = productos.desactivarProducto(idProducto);

                    if (desactivado)
                    {
                        // Después de agregar el producto, disparar el evento y se notifica a frmproductos para que actualice la tabla de productos
                        ProductoEliminado?.Invoke();

                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // -------------------------------- VALIDACIONES  ---------------------------------------------





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






        // EVENTO DOBLE CLIC DE TEXTBOX PRECIO COMPRA: Se encarga de limpiar el textbox precio compra cuando se va ingresar un precio
        private void tbPrecioCompra_DoubleClick(object sender, EventArgs e)
        {
            tbPrecioCompra.Text = "";
        }





        // EVENTO DOBLE CLIC DE TEXTBOX PRECIO VENTA: Se encarga de limpiar el textbox precio venta cuando se va ingresar un precio
        private void tbPrecioVenta_DoubleClick(object sender, EventArgs e)
        {
            tbPrecioVenta.Text = "";
        }





        // EVENTO DOBLE CLIC DE TEXTBOX NOMBRE PRODUCTO: Se encarga de limpiar el textbox nombre cuando se va ingresar un precio
        private void tbNombreProducto_DoubleClick(object sender, EventArgs e)
        {
            tbNombreProducto.Text = "";
        }





        // EVENTO DOBLE CLIC DE TEXTBOX DESCRIPCION: Se encarga de limpiar el textbox descripcion cuando se va ingresar un precio
        private void tbDescripcion_DoubleClick(object sender, EventArgs e)
        {
            tbDescripcion.Text = "";
        }

    }
}
