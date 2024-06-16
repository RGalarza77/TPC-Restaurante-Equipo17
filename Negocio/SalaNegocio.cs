using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class SalaNegocio
    {
        public List<Sala> listar()
        {
            List<Sala> lista = new List<Sala>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Mesas FROM Salas;");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Sala aux = new Sala();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.CantidadMesas = (int)datos.Lector["Mesas"];

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
