using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Insumo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Precio { get; set; }
        public bool Disponible { get; set; }
    }

}
