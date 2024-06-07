using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Net;
using System.Data;

namespace Negocio
{
    public class InsumoNegocio
    {
        public List<Insumo> listar()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select  Nombre, Categoria, Precio, CuponDescuento from Platos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo ins = new Insumo();

                    ins.Name = (string)datos.Lector["Nombre"];
                    ins.Categoria = (string)datos.Lector["Categoria"];
                    ins.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(ins);
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
