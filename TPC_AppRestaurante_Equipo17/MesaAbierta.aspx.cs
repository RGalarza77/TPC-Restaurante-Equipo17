using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_AppRestaurante_Equipo17
{
    public partial class MesaAbierta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Id"] != null)
                {
                    int idMesa = int.Parse(Request.QueryString["Id"].ToString());
                    List<Mesa> temporal = (List<Mesa>)Session["listaMesas"];
                    if (temporal != null)
                    {
                        Mesa mesa = temporal.Find(x => x.Id == idMesa);
                        if (mesa != null)
                        {
                            lblCantidadPersonas.Text = mesa.CantidadPersonas.ToString();
                            //lblCliente.Text = mesa.Cliente.Numero.ToString();
                            lblMozo.Text = mesa.MozoAsignado.ToString();
                        }
                    }
                }

                if (!IsPostBack)
                {

                    List<Insumo> listaPedidos = (List<Insumo>)Session["listaPedidos"];
                    if (listaPedidos != null)
                    {
                        repListaPedido.DataSource = listaPedidos;
                        repListaPedido.DataBind();

                        if (listaPedidos.Count != 0)
                        {
                            sumarCompra();
                            btnVaciarLista.Visible = true;
                        }
                        else
                        {
                            Session.Remove("listaPedidos");
                            Response.Redirect("listaPedidos", false);
                            return;
                        }
                    }
                    else
                    {
                        lblListaSinPedidos.Visible = true;
                    }

                    cargarListadoInsumos();


                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnCerrarMesa_Click(object sender, EventArgs e)
        {
            int idMesa = int.Parse(Request.QueryString["Id"].ToString());
            MesaNegocio mesaNegocio = new MesaNegocio();

            List<Mesa> temporal = mesaNegocio.listar();
            if (temporal != null)
            {
                foreach (Mesa mesa in temporal)
                {
                    if (mesa.Id == idMesa)
                    {
                        mesa.Estado = 1; // mesa libre
                        break;
                    }
                }
                Session["listaMesas"] = temporal;
                Response.Redirect("MesaCerrada.aspx?Id=" + idMesa.ToString());
            }
        }

        protected void cargarListadoInsumos()
        {
            InsumoNegocio insumoNegocio = new InsumoNegocio();

            repPrincipal.DataSource = insumoNegocio.listarPrincipal();
            repPrincipal.DataBind();

            repPostres.DataSource = insumoNegocio.listarPostres();
            repPostres.DataBind();

            repBebidas.DataSource = insumoNegocio.listarBebidas();
            repBebidas.DataBind();
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Button btnSumar = (Button)sender;
            int id = int.Parse(btnSumar.CommandArgument);
            List<Insumo> lista = (List<Insumo>)Session["listaPedidos"];
            Insumo insumoSumar = lista.Find(x => x.Id == id);

            foreach (Insumo insumo in lista)
            {
                if (insumo.Id == insumoSumar.Id)
                {
                    insumo.Cantidad++;
                    Session["listaPedidos"] = lista;
                    Response.Redirect("MesaAbierta.aspx", false);
                    return;
                }
            }
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Button btnRestar = (Button)sender;
            int id = int.Parse(btnRestar.CommandArgument);
            List<Insumo> lista = (List<Insumo>)Session["listaPedidos"];
            Insumo insumoRestar = lista.Find(x => x.Id == id);

            foreach (Insumo insumo in lista)
            {
                if (insumo.Id == insumoRestar.Id)
                {
                    if (insumo.Cantidad < 2)
                    {
                        Response.Redirect("MesaAbierta.aspx", false);
                        return;
                    }

                    insumo.Cantidad--;
                    Session["listaPedidos"] = lista;
                    Response.Redirect("MesaAbierta.aspx", false);
                    return;
                }
            }
        }

        protected void sumarCompra()
        {
            decimal total = 0;
            List<Insumo> lista = (List<Insumo>)Session["listaPedidos"];
            foreach (Insumo insumo in lista)
            {
                total += insumo.Precio * insumo.Cantidad;
            }
            lblDescuento.Text = "Descuento: 0%";
            lblSubtotal.Text = "Subtotal: $" + total;
            lblTotal.Text = "Total: $" + total;
        }

        protected void btnVaciarLista_Click(object sender, EventArgs e)
        {
            Session.Remove("listaPedidos");
            Response.Redirect("MesaAbierta.aspx", false);
        }

        protected void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            Button btnEliminarInsumo = (Button)sender;
            int idInsumo = int.Parse(btnEliminarInsumo.CommandArgument);

            List<Insumo> listaPedidos = (List<Insumo>)Session["listaPedidos"];
            foreach (Insumo insumo in listaPedidos)
            {
                if(insumo.Id == idInsumo)
                {
                    listaPedidos.Remove(insumo);
                    Session["listaPedidos"] = listaPedidos;

                    if (listaPedidos.Count() == 0)/*si la lista no posee insumos, vaciar la session*/ 
                    {
                        Session.Remove("listaPedidos");
                    }
                    Response.Redirect("MesaAbierta.aspx", false);
                    return;
                }
            }
        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Button btnAgregarInsumo = (Button)sender;
            int idInsumo = int.Parse(btnAgregarInsumo.CommandArgument);

            List<Insumo> nuevaListaInsumos = Session["listaPedidos"] != null
                ? (List<Insumo>)Session["listaPedidos"]
                : new List<Insumo>();

            InsumoNegocio insumoNegocio = new InsumoNegocio();
            List<Insumo> lista = insumoNegocio.listar();

            bool existe = false;

            if (idInsumo > 0)
            {
                Insumo insumoAgregado = lista.Find(x => x.Id == idInsumo);

                foreach (Insumo insumo in nuevaListaInsumos)
                {
                    if (insumo.Id == insumoAgregado.Id)
                    {
                        existe = true;
                        insumo.Cantidad++;
                        break;
                    }
                }

                if (!existe)
                {
                    insumoAgregado.Cantidad = 1;
                    nuevaListaInsumos.Add(insumoAgregado);
                }

                Session["listaPedidos"] = nuevaListaInsumos;
                Response.Redirect("MesaAbierta.aspx", false);
            }

        }
    }
}