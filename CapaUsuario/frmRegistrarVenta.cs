using CapaEntidades;
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
    public partial class frmRegistrarVenta : Form
    {
        public frmRegistrarVenta()
        {
            InitializeComponent();
            MostrarProductos(); // Se cargan los datos en la tabla productos
            MostrarVentas(); // Carga inicialmente todos los datos de la bd en la tabla
            cargarProductos(); // CARGA LOS PRODUCTO EN EL COMBOBOX AL INICIAR AL PROGRAMA
        }


        // METODO PARA MOSTRAR  LOS PRODUCTOS
        public void MostrarProductos()
        {
            ProductosNegocio productos = new ProductosNegocio();

            try
            {
                DataTable dt = productos.ConsultarProductos();

                dgvProductos.DataSource = dt;

                // Ocultar la columna de ID
                dgvProductos.Columns["IdProducto"].Visible = false;
                dgvProductos.Columns["IdCategoria"].Visible = false;
                dgvProductos.Columns["Activo"].Visible = false;

                // Cambiar el nombre de la columna "NombreProducto" a "Productos"
                dgvProductos.Columns["NombreProducto"].HeaderText = "Productos";
                dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["PrecioCompra"].HeaderText = "Precio compra";
                dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio venta";
                dgvProductos.Columns["NombreCategoria"].HeaderText = "Categoria";
                dgvProductos.Columns["CantidadDisponible"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        // METODO PARA CARGAR LOS DATOS EN LA TABLA DE VENTAS
        public void MostrarVentas()
        {
            VentasNegocio ventas = new VentasNegocio();

            try
            {
                DataTable dt = ventas.ConsultarVentas();

                dgvVentas.DataSource = dt;

                // Ocultar la columna de ID
                dgvVentas.Columns["IdVenta"].Visible = false;
                dgvVentas.Columns["IdProducto"].Visible = false;

                // Cambiar el nombre de la columna "NombreProducto" a "Productos"
                dgvVentas.Columns["NombreProducto"].HeaderText = "Productos";
                dgvVentas.Columns["PrecioVenta"].HeaderText = "Precio vendida";
                dgvVentas.Columns["CantidadVendida"].HeaderText = "Cantidad";
                dgvVentas.Columns["Total"].HeaderText = "Total";
                dgvVentas.Columns["FechaVenta"].HeaderText = "Fecha";


                decimal totalDia = ventas.consultarIngresosPorDia(DateTime.Now);

                lbVentas.Text = totalDia.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // METODO PARA CARGAR LOS PRODUCTOS DEL COMBOBOX PRODUCTOS
        public void cargarProductos()
        {
            VentasNegocio ventas = new VentasNegocio();

            DataTable dt = ventas.consultarProductos();

            cbProducto.ValueMember = "IdProducto";
            cbProducto.DisplayMember = "NombreProducto";

            cbProducto.DataSource = dt;

            cbProducto.SelectedIndex = -1;
        }





        // EVENTO CELL CLIC DE DATAGRIDVIEW PRODUCTOS: Al seleccionar un campo de la tabla productos se asigna el producto a a vender al combobox productos
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Obtener la fila actual seleccionada
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                int idProducto = (int)row.Cells["IdProducto"].Value;

                cbProducto.SelectedValue = idProducto;
            }
        }






        // EVENTO SELECTED INDEX CHANGED DE COMBOBOX PRODUCTOS: Al seleccionar un producto en el combobox se mostrara el precio de ese producto en el textbox precio y la existencia
        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Valida que el combobox no tenga un item seleccionado
            if (cbProducto.SelectedIndex != -1)
            {
                // Valida que el combobox no este vacio
                if (cbProducto.SelectedItem != null)
                {
                    // Obtiene el id del producto seleccionado en el combobox
                    int id = Convert.ToInt32(cbProducto.SelectedValue); ;

                    VentasNegocio ventas = new VentasNegocio();

                    // Obtenemos el precio del producto seleccionado en el combobox atraves de un metodo de la clase ventas
                    decimal precio = ventas.ConsultarPrecioProducto(id);

                    // Se muestra el precio en el textbox precio
                    tbPrecioVenta.Text = precio.ToString();

                    ProductosNegocio productos = new ProductosNegocio();

                    // Consultamos las existencias del producto
                    int existencias = productos.consultarExistencias(id);
                    tbCantidadDisponible.Text = existencias.ToString();
                }
            }
            else
            {
                tbPrecioVenta.Text = "0.00"; // Si el combobox no tienen un item seleccinado el textbox precio mostrara $0.00
                tbCantidadDisponible.Text = "1";
            }
        }







        public event Action? VentaAgregada; // Evento que se disparará al agregar el producto y notifica al formulario frmproductos


        // BOTON PARA REGISTRAR UNA NUEVA VENTA
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {

            int idProducto = Convert.ToInt32(cbProducto.SelectedValue);
            decimal precio = Convert.ToDecimal(tbPrecioVenta.Text);
            int cantidad = Convert.ToInt32(ndCantidadVendida.Text);
            DateTime fecha = dtpFechaVenta.Value;


            try
            {
                VentasNegocio ventas = new VentasNegocio();

                if(cbProducto.SelectedIndex != -1)
                {
                    bool agregado = ventas.registrarVenta(idProducto, precio, cantidad, fecha, out string mensaje);

                    if (agregado)
                    {
                        MostrarVentas(); // Carga inicialmente todos los datos de la bd en la tabla
                        MostrarProductos(); // Se cargan los datos en la tabla productos

                        // Limpia el combobox tanto su indice como el item
                        cbProducto.SelectedIndex = -1;
                        cbProducto.SelectedItem = null;

                        // Limpia todos los campos
                        ndCantidadVendida.Text = "1";
                        dtpFechaVenta.Value = DateTime.Now;

                        // Después de agregar el producto, disparar el evento y se notifica a frmproductos para que actualice la tabla de productos
                        VentaAgregada?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar un producto para registrar una nueva venta.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        public event Action? VentaCancelada; // Evento que se disparará al cancelar una venta y notifica al formulario frmventas

        // EVENTO CELL DOBLE CLIC DE DATAGRIDVIEW VENTAS: Al seleccionar un campo de la tabla ventas se asigna la venta a cancelar.
        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
                if (e.RowIndex >= 0)
                {
                    // Mostrar un cuadro de diálogo de confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar esta venta?",
                                                             "Confirmar cancelación",
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxIcon.Warning);

                    // Verificar si el usuario presionó el botón "OK"
                    if (resultado == DialogResult.OK)
                    {
                        // Obtener la fila actual seleccionada
                        DataGridViewRow row = dgvVentas.Rows[e.RowIndex];

                        // Asignar los valores de la fila a los controles correspondientes
                        int idVenta = (int)row.Cells["IdVenta"].Value;
                        // decimal precioCompra = (decimal)row.Cells["precioCompraDataGridViewTextBoxColumn1"].Value;
                        int cantidad = (int)row.Cells["CantidadVendida"].Value;
                        int idProducto = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["IdProducto"].Value);

                        VentasNegocio ventas = new VentasNegocio();

                        // Cancelación de la compra
                        bool cancelado = ventas.cancelarVenta(idVenta, cantidad, idProducto);

                        if (cancelado)
                        {
                            // Actualiza las tablas
                            MostrarVentas();
                            MostrarProductos();

                            // Después de cancelar la compra, disparar el evento y se notifica a frmcompras para que actualice la tabla de compras
                            VentaCancelada?.Invoke();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







        // EVENTO KEY DOWN DE TEXTBOX BUSCAR PRODUCTO: AL PRESIONAR ENTER EN EL TEXTBOX BUSCAR PRODUCTO BUSCARA EL PRODUCTO SIN NECESIDAD DEL BOTON.
        private void tbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // Se toma el texto ingresado en la barra de busqueda y se almacena en la variable dato
                string dato = tbBuscarProducto.Text;

                ProductosNegocio productos = new ProductosNegocio();


                // Se asigna todos los datos a la tabla de productos por medio del metodo buscar productos del controlador
                dgvProductos.DataSource = productos.BuscarProductos(dato);

                pbBotonQuitarBusqueda.Visible = true;
                pbBotonQuitarBusqueda.Enabled = true;
                lbQuirarBusqueda.Visible = true;

                tbBuscarProducto.Text = "";

                e.SuppressKeyPress = true;
            }
        }



        //BOTON PARA QUITAR FILTRO DE BUSQUEDA
        private void pbBotonQuitarBusqueda_Click(object sender, EventArgs e)
        {
            tbBuscarProducto.Text = "";
            MostrarProductos();
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Enabled = false;
            lbQuirarBusqueda.Visible = false;
        }

    }
}
