using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Visitante.Materiales
{
    public partial class ReservacionMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    LbFecha.Text = DateTime.Now.ToShortDateString();
                    this.ViewState["referer"] = HttpContext.Current.Request.UrlReferrer.PathAndQuery;
                }
            }    
           

        }

        protected void DdlMaterialAB_PreRender(object sender, EventArgs e)
        {
            DdlMaterialAB.DataSource = MaterialBLL.ShowMaterial();
            DdlMaterialAB.DataTextField = "Nombre";
            DdlMaterialAB.DataValueField = "idMaterial";
            DdlMaterialAB.DataBind();
            DdlMaterialAB.SelectedValue = Request.QueryString["Id"].ToString();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Regresar(ViewState["referer"]);
        }

        public static void Regresar(object sURL)
        {
            try
            {
                HttpContext.Current.Response.Redirect(sURL.ToString());
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ReservacionEntity oReservacion = new ReservacionEntity();
                MaterialEntity oMaterial = new MaterialEntity();

                oMaterial = MaterialBLL.GetCantidadMaterial(Convert.ToInt32(DdlMaterialAB.SelectedValue));
                int Existencia = 0;
                Existencia = oMaterial.Cantidad - (oMaterial.Prestado + oMaterial.Reservado);

                oReservacion.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterialAB.SelectedValue);
                oReservacion.VisitanteEntity.IdVisitante = VisitanteBLL.GetIdVisitante(Convert.ToString(Session["username"]));
                oReservacion.FechaReservacionEntrega = Convert.ToDateTime(TxtFecha.Text);
                oReservacion.FechaReservacionDia = Convert.ToDateTime(LbFecha.Text);
                oReservacion.Estado = false;
                oReservacion.EstadoEliminado = false;
                oReservacion.Cantidad = Convert.ToInt32(TxtCantidadM.Text);
                if (Existencia > 0 && oReservacion.Cantidad <= Existencia)
                {
                    if (ReservacionBLL.InsertResevacion(oReservacion))
                    {
                        oMaterial.IdMaterial = oReservacion.MaterialEntity.IdMaterial;
                        oMaterial.Reservado = oReservacion.Cantidad;
                        if (MaterialBLL.AsignarReservacion(oMaterial))
                        {
                            Regresar(ViewState["referer"]);
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorExistencia();", true);
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}