using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public   class Direccion
    {
        public int ID { get; set; }
        public int IDCiudad { get; set; }
        public int IDProvincia { get; set; }
        public string Calle { get; set; }
        public int Numeracion { get; set; }
        public string Depto { get; set; }
        public string Piso { get; set; }
        public string CP { get; set; }
    }
}
