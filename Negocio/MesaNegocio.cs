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
                datos.setearConsulta("SELECT M.Id, M.Numero, M.IdSala, S.Nombre AS NombreSala FROM Mesas M LEFT JOIN Salas S ON M.IdSala = S.Id;"); 

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

        public void agregar(Mesa mesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Mesas values (@Numero, @IdSala)");
                datos.setearParametro("@Numero", mesa.NumeroMesa);
                datos.setearParametro("@IdSala", mesa.Sala.Id);
                datos.ejecutarAccion();

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(Mesa mesa)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Mesas Where Id = @Id;");
                datos.setearParametro("@Id", mesa.Id);
                datos.ejecutarAccion();
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
