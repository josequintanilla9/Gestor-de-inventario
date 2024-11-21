using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class VentasNegocio
    {
        // METODO PARA REGISTRAR UNA NUEVA VENTA
        public bool registrarVenta(int idProducto, decimal precio, int cantidad, DateTime fecha, out string mensaje)
        {
            bool registrado = false;

            mensaje = "";

            ProductosNegocio productos = new ProductosNegocio();

            // Consultamos las existencias del producto
            int existencias = productos.consultarExistencias(idProducto);

            try
            {
                if (cantidad <= existencias)
                {

                    
                    VentasDatos ventas = new VentasDatos();

                    decimal total = cantidad * precio;

                    // Metodo para guardar la compra
                    registrado = ventas.registrarVenta(idProducto, precio, cantidad, total, fecha);

                    if (registrado)
                    {
                        

                        // Actualizar las existencias del producto
                        int existenciaActualizada = existencias - cantidad;

                        productos.actualizarExistencias(idProducto, existenciaActualizada);
                    }
                }
                else
                {
                    mensaje = "No hay suficiente producto disponible para esta venta.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

            return registrado;
        }



        // METODO PARA CANCELAR UNA VENTA
        public bool cancelarVenta(int idVenta, int cantidad, int idProducto)
        {
            bool cancelado = false;

            VentasDatos ventas = new VentasDatos();

            try
            {
                // Se cancela la compra
                cancelado = ventas.cancelarVenta(idVenta);

                if (cancelado)
                {

                    ProductosNegocio productos = new ProductosNegocio();

                    // Consultamos las existencias del producto
                    int existencias = productos.consultarExistencias(idProducto);


                    // Actualizar las existencias del producto

                    int existenciaActualizada = existencias + cantidad; // Se eliminan los productos de esa compra del inventario

                    productos.actualizarExistencias(idProducto, existenciaActualizada);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

            return cancelado;
        }


        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL DIA.
        public DataTable buscarVentasDia(string NombreProducto, DateTime Fecha)
        {


            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.buscarVentasDia(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }



        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO LA SEMANA.
        public DataTable buscarVentasSemana(string NombreProducto, DateTime Fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.buscarVentasSemana(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }

        }





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL MES Y AÑO.
        public DataTable buscarVentasMesAño(string NombreProducto, int mes, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.buscarVentasMesAño(NombreProducto, mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL AÑO.
        public DataTable buscarVentasAño(string NombreProducto, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.buscarVentasAño(NombreProducto, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }



        // METODO PARA MOSTRAR LAS VENTAS DEL DIA ACTUAL - ("FORMULARIO DE REGISTRAR VENTAS").
        public DataTable ConsultarVentas()
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.ConsultarVentas();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA CARGAR PRODUCTOS EN UN COMBOBOX - ("FORMULARIO DE REGISTRAR VENTAS").
        public DataTable consultarProductos()
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.consultarProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        //METODO PARA MOSTRAR EL PRECIO DE UN PRODUCTOS
        public decimal ConsultarPrecioProducto(int id)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                decimal precioProducto = ventas.ConsultarPrecioProducto(id);

                return precioProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }








        // ------------------- FILTROS DE BUSQUEDA DE COMPRAS PARA FORMULARIO COMPRAS -------------------




        // METODO PARA BUSCAR VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO EL DIA QUE SE QUIERA CONSULTAR
        public DataTable filtrarFecha(DateTime fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.filtrarFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO LA SEMANA QUE SE QUIERA CONSULTAR
        public DataTable consultarVentasSemana(DateTime fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.consultarVentasSemana(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }



        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO, SELECCIONANDO EL MES Y EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarVentasMesAño(int mes, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.consultarVentasMesAño(mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA MOSTRAR LAS VENTAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONADO EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarVentasAño(int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.consultarVentasAño(año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }






        // ------------------- DETALLES DE LAS COMPRAS -------------------








        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y EL DIA ESPECIFICIO
        public DataTable ConsultarDetalleDiaVenta(string NombreProducto, DateTime Fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.ConsultarDetalleDiaVenta(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y LA SEMANA ESPECIFICIA
        public DataTable ConsultarDetalleSemanaVenta(string NombreProducto, DateTime Fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.ConsultarDetalleSemanaVenta(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO, EL MES Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleMesAñoVenta(string NombreProducto, int mes, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.ConsultarDetalleMesAñoVenta(NombreProducto, mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA VENTA SEGUN EL NOMBRE DEL PRODUCTO Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleAñoVenta(string NombreProducto, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                return ventas.ConsultarDetalleAñoVenta(NombreProducto, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // ------------------- METODOS PARA CONSULTAR LOS GASTOS OBTENIDOS -------------------







        // METODO PARA CONSULTAR LOS INGRESOS POR DIA ESPECIFICO
        public decimal consultarIngresosPorDia(DateTime fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                decimal gananciaTotal = ventas.consultarIngresosPorDia(fecha);

                return gananciaTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }



        // METODO PARA CONSULTAR LOS INGRESOS POR SEMANA ESPECIFICA
        public decimal consultarIngresosPorSemana(DateTime fecha)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                decimal gananciaTotal = ventas.consultarIngresosPorSemana(fecha);

                return gananciaTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA CONSULTAR LOS INGRESOS POR MES Y AÑO ESPECIFICOS
        public decimal consultarIngresosPorMesAño(int mes, int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                decimal gananciaTotal = ventas.consultarIngresosPorMesAño(mes, año);

                return gananciaTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }


        }





        // METODO PARA CONSULTAR LOS INGRESOS POR AÑO ESPECIFICO
        public decimal consultarIngresosPorAño(int año)
        {
            try
            {
                VentasDatos ventas = new VentasDatos();

                decimal gananciaTotal = ventas.consultarIngresosPorAño(año);

                return gananciaTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }

        }
    }
}
