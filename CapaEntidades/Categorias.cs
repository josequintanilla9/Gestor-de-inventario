using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Categorias
    {
        // ATRIBUTOS DE LA CLASE CATEGORIAS ENCAPSULADOS
        int idCategoria;
        string nombreCategoria = "";



        // METODOS PARA ACCEDER A LOS ATRIBUTOS DE ESTA CLASE
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    }
}
