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
    public partial class frmDetalleVenta : Form
    {
        string nombreProducto = "";
        DateTime? FechaDia;
        DateTime? FechaSemana;
        int? FechaMes;
        int? FechaAño;


        public frmDetalleVenta()
        {
            InitializeComponent();
        }


        // CONSTRUCTOR DE FORMULARIO DETALLE VENTA: Recibe como parametro el nombre del producto seleccionado en la tabla del formulario frmventas y la fecha en que se deben mostrar los detalles de la venta.     
        public frmDetalleVenta(string NombreProducto, DateTime? fechaDia, DateTime? fechaSemana, int? fechaMes, int? fechaAño)
        {
            InitializeComponent();

            nombreProducto = NombreProducto;
            FechaDia = fechaDia;
            FechaSemana = fechaSemana;
            FechaMes = fechaMes;
            FechaAño = fechaAño;

            // Muestra los detalles de la compra seleccionada.
            mostarDetalleVenta();

        }





        // METODO PARA MOSTRAR LOS DETALLES DE LA VENTA SELECIONADA
        public void mostarDetalleVenta()
        {
            VentasNegocio ventas = new VentasNegocio();

            DataTable dt;



            // ---------- CONDICIONES PARA MOSTRAR LOS DETALLES DE VENTAS SEGÚN EL FILTRO ----------



            // Inicialmente si no se ha activado un filtro de busqueda, mostrara los detalles de las ventas de la semana actual.
            if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño == null)
            {

                DateTime semanaActual = DateTime.Now; //Se obtiene la fecha de la semana actual.

                //Consulta los detalles de venta de un producto segun la semana actual.

                dt = ventas.ConsultarDetalleSemanaVenta(nombreProducto, semanaActual);
                dgvDetalleVenta.DataSource = dt;
            }



            // Muestra los detalles de venta de un dia especifico seleccionado en el filtro de busqueda.
            if (FechaDia != null && FechaSemana == null && FechaMes == null && FechaAño == null)
            {
                dt = ventas.ConsultarDetalleDiaVenta(nombreProducto, FechaDia ?? DateTime.Now);

                // Consulta los detalles de venta de un producto según un dia especifico.
                dgvDetalleVenta.DataSource = dt;
            }




            // Muestra los detalles de ventas de una semana especifica seleccionada en el filtro de busqueda.
            if (FechaDia == null && FechaSemana != null && FechaMes == null && FechaAño == null)
            {
                dt = ventas.ConsultarDetalleSemanaVenta(nombreProducto, FechaSemana ?? DateTime.Now);

                // Consulta los detalles de venta de un producto según una semana especifica. 
                dgvDetalleVenta.DataSource = dt;
            }



            //Muestra los detalles de venta de un mes y año especificos seleccionados en el filtro de busqueda.
            if (FechaDia == null && FechaSemana == null && FechaMes != null && FechaAño != null)
            {
                dt = ventas.ConsultarDetalleMesAñoVenta(nombreProducto, FechaMes ?? 0, FechaAño ?? 0);

                // Consulta los detalles de venta de un producto según un mes y año especificos.
                dgvDetalleVenta.DataSource = dt;
            }




            //Muesta los detalles de ventas de un año especifico seleccionado en el filtro de busqueda.
            if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño != null)
            {
                dt = ventas.ConsultarDetalleAñoVenta(nombreProducto, FechaAño ?? 0);

                // Consulta los detalles de ventas de un producto según un mes especifico.
                dgvDetalleVenta.DataSource = dt;
            }

            // Ocultar la columna de ID
            dgvDetalleVenta.Columns["IdVenta"].Visible = false;
            dgvDetalleVenta.Columns["IdProducto"].Visible = false;

            // Cambiar el nombre de la columna "NombreProducto" a "Productos"
            dgvDetalleVenta.Columns["NombreProducto"].HeaderText = "Productos";
            dgvDetalleVenta.Columns["PrecioVenta"].HeaderText = "Precio venta";
            dgvDetalleVenta.Columns["CantidadVendida"].HeaderText = "Cantidad";
            dgvDetalleVenta.Columns["Total"].HeaderText = "Total";
            dgvDetalleVenta.Columns["FechaVenta"].HeaderText = "Fecha";
        }







        public event Action? VentaCancelada; // Evento que se disparará al cancelar una venta y notifica al formulario frmventas

        // EVENTO CELL CLIC DE DATAGRIDVIEW DETALLE DE VENTA: Al seleccionar un campo de la tabla detalle de ventas se puede eliminar la venta seleccionada.
        private void dgvDetalleVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    DataGridViewRow row = dgvDetalleVenta.Rows[e.RowIndex];

                    // Obtener los valores de la fila
                    int idVenta = Convert.ToInt32(row.Cells["IdVenta"].Value);
                    int cantidadVendida = Convert.ToInt32(row.Cells["CantidadVendida"].Value);
                    int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);

                    VentasNegocio ventas = new VentasNegocio();


                    // Inicialmente si no se ha activado un filtro de busqueda, mostrara los detalles de las ventas de la semana actual.
                    if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño == null)
                    {

                        ventas.cancelarVenta(idVenta, cantidadVendida, idProducto);

                        ProductosNegocio productos = new ProductosNegocio();


                        DateTime semanaActual = DateTime.Now; //Se obtiene la fecha de la semana actual.

                        //Consulta los detalles de venta de un producto segun la semana actual.
                        dgvDetalleVenta.DataSource = ventas.ConsultarDetalleSemanaVenta(nombreProducto, semanaActual);
                    }



                    // Muestra los detalles de compras de un dia especifico seleccionado en el filtro de busqueda.
                    if (FechaDia != null && FechaSemana == null && FechaMes == null && FechaAño == null)
                    {

                        ventas.cancelarVenta(idVenta, cantidadVendida, idProducto);

                        // Consulta los detalles de compra de un producto según un dia especifico.
                        dgvDetalleVenta.DataSource = ventas.ConsultarDetalleDiaVenta(nombreProducto, FechaDia ?? DateTime.Now);
                    }



                    // Muestra los detalles de compras de una semana especifica seleccionada en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana != null && FechaMes == null && FechaAño == null)
                    {
                        ventas.cancelarVenta(idVenta, cantidadVendida, idProducto);


                        // Consulta los detalles de compra de un producto según una semana especifica. 
                        dgvDetalleVenta.DataSource = ventas.ConsultarDetalleSemanaVenta(nombreProducto, FechaSemana ?? DateTime.Now);
                    }



                    //Muestra los detalles de compras de un mes y año especificos seleccionados en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana == null && FechaMes != null && FechaAño != null)
                    {

                        ventas.cancelarVenta(idVenta, cantidadVendida, idProducto);


                        // Consulta los detalles de compras de un producto según un mes y año especificos.
                        dgvDetalleVenta.DataSource = ventas.ConsultarDetalleMesAñoVenta(nombreProducto, FechaMes ?? 0, FechaAño ?? 0);
                    }


                    //Muesta los detalles de compras de un año especifico seleccionado en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño != null)
                    {
                        ventas.cancelarVenta(idVenta, cantidadVendida, idProducto);

                        // Consulta los detalles de compras de un producto según un mes especifico.
                        dgvDetalleVenta.DataSource = ventas.ConsultarDetalleAñoVenta(nombreProducto, FechaAño ?? 0);
                    }

                    // Después de cancelar la compra, disparar el evento y se notifica a frmcompras para que actualice la tabla de compras
                    VentaCancelada?.Invoke();
                }
            }
        }
    }
}
