using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_AppRestaurante_Equipo17
{
    public partial class ModificarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null && !IsPostBack)
            {
                int id = int.Parse(Request.QueryString["Id"].ToString());
                List<Plato> temp = (List<Plato>)Session["listaPlatos"];
                Plato modificado = temp.Find(x => x.Id == id);

                txtID.Text = modificado.Id.ToString();
                txtID.ReadOnly = true;
                txtCodigo.Text = modificado.Codigo;
                txtNombre.Text = modificado.Nombre;
                txtDescripcion.Text = modificado.Descripcion;
                txtPrecio.Text = modificado.Precio.ToString();
            }


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Plato nuevo = new Plato();
            PlatoNegocio negocio = new PlatoNegocio();

            nuevo.Id = int.Parse(txtID.Text);
            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Precio = float.Parse(txtPrecio.Text);

            negocio.modificar(nuevo);

            Response.Redirect("platos.aspx");

        }
    }
}