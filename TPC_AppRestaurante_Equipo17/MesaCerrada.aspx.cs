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
            Mesa mesa;

            try
            {
                if (!IsPostBack) /*si es la primera vez que carga la pantalla*/
                {
                    MesaNegocio mesaNegocio = new MesaNegocio();
                    ClienteNegocio clienteNegocio = new ClienteNegocio();

                    if (Request.QueryString["id"].ToString() != null)
                    {
                        int idMesa = int.Parse(Request.QueryString["id"].ToString());
                        List<Mesa> temporal = (List<Mesa>)Session["listaMesas"];
                        mesa = temporal.Find(x => x.Id == idMesa);

                    }

                    //cliente
                    ddlClientes.Enabled = false;

                    ddlClientes.DataSource = clienteNegocio.listar();


                    ddlClientes.DataTextField = "Numero";    /*reemplazar por un menu de busqueda de clientes*/
                    ddlClientes.DataValueField = "Documento";
                    ddlClientes.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtCantidadPersonas.Text);
            if(n > 1)
                txtCantidadPersonas.Text = (n - 1).ToString();

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtCantidadPersonas.Text);
            if(n < 30) //Limite de 30 personas por mesa
                txtCantidadPersonas.Text = (n + 1).ToString();
        }

        protected void btnAbrirMesa_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"].ToString() != null)
            {
                string idMesa = Request.QueryString["id"].ToString();
                
                Response.Redirect("MesaAbierta.aspx?Id="+ idMesa);

            }
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