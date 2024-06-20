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

                    
                    //Cargar Salones
                    ddlSalones.DataSource = negocioSala.listar();
                    ddlSalones.DataTextField = "Nombre";
                    ddlSalones.DataValueField = "Id";
                    ddlSalones.DataBind();

                    
                    int idSala=int.Parse(ddlSalones.Items[0].Value);
                    //Mostrar Mesas
                    repMesas.DataSource = ((List<Mesa>)Session["listaMesas"]).FindAll(x => x.Sala.Id == idSala);
                    repMesas.DataBind();

                }


            }catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected void ddlSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSala = int.Parse(ddlSalones.SelectedItem.Value);

            //Mostrar Mesas
            repMesas.DataSource = ((List<Mesa>)Session["listaMesas"]).FindAll(x=> x.Sala.Id == idSala);
            repMesas.DataBind();
        }
    }

}