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
    public partial class MesaCerrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio= new ClienteNegocio();

            try
            {
                if (!IsPostBack) /*si es la primera vez que carga la pantalla*/
                {
                    ddlClientes.Enabled = false;

                    ddlClientes.DataSource = clienteNegocio.listar();


                    ddlClientes.DataTextField = "Numero";    /*reemplazar por un menu de busqueda de clientes*/
                    ddlClientes.DataValueField = "Documento";
                    ddlClientes.DataBind();
                }

            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAbrirMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesaAbierta.aspx");
        }

        protected void chkClienteRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            ddlClientes.Enabled = true;
        }

        protected void chkClienteNoRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            ddlClientes.Enabled = false;
        }
    }
}