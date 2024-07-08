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
        public ClienteNegocio clienteNegocio = new ClienteNegocio();
        public EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack) /*si es la primera vez que carga la pantalla*/
                {
                    //cliente
                    ddlClientes.Enabled = false;

                    ddlClientes.DataSource = clienteNegocio.listar();


                    ddlClientes.DataTextField = "Nombre";    /*reemplazar por un menu de busqueda de clientes*/
                    ddlClientes.DataValueField = "Numero";
                    ddlClientes.DataBind();

                    //Mozo
                    ddlMozo.DataSource = empleadoNegocio.listarMozos();

                    ddlMozo.DataTextField = "Nombre";
                    ddlMozo.DataValueField = "Legajo";
                    ddlMozo.DataBind();



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
            MesaNegocio mesaNegocio = new MesaNegocio();

            if (Request.QueryString["Id"] == null)
            {
                return;
            }
            int IdMesa = int.Parse(Request.QueryString["Id"].ToString());
            List<Mesa> temporalMesas = mesaNegocio.listar();

            foreach (Mesa mesa in temporalMesas)
            {
                if (mesa.Id == IdMesa)
                {
                    //Cantidad Personas
                    mesa.CantidadPersonas = int.Parse(txtCantidadPersonas.Text);

                    //Cliente

                    List<Cliente> temporalClientes = clienteNegocio.listar();

                    if (ddlClientes.Enabled)
                    {
                        int numeroCliente = int.Parse(ddlClientes.SelectedValue);
                        mesa.Cliente = temporalClientes.Find(x => x.Numero == numeroCliente);


                    }
                    else
                    {
                        mesa.Cliente = temporalClientes.Find(x => x.Numero == 0);

                    }

                    //Mozo
                    mesa.MozoAsignado = int.Parse(ddlMozo.SelectedValue);

                    //Estado
                    mesa.Estado = 2;  /* 2- mesa ocupada*/

                    break;
                }

            }

            Session["listaMesas"] = temporalMesas;

            /*Mandar por parametro id y redireccionar a la ventana de mesaAbierta */

            Response.Redirect("MesaAbierta.aspx?Id=" + IdMesa.ToString());


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