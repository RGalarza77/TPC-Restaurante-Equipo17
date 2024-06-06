using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        CLIENTE = 0,
        MOZO = 1,
        SUPERVISOR = 2,
        ADMINISTRADOR = 3
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public TipoUsuario Tipo { get; set; }

        //domicilio - fechanacimiento
    }
}
