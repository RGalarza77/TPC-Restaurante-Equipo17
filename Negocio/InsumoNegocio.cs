﻿using System;
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
                datos.setearConsulta("select Id, Nombre, Descripcion, Precio, Categoria  from platos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo ins = new Insumo();
                    ins.Id = (int)datos.Lector["Id"];
                    ins.Nombre = (string)datos.Lector["Nombre"];
                    ins.Descripcion = (string)datos.Lector["Descripcion"];
                    ins.Precio = (decimal)datos.Lector["Precio"];
                    ins.Categoria = (int)datos.Lector["Categoria"];
                    ins.Cantidad = 1;
                    ins.Disponible = true;

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


        public List<Insumo> listarPrincipal()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, Precio, Categoria  from platos WHERE categoria=1;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo ins = new Insumo();
                    ins.Id = (int)datos.Lector["Id"];
                    ins.Nombre = (string)datos.Lector["Nombre"];
                    ins.Descripcion = (string)datos.Lector["Descripcion"];
                    ins.Precio = (decimal)datos.Lector["Precio"];
                    ins.Categoria = (int)datos.Lector["Categoria"];
                    ins.Cantidad = 1;
                    ins.Disponible = true;

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

        public List<Insumo> listarBebidas()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, Precio, Categoria  from platos WHERE categoria=2;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo ins = new Insumo();
                    ins.Id = (int)datos.Lector["Id"];
                    ins.Nombre = (string)datos.Lector["Nombre"];
                    ins.Descripcion = (string)datos.Lector["Descripcion"];
                    ins.Precio = (decimal)datos.Lector["Precio"];
                    ins.Categoria = (int)datos.Lector["Categoria"];
                    ins.Cantidad = 1;
                    ins.Disponible = true;

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

        public List<Insumo> listarPostres()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, Precio, Categoria  from platos WHERE categoria=3;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo ins = new Insumo();
                    ins.Id = (int)datos.Lector["Id"];
                    ins.Nombre = (string)datos.Lector["Nombre"];
                    ins.Descripcion = (string)datos.Lector["Descripcion"];
                    ins.Precio = (decimal)datos.Lector["Precio"];
                    ins.Categoria = (int)datos.Lector["Categoria"];
                    ins.Cantidad = 1;
                    ins.Disponible = true;

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
