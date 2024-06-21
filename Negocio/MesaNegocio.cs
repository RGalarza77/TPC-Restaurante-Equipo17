using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MesaNegocio
    {
        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT M.Id, M.Numero,M.IdSala, S.Nombre AS NombreSala FROM Mesas M LEFT JOIN Salas S ON M.IdSala = S.Id;"); 
                /*modificar consulta*/
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.NumeroMesa = (int)datos.Lector["Numero"];
                    aux.Sala = new Sala();
                    aux.Sala.Id = (int)datos.Lector["IdSala"];
                    aux.Sala.Nombre = (string)datos.Lector["NombreSala"];
                    aux.Estado = 1; /*mesa libre*/

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
