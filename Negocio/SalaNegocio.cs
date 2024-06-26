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

        public void agregar(Sala sala)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Salas (Nombre, Mesas) VALUES (@Nombre, @CantidadMesas)");
                datos.setearParametro("@Nombre", sala.Nombre);
                datos.setearParametro("@CantidadMesas", sala.CantidadMesas);
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

        public void modificar(Sala sala)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Salas SET Nombre=@Nombre, Mesas=@CantidadMesas WHERE Id=@Id");
                datos.setearParametro("@Nombre", sala.Nombre);
                datos.setearParametro("@CantidadMesas", sala.CantidadMesas);
                datos.setearParametro("@Id", sala.Id);
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
