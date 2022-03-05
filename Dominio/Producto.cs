using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDCategoria { get; set; }
        public int IDSubCategoria { get; set; }
        public DateTime FechaCarga { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public int IDMarca { get; set; }
        public List<Imagen> Items { get; set; }

    }
}
