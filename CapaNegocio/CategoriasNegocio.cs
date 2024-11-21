using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriasNegocio
    {
        // METODO PARA MOSTRAR LAS CATEGORIAS
        public DataTable ConsultarCategorias()
        {
            try
            {
                CategoriasDatos categorias = new CategoriasDatos();
                return categorias.consultar();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
        }






        // METODO PARA BUSCAR UNA CATEGORIA
        public DataTable BuscarCategorias(string dato)
        {

            try
            {
                // Modelo categorias
                CategoriasDatos categorias = new CategoriasDatos();

                // Obtiene los resultados de la busqueda
                return categorias.buscar(dato);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar a la base de datos, error: " + ex.Message);
            }
            
        }





        // METODO PARA VALIDAR LA AGREGACIÓN DE UNA NUEVA CATEGORIA
        public bool agregarCategorias(string nombre)
        {
            bool agregado = false;
            // Valida que no este vacio
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                // Modelo categorias
                CategoriasDatos categorias = new CategoriasDatos();

                try
                {
                    // Guarda la categoria en la base de datos
                    agregado = categorias.guardar(nombre);
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocurrio un error: " + ex.Message);
                }
                

            }
            return agregado;
        }







        // METODO PARA VALIDAR LA EDICION DE UNA CATEGORIA
        public bool editarCategoria(int id, string nombre)
        {
            // verifica si se agrego correctamente la categoria
            bool editado = false;

            // Modelo categorias
            CategoriasDatos categorias = new CategoriasDatos();

            try
            {
                // Confirma que la edición fue exitosa
                editado = categorias.editar(id, nombre);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
            

            return editado;
        }






        // METODO PARA VALIDAR LA DESACTIVACIÓN DE UNA CATEGORIA
        public bool desactivarCategoria(int id)
        {
            // verifica si se elimino correctamente la categoria
            bool desactivado = false;

            try
            {
                CategoriasDatos categorias = new CategoriasDatos();

                // Elimina la categoria y sus productos relacionados
                categorias.desactivarCategoria(Convert.ToInt32(id));
                categorias.desactivarCategoriaProductos(Convert.ToInt32(id));

                // Confirma que la eliminación fue exitosa
                desactivado = true;
            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }        

            return desactivado;
        }
    }
}
