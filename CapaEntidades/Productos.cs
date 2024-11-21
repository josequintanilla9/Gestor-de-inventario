using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Productos
    {
        // ATRIBUTOS DE LA CLASE PRODUCTOS ENCAPSULADOS
        private int idProducto;
        private string nombreProducto = "";
        private string? descripcion;
        private decimal precioCompra;
        private decimal precioVenta;
        private string nombreCategoria = "";
        private int idCategoria;
        private int cantidadDisponible;


        // METODOS PARA ACCEDER A LOS ATRIBUTOS DE ESTA CLASE
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    }
}
