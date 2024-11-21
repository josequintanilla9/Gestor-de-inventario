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
    public partial class frmDetalleCompra : Form
    {

        string nombreProducto = "";
        DateTime? FechaDia;
        DateTime? FechaSemana;
        int? FechaMes;
        int? FechaAño;


        public frmDetalleCompra()
        {
            InitializeComponent();
        }



        // CONSTRUCTOR DE FORMULARIO DETALLE COMPRA: Recibe como parametro el nombre del producto seleccionado en la tabla del formulario frmcompras y la fecha en que se deben mostrar los detalles de la compra.
        public frmDetalleCompra(string NombreProducto, DateTime? fechaDia, DateTime? fechaSemana, int? fechaMes, int? fechaAño)
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
            ComprasNegocio compras = new ComprasNegocio();

            DataTable dt;



            // ---------- CONDICIONES PARA MOSTRAR LOS DETALLES DE COMPRAS SEGÚN EL FILTRO ----------



            // Inicialmente si no se ha activado un filtro de busqueda, mostrara los detalles de las compras de la semana actual.
            if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño == null)
            {

                DateTime semanaActual = DateTime.Now; //Se obtiene la fecha de la semana actual.

                //Consulta los detalles de compra de un producto segun la semana actual.

                dt = compras.ConsultarDetalleSemanaCompra(nombreProducto, semanaActual);
                dgvDetalleCompra.DataSource = dt;
            }



            // Muestra los detalles de compras de un dia especifico seleccionado en el filtro de busqueda.
            if (FechaDia != null && FechaSemana == null && FechaMes == null && FechaAño == null)
            {
                dt = compras.ConsultarDetalleDiaCompra(nombreProducto, FechaDia ?? DateTime.Now);

                // Consulta los detalles de compra de un producto según un dia especifico.
                dgvDetalleCompra.DataSource = dt;
            }




            // Muestra los detalles de compras de una semana especifica seleccionada en el filtro de busqueda.
            if (FechaDia == null && FechaSemana != null && FechaMes == null && FechaAño == null)
            {
                dt = compras.ConsultarDetalleSemanaCompra(nombreProducto, FechaSemana ?? DateTime.Now);

                // Consulta los detalles de compra de un producto según una semana especifica. 
                dgvDetalleCompra.DataSource = dt;
            }



            //Muestra los detalles de compras de un mes y año especificos seleccionados en el filtro de busqueda.
            if (FechaDia == null && FechaSemana == null && FechaMes != null && FechaAño != null)
            {
                dt = compras.ConsultarDetalleMesAñoCompra(nombreProducto, FechaMes ?? 0, FechaAño ?? 0);

                // Consulta los detalles de compras de un producto según un mes y año especificos.
                dgvDetalleCompra.DataSource = dt;
            }




            //Muesta los detalles de compras de un año especifico seleccionado en el filtro de busqueda.
            if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño != null)
            {
                dt = compras.ConsultarDetalleAñoCompra(nombreProducto, FechaAño ?? 0);

                // Consulta los detalles de compras de un producto según un mes especifico.
                dgvDetalleCompra.DataSource = dt;
            }

            // Ocultar la columna de ID
            dgvDetalleCompra.Columns["IdCompra"].Visible = false;
            dgvDetalleCompra.Columns["IdProducto"].Visible = false;

            // Cambiar el nombre de la columna "NombreProducto" a "Productos"
            dgvDetalleCompra.Columns["NombreProducto"].HeaderText = "Productos";
            dgvDetalleCompra.Columns["PrecioCompra"].HeaderText = "Precio compra";
            dgvDetalleCompra.Columns["CantidadComprada"].HeaderText = "Cantidad";
            dgvDetalleCompra.Columns["Total"].HeaderText = "Total";
            dgvDetalleCompra.Columns["FechaCompra"].HeaderText = "Fecha";
        }




        public event Action? CompraCancelada; // Evento que se disparará al cancelar una compra y notifica al formulario frmcompras

        // EVENTO CELL CLIC DE DATAGRIDVIEW DETALLE DE COMPRA: Al seleccionar un campo de la tabla detalle de compras se puede eliminar la compra seleccionada
        private void dgvDetalleCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Mostrar un cuadro de diálogo de confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar esta compra?",
                                                         "Confirmar cancelación",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Warning);

                // Verificar si el usuario presionó el botón "OK"
                if (resultado == DialogResult.OK)
                {
                    // Obtener la fila actual seleccionada
                    DataGridViewRow row = dgvDetalleCompra.Rows[e.RowIndex];

                    // Obtener los valores de la fila
                    int idCompra = Convert.ToInt32(row.Cells["IdCompra"].Value);
                    int cantidadComprada = Convert.ToInt32(row.Cells["CantidadComprada"].Value);
                    int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);

                    ComprasNegocio compras = new ComprasNegocio();


                    // Inicialmente si no se ha activado un filtro de busqueda, mostrara los detalles de las ventas de la semana actual.
                    if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño == null)
                    {

                        compras.cancelarCompra(idCompra, cantidadComprada, idProducto);

                        ProductosNegocio productos = new ProductosNegocio();


                        DateTime semanaActual = DateTime.Now; //Se obtiene la fecha de la semana actual.

                        //Consulta los detalles de venta de un producto segun la semana actual.
                        dgvDetalleCompra.DataSource = compras.ConsultarDetalleSemanaCompra(nombreProducto, semanaActual);
                    }



                    // Muestra los detalles de compras de un dia especifico seleccionado en el filtro de busqueda.
                    if (FechaDia != null && FechaSemana == null && FechaMes == null && FechaAño == null)
                    {

                        compras.cancelarCompra(idCompra, cantidadComprada, idProducto);

                        // Consulta los detalles de compra de un producto según un dia especifico.
                        dgvDetalleCompra.DataSource = compras.ConsultarDetalleDiaCompra(nombreProducto, FechaDia ?? DateTime.Now);
                    }



                    // Muestra los detalles de compras de una semana especifica seleccionada en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana != null && FechaMes == null && FechaAño == null)
                    {
                        compras.cancelarCompra(idCompra, cantidadComprada, idProducto);


                        // Consulta los detalles de compra de un producto según una semana especifica. 
                        dgvDetalleCompra.DataSource = compras.ConsultarDetalleSemanaCompra(nombreProducto, FechaSemana ?? DateTime.Now);
                    }



                    //Muestra los detalles de compras de un mes y año especificos seleccionados en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana == null && FechaMes != null && FechaAño != null)
                    {

                        compras.cancelarCompra(idCompra, cantidadComprada, idProducto);


                        // Consulta los detalles de compras de un producto según un mes y año especificos.
                        dgvDetalleCompra.DataSource = compras.ConsultarDetalleMesAñoCompra(nombreProducto, FechaMes ?? 0, FechaAño ?? 0);
                    }


                    //Muesta los detalles de compras de un año especifico seleccionado en el filtro de busqueda.
                    if (FechaDia == null && FechaSemana == null && FechaMes == null && FechaAño != null)
                    {
                        compras.cancelarCompra(idCompra, cantidadComprada, idProducto);

                        // Consulta los detalles de compras de un producto según un mes especifico.
                        dgvDetalleCompra.DataSource = compras.ConsultarDetalleAñoCompra(nombreProducto, FechaAño ?? 0);
                    }

                    // Después de cancelar la compra, disparar el evento y se notifica a frmcompras para que actualice la tabla de compras
                    CompraCancelada?.Invoke();
                }              
            }
        }
    }
}
