using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocio
{
    public class ProductosNegocio
    {
        //METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable ConsultarProductos()
        {
            try
            {
                ProductosDatos productos = new ProductosDatos();
                return productos.consultar();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }



        // METODO PARA BUSCAR PRODUCTOS
        public DataTable BuscarProductos(string dato)
        {
            try
            {
                
                ProductosDatos productos = new ProductosDatos();

                // Obtiene los resultados de la busqueda
                return productos.buscar(dato);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }




        // METODO PARA CARGAR CATEGORIAS EN UN COMBOBOX
        public DataTable mostrarCategorias()
        {
            ProductosDatos productos = new ProductosDatos();

            // Metodo para consultar las categorias a la base de datos
            return productos.consultarCategorias();
        }







        // METODO PARA VALIDAR LA AGREGACIÓN DE UN NUEVO PRODUCTO
        public bool agregarProducto(string nombre, string descripcion, decimal precioCompra, decimal precioVenta, int idCategoria, int cantidad, out string Mensaje)
        {
            bool agregado = false;
            Mensaje = "";

            
            try
            {
                

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    if (cantidad <= 500)
                    {
                        ProductosDatos productos = new ProductosDatos();

                        agregado = productos.guardar(nombre, descripcion, precioCompra, precioVenta, idCategoria, cantidad, out string mensaje);

                        if(agregado == false)
                        {
                            Mensaje = mensaje;
                        }
                    }
                    else
                    {
                        Mensaje = "La existencia del producto pasa el maximo admitido: 500.";
                    }
                }
                else
                {
                    Mensaje = "El producto debe de tener un nombre.";
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agregado;
        }




        // METODO PARA VALIDAR EL EDITAR UN PRODUCTOS
        public bool editarProducto(int id, string nombre, string descripcion, decimal precioCompra, decimal precioVenta, int idCategoria, int cantidad, out string mensaje)
        {
            bool editado = false;

            mensaje = "";


            try
            {
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    if (cantidad <= 500)
                    {
                        ProductosDatos productos = new ProductosDatos();

                        editado = productos.editar(id, nombre, descripcion, precioCompra, precioVenta, idCategoria, cantidad);

                        editado = true;
                    }
                    else
                    {
                        mensaje = "La existencia del producto pasa el maximo admitido: 500.";
                    }
                }
                else
                {
                    mensaje = "El producto debe de tener un nombre.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

            return editado;
        }




        // METODO PARA DESACTIVAR UN PRODUCTO
        public bool desactivarProducto(int id)
        {
            bool desactivado = false;

            try
            {
                // Código para eliminar el producto

                ProductosDatos productos = new ProductosDatos();

                productos.desactivar(id);

                desactivado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

            return desactivado;
        }




        // METODO PARA CONSULTAR EXISTENCIAS
        public int consultarExistencias(int idProducto)
        {
            int existencias = 0;

            try
            {
                ProductosDatos productos = new ProductosDatos();

                existencias = productos.Existencias(idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }


            return existencias;
        }




        // METODO QUE LLAMA AL MODELO PRODUCTOS PARA ACTUALIZAR EXISTENCIAS
        public void actualizarExistencias(int idProducto, int cantidad)
        {
            try
            {
                ProductosDatos productos = new ProductosDatos();

                productos.editarExistencias(idProducto, cantidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

            
        }

    }
}
