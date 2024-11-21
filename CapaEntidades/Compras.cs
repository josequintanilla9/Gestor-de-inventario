using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Compras
    {
        // ATRIBUTOS DE LA CLASE COMPRAS ENCAPSULADOS
        int idCompra;
        int idProducto;
        string nombreProducto = "";
        decimal precioCompra;
        int cantidadComprada;
        decimal total;
        DateTime fechaCompra;


        // METODOS PARA ACCEDER A LOS ATRIBUTOS DE ESTA CLASE
        public int IdCompra { get => idCompra; set => idCompra = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public int CantidadComprada { get => cantidadComprada; set => cantidadComprada = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
    }
}
