using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    //public enum Puesto
    //{
    //    MOZO = 1,
    //    COCINERO=2,
    //    SUPERVISOR=3,
    //    ADMINISTRADOR=4
    //}
    public class Empleado
    {
        public int Dni { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public int Puesto { get; set; }
        public bool Activo { get; set; }

    }  
}
