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
        public MesaNegocio negocioMesa = new MesaNegocio();
        public SalaNegocio negocioSala = new SalaNegocio();

        public int idSala=1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaMesas"] == null)
                {

                    Session.Add("listaMesas", negocioMesa.listar()); /* guardo la lista de mesas en sesion*/
                }

                if (!IsPostBack)
                {             
                    //Cargar Salones
                    ddlSalones.DataSource = negocioSala.listar();
                    ddlSalones.DataTextField = "Nombre";
                    ddlSalones.DataValueField = "Id";
                    ddlSalones.DataBind();

                    
                    //Mostrar Mesas
                    idSala=int.Parse(ddlSalones.Items[0].Value);

                    cargarRepeaterMesas(idSala);

                }
            }catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected void ddlSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            idSala = int.Parse(ddlSalones.SelectedItem.Value);

            //Mostrar Mesas por salas
            cargarRepeaterMesas(idSala);
        }


        public string ObtenerIframeMesasSrc(object estado, object id) /* mostrar iframe depende del estado de la mesa*/
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
            else if (estado != null && estado.ToString() == "2")
            {
                return "btn btn-danger"; /* Botón rojo para estado 2 - mesa ocupada*/
            }
            else
            {
                return "btn btn-primary"; /* Botón azul para estado 3 - en proceso de pago*/
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e) /*btn para Agregar mesa*/
        {
            if (ddlSalones.SelectedItem.Value != null)
            {
                List<Sala> temporalSalas = negocioSala.listar();
                List<Mesa> temporalMesas = (List<Mesa>)Session["listaMesas"];
                idSala = int.Parse(ddlSalones.SelectedItem.Value);

                Mesa mesa = new Mesa();
                Sala sala = temporalSalas.Find(x => x.Id == idSala);

                //Agregar mesa a DB

                mesa.NumeroMesa = (sala.CantidadMesas) + 1;
                mesa.Sala = sala;
                negocioMesa.agregar(mesa);

                //Agregar mesa a session
                Session["listaMesas"] = negocioMesa.listar();


                //Modificar Sala.CantidadMesas en DB
                sala.CantidadMesas += 1;
                negocioSala.modificar(sala);

                //Cargar Mesas

                cargarRepeaterMesas(idSala);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
                if (ddlSalones.SelectedItem.Value != null)
                {
                    List<Sala> temporalSalas = negocioSala.listar();
                    List<Mesa> temporalMesas = (List<Mesa>)Session["listaMesas"];
                    idSala = int.Parse(ddlSalones.SelectedItem.Value);

                    Sala sala = temporalSalas.Find(x => x.Id == idSala);

                    
                    Mesa mesa = temporalMesas.FindLast(x => x.Sala.Id == idSala); /*ultima mesa de la sala*/

                    if(mesa.Id > 0)
                    {
                        //Quitar mesa a DB
                        negocioMesa.eliminar(mesa);

                        //Quitar mesa a session
                        temporalMesas.Remove(mesa);

                        Session["listaMesas"] = temporalMesas;


                        //Modificar Sala.CantidadMesas en DB
                        sala.CantidadMesas -= 1;
                        negocioSala.modificar(sala);

                        //Cargar Mesas
                        cargarRepeaterMesas(idSala);

                    }
                }
        }

        public void cargarRepeaterMesas(int idSala)
        {
            repMesas.DataSource = ((List<Mesa>)Session["listaMesas"]).FindAll(x => x.Sala.Id == idSala);
            repMesas.DataBind();
        }
    }

}