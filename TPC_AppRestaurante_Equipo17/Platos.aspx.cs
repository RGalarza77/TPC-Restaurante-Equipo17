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
    public partial class Platos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaPLatos"] == null)
            {
                PlatoNegocio PlaNeg = new PlatoNegocio();
                Session.Add("listaPlatos", PlaNeg.listar());
            }
            
          
            if (!IsPostBack)
            {
                repPlatos.DataSource = Session["listaPlatos"];
                repPlatos.DataBind();

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Plato plato = new Plato();
                PlatoNegocio negocio = new PlatoNegocio();


                plato.Codigo = txtCod.Text;
                plato.Nombre = txtNombre.Text;
                plato.Descripcion = txtDescripcion.Text;
                plato.Precio = decimal.Parse(txtPrecio.Text.ToString());

                plato.Id = negocio.agregar(plato);
                ((List<Plato>)Session["listaPlatos"]).Add(plato);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }




        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("ModificarPLato.aspx?Id=" + valor);
        }
    }
}