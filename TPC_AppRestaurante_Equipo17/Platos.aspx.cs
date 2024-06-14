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
            PlatoNegocio PlaNeg = new PlatoNegocio();
            List<Plato> lista = new List<Plato>();
            lista = PlaNeg.listar();
            if (!IsPostBack)
            {
                repPlatos.DataSource = lista;
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
                plato.Precio = float.Parse(txtPrecio.Text.ToString());

                plato.Id = negocio.agregar(plato);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }




        }
    }
}