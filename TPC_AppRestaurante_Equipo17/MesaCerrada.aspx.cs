using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_AppRestaurante_Equipo17
{
    public partial class MesaCerrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}