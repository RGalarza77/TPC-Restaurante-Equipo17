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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlatoNegocio PlaNeg = new PlatoNegocio();
            List<Plato> lista = new List<Plato>();
            lista = PlaNeg.listar();

            repInsumos.DataSource = lista;
            repInsumos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
         
        }
    }
}