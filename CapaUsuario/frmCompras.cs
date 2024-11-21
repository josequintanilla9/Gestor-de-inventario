using CapaNegocio;
using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace CapaUsuario
{
    public partial class frmCompras : Form
    {

        // VARIABLES(NULEABLES: "?") QUE CONTROLAN LAS FECHAS SELECCIONADAS EN EL FILTRO DE BUSQUEDA.

        DateTime? fechaDia = null; // Controla si se filtra por dia especifico.
        DateTime? fechaSemana = null; // Controla si se filtra por semana especifica.

        // Controla si se filtra por mes y año.
        int? fechaMes = null;
        int? fechaAño = null; // Por si solo, controla si se filtra por año.


        public frmCompras()
        {
            InitializeComponent();
            MostrarComprasSemanaActual(); // Carga inicialmente todos los datos de la bd en la tabla
        }




        // METODO PARA CARGAR LAS COMPRAS DE LA SEMANA ACTUAL
        public void MostrarComprasSemanaActual()
        {
            ComprasNegocio compras = new ComprasNegocio();

            try
            {
                DateTime semanaActual = DateTime.Now;

                DataTable dt = compras.consultarComprasSemana(semanaActual);

                dgvCompras.DataSource = dt;

                // Ocultar la columna de ID
                dgvCompras.Columns["IdProducto"].Visible = false;

                // Cambiar el nombre de la columna "NombreProducto" a "Productos"
                dgvCompras.Columns["NombreProducto"].HeaderText = "Productos";
                dgvCompras.Columns["CantidadComprada"].HeaderText = "Cantidad comprada";
                dgvCompras.Columns["Total"].HeaderText = "Total comprado";



                // Calcular los Gastos
                decimal gastado = compras.consultarGastosPorSemana(semanaActual);
                lbTotalGastado.Text = gastado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        // EVENTO CELL CLICK DE DATAGRIDVIEW COMPRAS: Al seleccionar un campo de la tabla se muestran los detalles de la compra
        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
                if (e.RowIndex >= 0)
                {
                    // Obtener la fila actual seleccionada
                    DataGridViewRow row = dgvCompras.Rows[e.RowIndex];

                    // Asignar los valores de la fila a los controles correspondientes
                    var NombreProducto = row.Cells["NombreProducto"].Value.ToString();

                    if (NombreProducto == null || string.IsNullOrEmpty(NombreProducto.ToString()))
                    {
                        MessageBox.Show("Ocurrio un error al mostrar el detalle de la compra, intentalo de nuevo.");
                        return;
                    }

                    // Crear una instancia del formulario detalles de venta y pasar el nombre del producto
                    frmDetalleCompra frmDetalleCompra = new frmDetalleCompra(NombreProducto, fechaDia, fechaSemana, fechaMes, fechaAño);


                    // CONDICIONALES: Depende el filtro que este activo, se mostraran las compras despues de que en detalle compra alla sido eliminada alguna compra.


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        ComprasNegocio compras = new ComprasNegocio();

                        DateTime fecha = DateTime.Now;

                        // Se suscribe al evento VentaCancelada.
                        frmDetalleCompra.CompraCancelada += () =>
                        {
                            dgvCompras.DataSource = compras.consultarComprasSemana(fecha);

                            // Calcular los Gastos

                            decimal gastado = compras.consultarGastosPorSemana(fecha);
                            lbTotalGastado.Text = gastado.ToString();
                        };
                    }




                    if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        ComprasNegocio compras = new ComprasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleCompra.CompraCancelada += () =>
                        {

                            dgvCompras.DataSource = compras.filtrarFecha(fechaDia ?? DateTime.Now);

                            // Calcular los Gastos
                            decimal gastado = compras.consultarGastosPorDia(fechaDia ?? DateTime.Now);
                            lbTotalGastado.Text = gastado.ToString();

                        };

                    }


                    if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                    {
                        ComprasNegocio compras = new ComprasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleCompra.CompraCancelada += () =>
                        {
                            dgvCompras.DataSource = compras.consultarComprasSemana(fechaSemana ?? DateTime.Now);


                            // Calcular los Gastos

                            decimal gastado = compras.consultarGastosPorSemana(fechaSemana ?? DateTime.Now);
                            lbTotalGastado.Text = gastado.ToString();

                        };


                    }



                    if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                    {
                        ComprasNegocio compras = new ComprasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleCompra.CompraCancelada += () =>
                        {
                            dgvCompras.DataSource = compras.consultarComprasMesAño(fechaMes ?? 0, fechaAño ?? 0);


                            // Calcular los Gastos

                            decimal gastado = compras.consultarGastosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
                            lbTotalGastado.Text = gastado.ToString();

                        };
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                    {
                        ComprasNegocio compras = new ComprasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleCompra.CompraCancelada += () =>
                        {
                            dgvCompras.DataSource = compras.consultarComprasAño(fechaAño ?? 0);

                            // Calcular los Gastos

                            decimal gastado = compras.consultarGastosPorAño(fechaAño ?? 0);
                            lbTotalGastado.Text = gastado.ToString();
                        };
                    }


                    try
                    {
                        // Se muestra el formulario.
                        frmDetalleCompra.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al mostrar el formulario de detalle: {ex.Message}");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar los detalles: {ex.Message}");
            }
        }







        // BOTON PARA DIRIGIRSE A LA SECCION PARA REGISTRAR UNA NUEVA COMPRA
        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            // Se crea el formulario frmRegistrarCompra.
            frmRegistrarCompra frmregistrarcompra = new frmRegistrarCompra();


            // Se Suscribe al evento CompraAgregada del formulario frmRegistrarCompra para que cada vez que se agregue una compra la tabla dgvCompras de frmCompras se actualice
            frmregistrarcompra.CompraAgregada += () =>
            {
                // Actualiza la tabla a ventas de la semana.
                MostrarComprasSemanaActual();

                // Actualiza el texto del groupbox a "Ventas de la semana".
                gbCompras.Text = "COMPRAS DE ESTA SEMANA";

                // Restablece el filtro de ventas
                fechaDia = null;
                fechaSemana = null;
                fechaMes = null;
                fechaAño = null;

                pbBotonRestablecerFecha.Visible = false;
                pbBotonRestablecerFecha.Enabled = false;
                pbBotonRestablecerFecha.Visible = false;
                lbRestablecerFecha.Visible = false;


                pbBotonBuscarFecha.BringToFront();
                pbBotonBuscarFecha.Visible = true;
                pbBotonBuscarFecha.Enabled = true;
                lbCambiarFecha.Visible = true;
            };

            // Se Suscribe al evento CompraCancelada del formulario frmRegistrarCompra para que cada vez que se Cancele una compra la tabla dgvCompras de frmCompras se actualice
            frmregistrarcompra.CompraCancelada += () =>
            {
                // Actualiza la tabla a ventas de la semana.
                MostrarComprasSemanaActual();

                // Actualiza el texto del groupbox a "Ventas de la semana".
                gbCompras.Text = "COMPRAS DE ESTA SEMANA";

                // Restablece el filtro de ventas
                fechaDia = null;
                fechaSemana = null;
                fechaMes = null;
                fechaAño = null;

                pbBotonRestablecerFecha.Visible = false;
                pbBotonRestablecerFecha.Enabled = false;
                pbBotonRestablecerFecha.Visible = false;
                lbRestablecerFecha.Visible = false;


                pbBotonBuscarFecha.BringToFront();
                pbBotonBuscarFecha.Visible = true;
                pbBotonBuscarFecha.Enabled = true;
                lbCambiarFecha.Visible = true;
            };

            // Despues de suscribirse a los eventos finalmente se muestra el formulario frmregistrarcompras
            frmregistrarcompra.ShowDialog();
        }





        // BOTON PARA MOSTRAR FORMULARIO "FRMFILTROSCOMPRAS" CON LAS DIFERENTES OPCIONES PARA FILTRAR LAS COMPRAS.
        private void pbBotonBuscarFecha_Click(object sender, EventArgs e)
        {
            pbBotonBuscarFecha.BorderStyle = BorderStyle.Fixed3D;

            // Crear instancia del formulario "frmfiltrarcompras(formulario secundario).
            frmFiltrosCompras frmfiltrarcompras = new frmFiltrosCompras();

            // Suscribirse al evento FiltrarCompras del formulario "frmFiltrosCompras" para recibir el dia especifico para mostrar las compras en la tabla del formulario "frmCompras".
            frmfiltrarcompras.FiltrarDia += new frmFiltrosCompras.FiltrarDiaEventHandler(RecibirFecha);

            // Suscribirse al evento FiltrarSemana del formulario "frmFiltrosCompras" para recibir la semana seleccionada en "frmFiltrosCompras" y mostrar las ventas en esa fecha en la tabla del formulario "frmCompras".
            frmfiltrarcompras.FiltrarSemana += new frmFiltrosCompras.FiltrarSemanaEventHandler(RecibirSemana);

            // Suscribirse al evento FiltrarMesAño del formulario "frmFiltrosCompras" para recibir el mes y año seleccionado en "frmFiltrosCompras" para mostrar las ventas en la tabla del formulario "frmCompras".
            frmfiltrarcompras.FiltrarMesAño += new frmFiltrosCompras.FiltrarMesAñoEventHandler(RecibirMesAño);

            // Suscribirse al evento FiltrarAño del formulario "frmFiltrosCompras" para recibir el año seleccionado en "frmFiltrosCompras" y mostrar las ventas de ese año en la tabla del formulario "frmCompras".
            frmfiltrarcompras.FiltrarAño += new frmFiltrosCompras.FiltrarAñoEventHandler(RecibirAño);

            pbBotonBuscarFecha.BorderStyle = BorderStyle.None;

            // final mente despues de suscribirse a los eventos se muestra el formulario "frmFiltrarCompras".
            frmfiltrarcompras.ShowDialog();
        }





        // METODO PARA RECIBIR LA FECHA DEL DIA ESPECIFICO SELECCIONADO EN EL FORMULARIO "FRMFILTROSCOMPRAS".
        private void RecibirFecha(DateTime fecha)
        {
            ComprasNegocio compras = new ComprasNegocio();

            // Se utiliza un metodo del controlador compras para consultar las compras del dia seleccionado y mostrarlos en la tabla de compras.
            dgvCompras.DataSource = compras.filtrarFecha(fecha);

            // Muestra la fecha del dia que se selecciono en el texto del groupbox
            gbCompras.Text = "COMPRAS DEL DÍA:   " + fecha.ToString("D");


            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;

            // Aqui se obtiene la fecha del dia seleccionado en los filtros, que sera util para buscar en la barra de busqueda y mostrar los detalles de las compras al dar clic en la tabla compras.
            fechaDia = fecha;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = null;


            // Calcular los Gastos.

            decimal gastado = compras.consultarGastosPorDia(fechaDia ?? DateTime.Now);
            lbTotalGastado.Text = gastado.ToString();

        }



        // METODO PARA RECIBIR LA SEMANA SELECCIONADA DE UN DATETIMEPICKER DEL FORMULARIO "FRMFILTROSCOMPRAS".
        public void RecibirSemana(DateTime fecha)
        {
            ComprasNegocio compras = new ComprasNegocio();

            // Se utiliza un metodo del controlador compras para consultar las compras de la semana seleccionada y mostrarlos en la tabla de compras.
            dgvCompras.DataSource = compras.consultarComprasSemana(fecha);

            // Muestra la semana de las ventas que se selecciono, en el texto del groupbox
            gbCompras.Text = "COMPRAS DE LA SEMANA DEL:   " + fecha.ToString("D");


            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;


            // Aqui se obtiene la fecha de la semana seleccionada en los filtros, que sera util para buscar en la barra de busqueda y mostrar los detalles de las compras al dar clic en la tabla compras.
            fechaDia = null;
            fechaSemana = fecha;
            fechaMes = null;
            fechaAño = null;

            // Calcular los Gastos

            decimal gastado = compras.consultarGastosPorSemana(fechaSemana ?? DateTime.Now);
            lbTotalGastado.Text = gastado.ToString();
        }



        //  METODO PARA RECIBIR EL MES Y EL AÑO SELECCIONADOS EN EL FORMULARIO "FRMFILTROSCOMPRASS".
        private void RecibirMesAño(int mes, int año)
        {
            ComprasNegocio compras = new ComprasNegocio();

            // Se utiliza un metodo del controlador compras para consultar las compras del mes y año seleccionado y mostrarlos en la tabla de compras.
            dgvCompras.DataSource = compras.consultarComprasMesAño(mes, año);

            // Muestra el mes y el año de las ventas que se selecciono, en el texto del groupbox
            gbCompras.Text = "COMPRAS DEL MES:   " + mes + " del año " + año;

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;


            // Aqui se obtiene la fecha del mes y año seleccionado en los filtros, que sera util para buscar en la barra de busqueda y mostrar los detalles de las compras al dar clic en la tabla compras.
            fechaDia = null;
            fechaSemana = null;
            fechaMes = mes;
            fechaAño = año;

            // Calcular los Gastos

            decimal gastado = compras.consultarGastosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
            lbTotalGastado.Text = gastado.ToString();

        }



        // METODO PARA RECIBIR EL AÑO DE UN DATETIMEPICKER DE FORMULARIO FRMFILTROSCOMPRAS Y FILTRAR LAS COMPRAS POR AÑO
        public void RecibirAño(int año)
        {
            ComprasNegocio compras = new ComprasNegocio();

            // Se utiliza un metodo del controlador compras para consultar las compras del año seleccionado y mostrarlos en la tabla de compras.
            dgvCompras.DataSource = compras.consultarComprasAño(año);

            // Muestra el año de las compras que se selecciono, en el texto del groupbox
            gbCompras.Text = "COMPRAS DEL AÑO:   " + año;

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;



            // Aqui se obtiene el año seleccionado en los filtros, que sera util para buscar en la barra de busqueda y mostrar los detalles de las compras al dar clic en la tabla compras.
            fechaDia = null;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = año;

            // Calcular los Gastos

            decimal gastado = compras.consultarGastosPorAño(fechaAño ?? 0);
            lbTotalGastado.Text = gastado.ToString();

        }



        // EVENTO KEY DOWN DE TEXTBOX BUSCAR PRODUCTO: AL PRESIONAR ENTER EN EL TEXTBOX BUSCAR PRODUCTO BUSCARA EL PRODUCTO SIN NECESIDAD DEL BOTON.
        private void tbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComprasNegocio compras = new ComprasNegocio();

                string dato = tbBuscarProducto.Text;

                DataTable dt;

                // CONDICIONALES: Depende el filtro que este activo, se mostraran las ventas despues de que en detalle venta alla sido eliminada alguna venta.

                if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;
                    DateTime fecha = DateTime.Now;

                    dt = compras.buscarComprasSemana(dato, fecha);

                    dgvCompras.DataSource = dt;
                }


                if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = compras.buscarComprasDia(dato, fechaDia ?? DateTime.Now);

                    dgvCompras.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = compras.buscarComprasSemana(dato, fechaSemana ?? DateTime.Now);

                    dgvCompras.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = compras.buscarComprasMesAño(dato, fechaMes ?? 0, fechaAño ?? 0);

                    dgvCompras.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = compras.buscarComprasAño(dato, fechaAño ?? 0);

                    dgvCompras.DataSource = dt;
                }

                pbBotonQuitarBusqueda.Visible = true;
                pbBotonQuitarBusqueda.Enabled = true;
                lbQuirarBusqueda.Visible = true;

                tbBuscarProducto.Text = "";

                e.SuppressKeyPress = true;
            }

        }



        //BOTON PARA QUITAR FILTRO DE BUSQUEDA
        private void pbBotonRestablecerFecha_Click(object sender, EventArgs e)
        {
            pbBotonRestablecerFecha.BorderStyle = BorderStyle.Fixed3D;

            fechaDia = null;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = null;

            MostrarComprasSemanaActual();

            gbCompras.Text = "COMPRAS DE ESTA SEMANA";

            pbBotonRestablecerFecha.Visible = false;
            pbBotonRestablecerFecha.Enabled = false;
            pbBotonRestablecerFecha.Visible = false;
            lbRestablecerFecha.Visible = false;


            pbBotonBuscarFecha.BringToFront();
            pbBotonBuscarFecha.Visible = true;
            pbBotonBuscarFecha.Enabled = true;
            lbCambiarFecha.Visible = true;

            pbBotonRestablecerFecha.BorderStyle = BorderStyle.None;
        }





        // BOTON PARA QUITAR LOS RESULTADOS DE BUSQUEDA
        private void pbBotonQuitarBusqueda_Click(object sender, EventArgs e)
        {
            ComprasNegocio compras = new ComprasNegocio();


            // CONDICIONALES: Depende el filtro que este activo, se mostraran las ventas despues de que en detalle venta alla sido eliminada alguna venta.

            if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
            {
                DateTime fecha = DateTime.Now;

                dgvCompras.DataSource = compras.consultarComprasSemana(fecha);
            }


            if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
            {
                dgvCompras.DataSource = compras.filtrarFecha(fechaDia ?? DateTime.Now);
            }


            if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
            {
                dgvCompras.DataSource = compras.consultarComprasSemana(fechaDia ?? DateTime.Now);
            }


            if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
            {
                dgvCompras.DataSource = compras.consultarComprasMesAño(fechaMes ?? 0, fechaAño ?? 0);
            }


            if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
            {
                dgvCompras.DataSource = compras.consultarComprasAño(fechaAño ?? 0);
            }


            tbBuscarProducto.Text = "";

            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Enabled = false;
            lbQuirarBusqueda.Visible = false;
        }




        // BOTON PARA EXPORTAR EL REGISTRO DE LAS VENTAS A UN EXCEL
        private void pbBotonExcel_Click(object sender, EventArgs e)
        {
            try
            {
                pbBotonExcel.BorderStyle = BorderStyle.Fixed3D;

                // Crear un nuevo libro de Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Datos");

                    // Agregar encabezados del DataGridView
                    int colIndex = 1;
                    for (int i = 0; i < dgvCompras.Columns.Count; i++)
                    {
                        if (dgvCompras.Columns[i].Visible) // Verificar si la columna es visible
                        {
                            var cell = worksheet.Cell(1, colIndex);
                            cell.Value = dgvCompras.Columns[i].HeaderText;
                            cell.Style.Font.Bold = true; // Negrita
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray; // Color de fondo
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Alinear al centro
                            colIndex++;
                        }

                    }

                    // Agregar los datos del DataGridView
                    for (int i = 0; i < dgvCompras.Rows.Count; i++)
                    {
                        colIndex = 1; // Reiniciar el índice de columna para cada fila
                        for (int j = 0; j < dgvCompras.Columns.Count; j++)
                        {
                            if (dgvCompras.Columns[j].Visible) // Verificar si la columna es visible
                            {
                                worksheet.Cell(i + 2, colIndex).Value = dgvCompras.Rows[i].Cells[j].Value?.ToString();
                                colIndex++;

                            }
                        }
                    }

                    // Ajustar el ancho de las columnas
                    for (int i = 1; i <= colIndex - 1; i++)
                    {
                        worksheet.Column(i).AdjustToContents(); // Ajustar automáticamente al contenido
                    }



                    // Agregar totales debajo de los datos
                    int rowCount = dgvCompras.Rows.Count + 3;


                    var totalComprasCell = worksheet.Cell(rowCount + 1, 1);
                    totalComprasCell.Value = "Total Gastos:";
                    totalComprasCell.Style.Font.Bold = true; // Negrita
                    totalComprasCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo
                    worksheet.Cell(rowCount + 2, 1).Value = lbTotalGastado.Text;


                    // Agregar la fecha
                    var fechaCell = worksheet.Cell(rowCount + 1, 2);
                    fechaCell.Value = "Fecha:";
                    fechaCell.Style.Font.Bold = true; // Negrita
                    fechaCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo


                    // CONDICIONALES: Depende el filtro que este activo, se mostrara esa fecha en el reporte de excel.

                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        DateTime fecha = DateTime.Now;

                        worksheet.Cell(rowCount + 2, 2).Value = "La semana del: " + fecha.ToString("D");
                    }


                    if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        worksheet.Cell(rowCount + 2, 2).Value = fechaDia.Value.ToString("D");
                    }


                    if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                    {
                        worksheet.Cell(rowCount + 2, 2).Value = "La semana del: " + fechaSemana.Value.ToString("D");
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                    {
                        worksheet.Cell(rowCount + 2, 2).Value = "El mes: " + fechaMes + " del año " + fechaAño;
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                    {
                        worksheet.Cell(rowCount + 2, 2).Value = "Año: " + fechaAño;
                    }



                    // Ajustar el ancho de todas las columnas
                    worksheet.Columns().AdjustToContents();

                    pbBotonExcel.BorderStyle = BorderStyle.None;

                    // Guardar el archivo
                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Guardar archivo Excel",
                        FileName = "DatosExportados.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Exportación completada con éxito.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}");
            }
        }
    }
}
