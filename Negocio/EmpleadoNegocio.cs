using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listarMozos()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Documento, Legajo, Nombre, IdPuesto, Activo FROM Empleados WHERE IdPuesto=1 AND Activo=1;");
                /*modificar consulta*/
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Dni = (int)datos.Lector["Documento"];
                    aux.Legajo = (int)datos.Lector["Legajo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Puesto = (int)datos.Lector["IdPuesto"];
                    aux.Activo = (bool)datos.Lector["Activo"];


                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

