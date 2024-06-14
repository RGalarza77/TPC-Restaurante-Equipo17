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
                datos.setearConsulta("SELECT M.Id, M.Numero, S.Nombre AS Sucursal, M.Personas, C.Nombre AS Cliente, Mo.Nombre AS Mozo, E.Estado AS EstadoMesa FROM Mesas M LEFT JOIN Sucursales S ON M.Sucursal = S.Id LEFT JOIN Clientes C ON M.Cliente = C.Documento LEFT JOIN Mozos Mo ON M.Mozo = Mo.Documento LEFT JOIN EstadoMesa E ON M.IdEstadoMesa = E.Id;"); 
                /*modificar consulta*/
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.NumeroMesa = (int)datos.Lector["Numero"];
                    aux.Sucursal = (string)datos.Lector["Sucursal"];
                    aux.CantidadPersonas = (int)datos.Lector["Personas"];


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
