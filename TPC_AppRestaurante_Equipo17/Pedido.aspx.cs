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
	public partial class Pedido : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{
			InsumoNegocio insumos = new InsumoNegocio();
			List<Insumo> listaInsumos;
			listaInsumos = insumos.listar();

            repInsumos.DataSource = listaInsumos;
            repInsumos.DataBind();
        }
    
	}
}