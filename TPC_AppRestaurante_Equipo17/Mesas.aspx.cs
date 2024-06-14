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
            MesaNegocio negocioMesa = new MesaNegocio();
            List<Mesa> listaMesas = negocioMesa.listar();

            if (!IsPostBack)
            {
                repMesas.DataSource=listaMesas;
                repMesas.DataBind();

            }

        }

   
    }

}