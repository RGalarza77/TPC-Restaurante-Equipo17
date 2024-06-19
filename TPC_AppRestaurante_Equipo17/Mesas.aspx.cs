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
    public partial class Mesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                MesaNegocio negocioMesa = new MesaNegocio();
                SalaNegocio negocioSala = new SalaNegocio();

                if (Session["listaMesas"] == null)
                {

                    Session.Add("listaMesas", negocioMesa.listar()); /* guardo la lista de mesas en sesion*/
                }

                if (!IsPostBack)
                {
                    List<Mesa> listaMesas = negocioMesa.listar();

                    

                    //Mesas
                    repMesas.DataSource=listaMesas;
                    repMesas.DataBind();

                    //Salones
                    ddlSalones.DataSource = negocioSala.listar();
                    ddlSalones.DataTextField = "Nombre";
                    ddlSalones.DataValueField = "Id";
                    ddlSalones.DataBind();

                }


            }catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

   
    }

}