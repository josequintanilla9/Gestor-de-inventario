using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaUsuario
{
    public partial class frmVentas : Form
    {
        // VARIABLES(NULEABLES: "?") QUE CONTROLAN LAS FECHAS SELECCIONADAS EN EL FILTRO DE BUSQUEDA.

        DateTime? fechaDia = null; // Controla si se filtra por dia especifico.
        DateTime? fechaSemana = null; // Controla si se filtra por semana especifica.

        // Controla si se filtra por mes y año.
        int? fechaMes = null;
        int? fechaAño = null; // Por si solo, controla si se filtra por año.



        public frmVentas()
        {
            InitializeComponent();
            MostrarVentasSemanaActual(); // Carga inicialmente las ventas de la semana actual
        }



        // METODO PARA CARGAR LAS VENTAS Y TOTAL DE INGRESOS DE LA SEMANA ACTUAL
        public void MostrarVentasSemanaActual()
        {
            VentasNegocio ventas = new VentasNegocio();

            ComprasNegocio compras = new ComprasNegocio();

            try
            {
                DateTime semanaActual = DateTime.Now;

                DataTable dt = ventas.consultarVentasSemana(semanaActual);

                dgvVentas.DataSource = dt;

                // Ocultar la columna de ID
                dgvVentas.Columns["IdProducto"].Visible = false;

                // Cambiar el nombre de la columna "NombreProducto" a "Productos"
                dgvVentas.Columns["NombreProducto"].HeaderText = "Productos";
                dgvVentas.Columns["CantidadVendida"].HeaderText = "Cantidad vendida";
                dgvVentas.Columns["Total"].HeaderText = "Total vendido";



                // Calcular las ventas
                decimal vendido = ventas.consultarIngresosPorSemana(semanaActual);
                lbTotalVendido.Text = vendido.ToString();


                // Calcular los Gastos

                decimal gastado = compras.consultarGastosPorSemana(semanaActual);
                lbTotalGastado.Text = gastado.ToString();

                // Calcular el total de ganancia
                decimal totalGanancia = vendido - gastado;

                if (totalGanancia >= 0)
                {
                    lbGanancias.Text = totalGanancia.ToString();
                }
                else
                {
                    totalGanancia = 0;
                    lbGanancias.Text = totalGanancia.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }



        // EVENTO CELL CLICK DE DATAGRIDVIEW VENTAS: Al seleccionar un campo de la tabla se crea un formulario frmDetalleVenta que muestra los detalles de la venta seleccionada
        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
                if (e.RowIndex >= 0)
                {
                    // Obtener la fila actual seleccionada
                    DataGridViewRow row = dgvVentas.Rows[e.RowIndex];

                    // Asignar los valores de la fila a los controles correspondientes
                    var NombreProducto = row.Cells["NombreProducto"].Value.ToString();

                    if (NombreProducto == null || string.IsNullOrEmpty(NombreProducto.ToString()))
                    {
                        MessageBox.Show("Ocurrio un error al mostrar el detalle de la venta, intentalo de nuevo.");
                        return;
                    }

                    // Crear una instancia del formulario detalles de venta y pasar el nombre del producto
                    frmDetalleVenta frmDetalleVenta = new frmDetalleVenta(NombreProducto, fechaDia, fechaSemana, fechaMes, fechaAño);


                    // CONDICIONALES: Depende el filtro que este activo, se mostraran las compras despues de que en detalle compra alla sido eliminada alguna compra.


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        VentasNegocio ventas = new VentasNegocio();

                        DateTime fecha = DateTime.Now;

                        // Se suscribe al evento VentaCancelada.
                        frmDetalleVenta.VentaCancelada += () =>
                        {
                            dgvVentas.DataSource = ventas.consultarVentasSemana(fecha);


                            // Calcular las ventas
                            decimal vendido = ventas.consultarIngresosPorSemana(fecha);
                            lbTotalVendido.Text = vendido.ToString();


                            // Calcular los Gastos

                            ComprasNegocio compras = new ComprasNegocio();

                            decimal gastado = compras.consultarGastosPorSemana(fecha);
                            lbTotalGastado.Text = gastado.ToString();


                            // Calcular el total de ganancia
                            decimal totalGanancia = vendido - gastado;

                            if (totalGanancia >= 0)
                            {
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                            else
                            {
                                totalGanancia = 0;
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                        };
                    }




                    if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        VentasNegocio  ventas = new VentasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleVenta.VentaCancelada += () =>
                        {

                            dgvVentas.DataSource = ventas.filtrarFecha(fechaDia ?? DateTime.Now);

                            // Calcular las ventas
                            decimal vendido = ventas.consultarIngresosPorDia(fechaDia ?? DateTime.Now);
                            lbTotalVendido.Text = vendido.ToString();


                            // Calcular los Gastos

                            ComprasNegocio compras = new ComprasNegocio();

                            decimal gastado = compras.consultarGastosPorDia(fechaDia ?? DateTime.Now);
                            lbTotalGastado.Text = gastado.ToString();


                            // Calcular el total de ganancia
                            decimal totalGanancia = vendido - gastado;

                            if (totalGanancia >= 0)
                            {
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                            else
                            {
                                totalGanancia = 0;
                                lbGanancias.Text = totalGanancia.ToString();
                            }

                        };

                    }


                    if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                    {
                        VentasNegocio ventas = new VentasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleVenta.VentaCancelada += () =>
                        {
                            dgvVentas.DataSource = ventas.consultarVentasSemana(fechaSemana ?? DateTime.Now);


                            // Calcular las ventas
                            decimal vendido = ventas.consultarIngresosPorSemana(fechaSemana ?? DateTime.Now);
                            lbTotalVendido.Text = vendido.ToString();


                            // Calcular los Gastos

                            ComprasNegocio compras = new ComprasNegocio();

                            decimal gastado = compras.consultarGastosPorSemana(fechaSemana ?? DateTime.Now);
                            lbTotalGastado.Text = gastado.ToString();


                            // Calcular el total de ganancia
                            decimal totalGanancia = vendido - gastado;

                            if (totalGanancia >= 0)
                            {
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                            else
                            {
                                totalGanancia = 0;
                                lbGanancias.Text = totalGanancia.ToString();
                            }

                        };


                    }



                    if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                    {
                        VentasNegocio ventas = new VentasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleVenta.VentaCancelada += () =>
                        {
                            dgvVentas.DataSource = ventas.consultarVentasMesAño(fechaMes ?? 0, fechaAño ?? 0);


                            // Calcular las ventas
                            decimal vendido = ventas.consultarIngresosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
                            lbTotalVendido.Text = vendido.ToString();


                            // Calcular los Gastos

                            ComprasNegocio compras = new ComprasNegocio();

                            decimal gastado = compras.consultarGastosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
                            lbTotalGastado.Text = gastado.ToString();


                            // Calcular el total de ganancia
                            decimal totalGanancia = vendido - gastado;

                            if (totalGanancia >= 0)
                            {
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                            else
                            {
                                totalGanancia = 0;
                                lbGanancias.Text = totalGanancia.ToString();
                            }

                        };
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                    {
                        VentasNegocio ventas = new VentasNegocio();


                        // Se suscribe al evento VentaCancelada.
                        frmDetalleVenta.VentaCancelada += () =>
                        {
                            dgvVentas.DataSource = ventas.consultarVentasAño(fechaAño ?? 0);


                            // Calcular las ventas
                            decimal vendido = ventas.consultarIngresosPorAño(fechaAño ?? 0);
                            lbTotalVendido.Text = vendido.ToString();


                            // Calcular los Gastos

                            ComprasNegocio compras = new ComprasNegocio();

                            decimal gastado = compras.consultarGastosPorAño(fechaAño ?? 0);
                            lbTotalGastado.Text = gastado.ToString();


                            // Calcular el total de ganancia
                            decimal totalGanancia = vendido - gastado;

                            if (totalGanancia >= 0)
                            {
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                            else
                            {
                                totalGanancia = 0;
                                lbGanancias.Text = totalGanancia.ToString();
                            }
                        };
                    }


                    try
                    {
                        // Se muestra el formulario.
                        frmDetalleVenta.ShowDialog();

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











        // BOTON PARA IR A LA SECCION PARA REGISTRAR UNA NUEVA VENTA
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            // Se crea el formulario frmRegistrarVenta
            frmRegistrarVenta frmregistrarventa = new frmRegistrarVenta();

            // Se Suscribe al evento VentaAgregada del formulario frmRegistrarVenta para que cada vez que se agregue una venta la tabla dgvVentas de frmVentas se actualice
            frmregistrarventa.VentaAgregada += () =>
            {
                // Actualiza la tabla a ventas de la semana.
                MostrarVentasSemanaActual();

                // Actualiza el texto del groupbox a "Ventas de la semana".
                gbVentas.Text = "VENTAS DE ESTA SEMANA";

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

            // Se Suscribe al evento VentaCancelada del formulario frmRegistrarVenta para que cada vez que se Cancele una venta la tabla dgvVentas de frmVentas se actualice
            frmregistrarventa.VentaCancelada += () =>
            {
                // Actualiza la tabla a ventas de la semana.
                MostrarVentasSemanaActual();

                // Actualiza el texto del groupbox a "Ventas de la semana".
                gbVentas.Text = "VENTAS DE ESTA SEMANA";

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

            // Despues de suscribirse a los eventos finalmente se muestra el formulario frmregistrarventas
            frmregistrarventa.ShowDialog();
        }





        // BOTON PARA MOSTRAR FORMULARIO "FRMFILTROSVENTAS" CON LAS DIFERENTES OPCIONES PARA FILTRAR LAS VENTAS.
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pbBotonBuscarFecha.BorderStyle = BorderStyle.Fixed3D;

            // Crear instancia del formulario "frmfiltrarventas(formulario secundario).
            frmFiltrosVentas frmfiltrarventas = new frmFiltrosVentas();

            // Suscribirse al evento FiltrarVentas del formulario "frmFiltrosVentas" para recibir el dia especifico para mostrar las ventas en la tabla del formulario "frmVentas".
            frmfiltrarventas.FiltrarDia += new frmFiltrosVentas.FiltrarDiaEventHandler(RecibirFecha);

            // Suscribirse al evento FiltrarSemana del formulario "frmFiltrosVentas" para recibir la semana seleccionada en "frmFiltrosVentas" y mostrar las ventas en esa fecha en la tabla del formulario "frmVentas".
            frmfiltrarventas.FiltrarSemana += new frmFiltrosVentas.FiltrarSemanaEventHandler(RecibirSemana);

            // Suscribirse al evento FiltrarMesAño del formulario "frmFiltrosVentas" para recibir el mes y año seleccionado en "frmFiltrosVentas" para mostrar las ventas en la tabla del formulario "frmVentas".
            frmfiltrarventas.FiltrarMesAño += new frmFiltrosVentas.FiltrarMesAñoEventHandler(RecibirMesAño);

            // Suscribirse al evento FiltrarAño del formulario "frmFiltrosVentas" para recibir el año seleccionado en "frmFiltrosVentas" y mostrar las ventas de ese año en la tabla del formulario "frmVentas".
            frmfiltrarventas.FiltrarAño += new frmFiltrosVentas.FiltrarAñoEventHandler(RecibirAño);

            pbBotonBuscarFecha.BorderStyle = BorderStyle.None;

            // final mente despues de suscribirse a los eventos se muestra el formulario "frmFiltrarVentas".
            frmfiltrarventas.ShowDialog();
        }





        // METODO PARA RECIBIR LA FECHA DEL DIA ESPECIFICO SELECCIONADO EN EL FORMULARIO "FRMFILTROSVENTAS".
        private void RecibirFecha(DateTime fecha)
        {
            VentasNegocio ventas = new VentasNegocio();

            // Se utiliza un metodo del controlador ventas para consultar las ventas del dia seleccionado y mostrarlos en la tabla de ventas.
            dgvVentas.DataSource = ventas.filtrarFecha(fecha);

            // Muestra la fecha del dia que se selecciono en el texto del groupbox
            gbVentas.Text = "VENTAS DEL DÍA:   " + fecha.ToString("D");

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;


            // Aqui se obtiene la fecha del dia seleccionado en los filtros, que sera util para buscar en la barra de busqueda y mostrar los detalles de las ventas al dar clic en la tabla ventas.
            fechaDia = fecha;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = null;



            // Calcular las ventas
            decimal vendido = ventas.consultarIngresosPorDia(fechaDia ?? DateTime.Now);
            lbTotalVendido.Text = vendido.ToString();


            // Calcular los Gastos
            ComprasNegocio compras = new ComprasNegocio();

            decimal gastado = compras.consultarGastosPorDia(fechaDia ?? DateTime.Now);
            lbTotalGastado.Text = gastado.ToString();


            // Calcular el total de ganancia
            decimal totalGanancia = vendido - gastado;

            if (totalGanancia >= 0)
            {
                lbGanancias.Text = totalGanancia.ToString();
            }
            else
            {
                totalGanancia = 0;
                lbGanancias.Text = totalGanancia.ToString();
            }

        }



        // METODO PARA RECIBIR LA SEMANA SELECCIONADA DE UN DATETIMEPICKER DEL FORMULARIO "FRMFILTROSVENTAS".
        public void RecibirSemana(DateTime fecha)
        {
            // Se crea un objeto del ventas 
            VentasNegocio ventas = new VentasNegocio();

            // Se utiliza un metodo del controlador ventas para consultar las ventas de la semana seleccionada y mostrarlos en la tabla de ventas.
            dgvVentas.DataSource = ventas.consultarVentasSemana(fecha);

            // Muestra la semana de las ventas que se selecciono, en el texto del groupbox
            gbVentas.Text = "VENTAS DE LA SEMANA DEL:   " + fecha.ToString("D");

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;

            // Aqui se obtiene la fecha de la semana seleccionada en los filtros que sera util para buscar en la barra de busqueda y mostrar los detalles de las ventas al dar clic en la tabla ventas.
            fechaDia = null;
            fechaSemana = fecha;
            fechaMes = null;
            fechaAño = null;



            // Calcular las ventas
            decimal vendido = ventas.consultarIngresosPorSemana(fechaSemana ?? DateTime.Now);
            lbTotalVendido.Text = vendido.ToString();


            // Calcular los Gastos
            ComprasNegocio compras = new ComprasNegocio();

            decimal gastado = compras.consultarGastosPorSemana(fechaSemana ?? DateTime.Now);
            lbTotalGastado.Text = gastado.ToString();


            // Calcular el total de ganancia
            decimal totalGanancia = vendido - gastado;

            if (totalGanancia >= 0)
            {
                lbGanancias.Text = totalGanancia.ToString();
            }
            else
            {
                totalGanancia = 0;
                lbGanancias.Text = totalGanancia.ToString();
            }

        }



        //  METODO PARA RECIBIR EL MES Y EL AÑO SELECCIONADOS EN EL FORMULARIO "FRMFILTROSVENTAS".
        private void RecibirMesAño(int mes, int año)
        {
            // Se crea un objeto del  ventas 
            VentasNegocio ventas = new VentasNegocio();

            // Se utiliza un metodo del controlador ventas para consultar las ventas del mes y año seleccionado y mostrarlos en la tabla de ventas.
            dgvVentas.DataSource = ventas.consultarVentasMesAño(mes, año);

            // Muestra el mes y el año de las ventas que se selecciono, en el texto del groupbox
            gbVentas.Text = "VENTAS DEL MES:   " + mes + " del año " + año;

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;


            // Aqui se obtiene la fecha del mes y año seleccionado en los filtros que sera util para buscar en la barra de busqueda y mostrar los detalles de las ventas al dar clic en la tabla ventas.
            fechaDia = null;
            fechaSemana = null;
            fechaMes = mes;
            fechaAño = año;


            // Calcular las ventas
            decimal vendido = ventas.consultarIngresosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
            lbTotalVendido.Text = vendido.ToString();


            // Calcular los Gastos
            ComprasNegocio compras = new ComprasNegocio();

            decimal gastado = compras.consultarGastosPorMesAño(fechaMes ?? 0, fechaAño ?? 0);
            lbTotalGastado.Text = gastado.ToString();


            // Calcular el total de ganancia
            decimal totalGanancia = vendido - gastado;

            if (totalGanancia >= 0)
            {
                lbGanancias.Text = totalGanancia.ToString();
            }
            else
            {
                totalGanancia = 0;
                lbGanancias.Text = totalGanancia.ToString();
            }
        }




        // METODO PARA RECIBIR EL AÑO DE UN DATETIMEPICKER DE FORMULARIO FRMFILTROSVENTAS Y FILTRAR LAS VENTAS POR AÑO
        public void RecibirAño(int año)
        {
            // Se crea un objeto ventas 
            VentasNegocio ventas = new VentasNegocio();

            // Se utiliza un metodo del controlador ventas para consultar las ventas del año seleccionado y mostrarlos en la tabla de ventas.
            dgvVentas.DataSource = ventas.consultarVentasAño(año);

            // Muestra el año de las ventas que se selecciono, en el texto del groupbox
            gbVentas.Text = "VENTAS DEL AÑO:   " + año;

            pbBotonBuscarFecha.Visible = false;
            pbBotonBuscarFecha.Enabled = false;
            lbCambiarFecha.Visible = false;

            pbBotonRestablecerFecha.BringToFront();
            pbBotonRestablecerFecha.Enabled = true;
            pbBotonRestablecerFecha.Visible = true;
            lbRestablecerFecha.Visible = true;


            // Aqui se obtiene el año seleccionado en los filtros que sera util para buscar en la barra de busqueda y mostrar los detalles de las ventas al dar clic en la tabla ventas.
            fechaDia = null;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = año;




            // Calcular las ventas
            decimal vendido = ventas.consultarIngresosPorAño(fechaAño ?? 0);
            lbTotalVendido.Text = vendido.ToString();


            // Calcular los Gastos
            ComprasNegocio compras = new ComprasNegocio();

            decimal gastado = compras.consultarGastosPorAño(fechaAño ?? 0);
            lbTotalGastado.Text = gastado.ToString();


            // Calcular el total de ganancia
            decimal totalGanancia = vendido - gastado;

            if (totalGanancia >= 0)
            {
                lbGanancias.Text = totalGanancia.ToString();
            }
            else
            {
                totalGanancia = 0;
                lbGanancias.Text = totalGanancia.ToString();
            }
        }







        // EVENTO KEY DOWN DE TEXTBOX BUSCAR PRODUCTO: AL PRESIONAR ENTER EN EL TEXTBOX BUSCAR PRODUCTO BUSCARA EL PRODUCTO SIN NECESIDAD DEL BOTON.
        private void tbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VentasNegocio ventas = new VentasNegocio();

                string dato = tbBuscarProducto.Text;

                DataTable dt;

                // CONDICIONALES: Depende el filtro que este activo, se mostraran las ventas despues de que en detalle venta alla sido eliminada alguna venta.

                if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;
                    DateTime fecha = DateTime.Now;

                    dt = ventas.buscarVentasSemana(dato, fecha);

                    dgvVentas.DataSource = dt;
                }


                if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = ventas.buscarVentasDia(dato, fechaDia ?? DateTime.Now);

                    dgvVentas.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = ventas.buscarVentasSemana(dato, fechaSemana ?? DateTime.Now);

                    dgvVentas.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = ventas.buscarVentasMesAño(dato, fechaMes ?? 0, fechaAño ?? 0);

                    dgvVentas.DataSource = dt;
                }


                if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                {
                    string NombreProducto = tbBuscarProducto.Text;

                    dt = ventas.buscarVentasAño(dato, fechaAño ?? 0);

                    dgvVentas.DataSource = dt;
                }

                pbBotonQuitarBusqueda.Visible = true;
                pbBotonQuitarBusqueda.Enabled = true;
                lbQuirarBusqueda.Visible = true;

                tbBuscarProducto.Text = "";

                e.SuppressKeyPress = true;
            }
        }








        // BOTON PARA RESTABLECER TODOS LOS FILTROS Y QUE TODO ESTE POR DEFECTO
        private void pbBotonRestablecerFecha_Click(object sender, EventArgs e)
        {
            pbBotonRestablecerFecha.BorderStyle = BorderStyle.Fixed3D;

            fechaDia = null;
            fechaSemana = null;
            fechaMes = null;
            fechaAño = null;

            MostrarVentasSemanaActual();

            gbVentas.Text = "VENTAS DE ESTA SEMANA";

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






        //BOTON PARA QUITAR FILTRO DE BUSQUEDA
        private void pbBotonQuitarBusqueda_Click(object sender, EventArgs e)
        {
            VentasNegocio ventas = new VentasNegocio();

            // CONDICIONALES: Depende el filtro que este activo, se mostraran las ventas despues de que en detalle venta alla sido eliminada alguna venta.

            if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
            {
                DateTime fecha = DateTime.Now;

                dgvVentas.DataSource = ventas.consultarVentasSemana(fecha);
            }


            if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
            {
                dgvVentas.DataSource = ventas.filtrarFecha(fechaDia ?? DateTime.Now);
            }


            if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
            {
                dgvVentas.DataSource = ventas.consultarVentasSemana(fechaDia ?? DateTime.Now);
            }


            if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
            {
                dgvVentas.DataSource = ventas.consultarVentasMesAño(fechaMes ?? 0, fechaAño ?? 0);
            }


            if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
            {
                dgvVentas.DataSource = ventas.consultarVentasAño(fechaAño ?? 0);
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
                    for (int i = 0; i < dgvVentas.Columns.Count; i++)
                    {
                        if (dgvVentas.Columns[i].Visible) // Verificar si la columna es visible
                        {
                            var cell = worksheet.Cell(1, colIndex);
                            cell.Value = dgvVentas.Columns[i].HeaderText;
                            cell.Style.Font.Bold = true; // Negrita
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray; // Color de fondo
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Alinear al centro
                            colIndex++;
                        }

                    }

                    // Agregar los datos del DataGridView
                    for (int i = 0; i < dgvVentas.Rows.Count; i++)
                    {
                        colIndex = 1; // Reiniciar el índice de columna para cada fila
                        for (int j = 0; j < dgvVentas.Columns.Count; j++)
                        {
                            if (dgvVentas.Columns[j].Visible) // Verificar si la columna es visible
                            {
                                worksheet.Cell(i + 2, colIndex).Value = dgvVentas.Rows[i].Cells[j].Value?.ToString();
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
                    int rowCount = dgvVentas.Rows.Count + 3;


                    var totalVentasCell = worksheet.Cell(rowCount + 1, 1);
                    totalVentasCell.Value = "Total Ventas:";
                    totalVentasCell.Style.Font.Bold = true; // Negrita
                    totalVentasCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo verde suave
                    worksheet.Cell(rowCount + 2, 1).Value = lbTotalVendido.Text;

                    var totalGastosCell = worksheet.Cell(rowCount + 1, 2);
                    totalGastosCell.Value = "Total Gastos:";
                    totalGastosCell.Style.Font.Bold = true; // Negrita
                    totalGastosCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo rojo suave
                    worksheet.Cell(rowCount + 2, 2).Value = lbTotalGastado.Text;

                    // Agregar Total Ganancias
                    var totalGananciasCell = worksheet.Cell(rowCount + 1, 3);
                    totalGananciasCell.Value = "Total Ganancias:";
                    totalGananciasCell.Style.Font.Bold = true; // Negrita
                    totalGananciasCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo amarillo suave
                    worksheet.Cell(rowCount + 2, 3).Value = lbGanancias.Text;

                    // Agregar la fecha
                    var fechaCell = worksheet.Cell(rowCount + 1, 4);
                    fechaCell.Value = "Fecha:";
                    fechaCell.Style.Font.Bold = true; // Negrita
                    fechaCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo amarillo suave


                    // CONDICIONALES: Depende el filtro que este activo, se mostrara esa fecha en el reporte de excel.

                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        DateTime fecha = DateTime.Now;

                        worksheet.Cell(rowCount + 2, 4).Value = "La semana del: " + fecha.ToString("D");
                    }


                    if (fechaDia != null && fechaSemana == null && fechaMes == null && fechaAño == null)
                    {
                        worksheet.Cell(rowCount + 2, 4).Value = fechaDia.Value.ToString("D");
                    }


                    if (fechaDia == null && fechaSemana != null && fechaMes == null && fechaAño == null)
                    {
                        worksheet.Cell(rowCount + 2, 4).Value = "La semana del: " + fechaSemana.Value.ToString("D");
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes != null && fechaAño != null)
                    {
                        worksheet.Cell(rowCount + 2, 4).Value = "El mes: " + fechaMes + " del año " + fechaAño;
                    }


                    if (fechaDia == null && fechaSemana == null && fechaMes == null && fechaAño != null)
                    {
                        worksheet.Cell(rowCount + 2, 4).Value = "Año: " + fechaAño;
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
