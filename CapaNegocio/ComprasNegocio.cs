using CapaDatos;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ComprasNegocio
    {

        // METODO PARA REGISTRAR UNA NUEVA COMPRA
        public bool registrarCompra(int idProducto, decimal precio, int cantidad, DateTime fecha, out string mensaje)
        {
            bool registrado = false;

            mensaje = "";

            try
            {
                if (cantidad <= 500)
                {

                    // Modelo compras
                    ComprasDatos compras = new ComprasDatos();

                    decimal total = cantidad * precio;

                    // Metodo para guardar la compra
                    registrado = compras.guardar(idProducto, precio, cantidad, total, fecha);

                    if (registrado)
                    {
                        ProductosNegocio productos = new ProductosNegocio();

                        // Consultamos las existencias del producto
                        int existencias = productos.consultarExistencias(idProducto);

                        // Actualizar las existencias del producto
                        int existenciaActualizada = existencias + cantidad;

                        productos.actualizarExistencias(idProducto, existenciaActualizada);
                    }
                }
                else
                {
                    mensaje = "La cantidad comprada pasa el maximo admitido: 500.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
          
            return registrado;
        }





        // METODO PARA CANCELAR UNA COMPRA
        public bool cancelarCompra(int idCompra, int cantidad, int idProducto)
        {
            bool cancelado = false;

            ComprasDatos compras = new ComprasDatos();

            try
            {
                // Se cancela la compra
                cancelado = compras.cancelar(idCompra);

                if (cancelado)
                {

                    ProductosNegocio productos = new ProductosNegocio();

                    // Consultamos las existencias del producto
                    int existencias = productos.consultarExistencias(idProducto);


                    // Actualizar las existencias del producto

                    int existenciaActualizada = existencias - cantidad; // Se eliminan los productos de esa compra del inventario

                    // Si la existencia del del producto es cero o mayor, actualiza la existencia.
                    if (existenciaActualizada >= 0)
                    {
                        productos.actualizarExistencias(idProducto, existenciaActualizada);
                    }
                    // Si la existencia del producto es menor que cero, deja la existencia a cero.
                    else
                    {
                        existenciaActualizada = 0;

                        productos.actualizarExistencias(idProducto, existenciaActualizada);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            
            return cancelado;
        }



        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL DIA.
        public DataTable buscarComprasDia(string NombreProducto, DateTime Fecha)
        {
            

            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.buscarComprasDia(NombreProducto, Fecha);
            }
            catch(Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO LA SEMANA.
        public DataTable buscarComprasSemana(string NombreProducto, DateTime Fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.buscarComprasSemana(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }

        }





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL MES Y AÑO.
        public DataTable buscarComprasMesAño(string NombreProducto, int mes, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.buscarComprasMesAño(NombreProducto, mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA BUSCAR LA COMPRAS DE UN PRODUCTO ESPECIFICANDO EL AÑO.
        public DataTable buscarComprasAño(string NombreProducto, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.buscarComprasAño(NombreProducto, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LAS COMPRAS DEL DIA ACTUAL - ("FORMULARIO DE REGISTRAR COMPRAS").
        public DataTable ConsultarCompras()
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.ConsultarCompras();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA CARGAR PRODUCTOS EN UN COMBOBOX - ("FORMULARIO DE REGISTRAR COMPRAS").
        public DataTable consultarProductos()
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.consultarProductos();
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
                ComprasDatos compras = new ComprasDatos();

                decimal precioProducto = compras.ConsultarPrecioProducto(id);

                return precioProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }










        // ------------------- FILTROS DE BUSQUEDA DE COMPRAS PARA FORMULARIO COMPRAS -------------------




        // METODO PARA BUSCAR COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO EL DIA QUE SE QUIERA CONSULTAR
        public DataTable filtrarFecha(DateTime fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.filtrarFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONANDO LA SEMANA QUE SE QUIERA CONSULTAR
        public DataTable consultarComprasSemana(DateTime fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.consultarComprasSemana(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }






        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO, SELECCIONANDO EL MES Y EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarComprasMesAño(int mes, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.consultarComprasMesAño(mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA MOSTRAR LAS COMPRAS AGRUPADAS POR NOMBRE DEL PRODUCTO SELECCIONADO EL AÑO QUE SE QUIERA CONSULTAR.
        public DataTable consultarComprasAño(int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.consultarComprasAño(año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }








        // ------------------- DETALLES DE LAS COMPRAS -------------------








        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y EL DIA ESPECIFICIO
        public DataTable ConsultarDetalleDiaCompra(string NombreProducto, DateTime Fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.ConsultarDetalleDiaCompra(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y LA SEMANA ESPECIFICIA
        public DataTable ConsultarDetalleSemanaCompra(string NombreProducto, DateTime Fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.ConsultarDetalleSemanaCompra(NombreProducto, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO, EL MES Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleMesAñoCompra(string NombreProducto, int mes, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.ConsultarDetalleMesAñoCompra(NombreProducto, mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // METODO PARA MOSTRAR LOS DETALLES DE UNA COMPRA SEGUN EL NOMBRE DEL PRODUCTO Y EL AÑO ESPECIFICADOS
        public DataTable ConsultarDetalleAñoCompra(string NombreProducto, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                return compras.ConsultarDetalleAñoCompra(NombreProducto, año);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }





        // ------------------- METODOS PARA CONSULTAR LOS GASTOS OBTENIDOS -------------------







        // METODO PARA CONSULTAR LOS GASTOS POR DIA ESPECIFICO
        public decimal consultarGastosPorDia(DateTime fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                decimal gastoTotal = compras.consultarGastosPorDia(fecha);

                return gastoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }






        // METODO PARA CONSULTAR LOS GASTOS POR SEMANA ESPECIFICA
        public decimal consultarGastosPorSemana(DateTime fecha)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                decimal gastoTotal = compras.consultarGastosPorSemana(fecha);

                return gastoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }








        // METODO PARA CONSULTAR LOS GASTOS POR MES Y AÑO ESPECIFICOS
        public decimal consultarGastosPorMesAño(int mes, int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                decimal gastoTotal = compras.consultarGastosPorMesAño(mes, año);

                return gastoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }

            
        }





        // METODO PARA CONSULTAR LOS GASTOS POR AÑO ESPECIFICO
        public decimal consultarGastosPorAño(int año)
        {
            try
            {
                ComprasDatos compras = new ComprasDatos();

                decimal gastoTotal = compras.consultarGastosPorAño(año);

                return gastoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }

        }

    }
}
