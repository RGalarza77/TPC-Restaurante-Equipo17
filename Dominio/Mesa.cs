using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int Id { get; set; }
        public int NumeroMesa { get; set; }
        public Sala Sala { get; set; }
        public int CantidadPersonas { get; set; }
        public Cliente Cliente { get; set; }
        public int MozoAsignado { get; set; }
        public string Comentario { get; set; }
        public List<Insumo> Insumos { get; set; }
        public int Estado { get; set; } /* puede ser: 1-mesa libre(verde), 2-mesa ocupada(rojo), 3-en proceso de pago(azul)*/

    }
}
