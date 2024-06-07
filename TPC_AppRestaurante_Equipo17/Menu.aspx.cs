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
            InsumoNegocio insNeg = new InsumoNegocio();
            List<Insumo> listaInsumos = new List<Insumo>();
            listaInsumos = insNeg.listar();

            repInsumos.DataSource = listaInsumos;
            repInsumos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
         
        }
    }
}