using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_AppRestaurante_Equipo17
{
    public partial class MesaAbierta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected void btnCerrarMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesaCerrada.aspx");
        }
    }
}