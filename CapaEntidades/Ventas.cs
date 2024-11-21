using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Ventas
    {
        // ATRIBUTOS DE LA CLASE VENTAS ENCAPSULADOS
        int idVenta;
        int idProducto;
        string nombreProducto = "";
        decimal precioVenta;
        int cantidadVendida;
        decimal total;
        DateTime fechaVenta;


        // METODOS PARA ACCEDER A LOS ATRIBUTOS DE ESTA CLASE
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public int CantidadVendida { get => cantidadVendida; set => cantidadVendida = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
    }
}
