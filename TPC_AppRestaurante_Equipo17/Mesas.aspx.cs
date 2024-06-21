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


        public string ObtenerIframeSrc(object estado, object id) /* mostrar iframe depende del estado de la mesa*/
        {
            if (estado != null && estado.ToString() == "1")
            {
                return "MesaCerrada.aspx?Id=" + id.ToString();
            }
            else
            {
                return "MesaAbierta.aspx?Id=" + id.ToString();
            }
        }

        public string ObtenerButtonClass(object estado) /*cambiar de color el boton depende del estado mesa*/
        {
            if (estado != null && estado.ToString() == "1")
            {
                return "btn btn-success"; /* Botón verde para estado 1 - mesa libre*/
            }
            else if(estado != null && estado.ToString() == "2")
            {
                return "btn btn-danger"; /* Botón rojo para estado 2 - mesa ocupada*/
            }
            else
            {
                return "btn btn-danger"; /* Botón azul para estado 3 - en proceso de pago*/
            }
        }


    }

}