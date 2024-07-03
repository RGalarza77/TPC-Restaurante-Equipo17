using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PlatoNegocio
    {
        public List<Plato> listar()
        {
            List<Plato> lista = new List<Plato>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select  Id, Codigo, Nombre, Descripcion, Precio  from Platos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Plato plato = new Plato();

                    plato.Id = int.Parse(datos.Lector["Id"].ToString());
                    plato.Nombre = (string)datos.Lector["Nombre"];
                    plato.Codigo = (string)datos.Lector["Codigo"];
                    plato.Descripcion = (string)datos.Lector["Descripcion"];
                    plato.Precio = float.Parse(datos.Lector["Precio"].ToString());

                    lista.Add(plato);
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

        public int agregar(Plato nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Platos (Codigo, Nombre, Descripcion, Precio) output inserted.id values (@Codigo,@Nombre,@Descripcion,@Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio.ToString());
                return datos.ejecutarAccionScalar();



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
