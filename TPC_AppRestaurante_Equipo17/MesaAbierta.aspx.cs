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
                    /*obtengo las propiedades desde las mesas en session*/
                    int idMesa = int.Parse(Request.QueryString["Id"].ToString());
                    List<Mesa> temporal = (List<Mesa>)Session["listaMesas"];
                    Mesa mesa = temporal.Find(x => x.Id == idMesa);

                    /*Cargo lo obtenido*/
                    lblCantidadPersonas.Text = mesa.CantidadPersonas.ToString();
                    lblCliente.Text = mesa.Cliente.Numero.ToString();
                    lblMozo.Text = mesa.MozoAsignado.ToString();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnCerrarMesa_Click(object sender, EventArgs e)
        {
            string idMesa = Request.QueryString["Id"].ToString();

            List<Mesa> temporal = (List<Mesa>)Session["listaMesas"];
            Mesa mesa = temporal.Find(x => x.Id == int.Parse(idMesa));

            mesa.Estado = 1; /* 1- mesa libre*/


            Response.Redirect("MesaCerrada.aspx?Id=" + idMesa);
        }

        protected void btnAbrirMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentanaAgregarInsumos.aspx");
        }
    }
}