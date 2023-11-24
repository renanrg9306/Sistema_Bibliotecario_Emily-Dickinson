using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Services;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Visitante.Materiales
{
    public partial class ReservacionesPendienteVisitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GdvReservacionesSinEntregar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GdvReservacionesSinEntregar_PreRender(object sender, EventArgs e)
        {
            GdvReservacionesSinEntregar.DataSource = ReservacionBLL.ShowReservacionesSinEntegarByVisitante(VisitanteBLL.GetIdVisitante(Session["username"].ToString()));
            GdvReservacionesSinEntregar.DataBind();
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteReservacion(string IdReserva)
        {
            ReservacionEntity oReservacion = new ReservacionEntity();
            oReservacion.IdResercacion = Convert.ToInt32(IdReserva);
            oReservacion.EstadoEliminado = true;
            string msg = "";
            if (ReservacionBLL.DeleteReservacion(oReservacion))
            {
                ReservacionEntity oAuxReservacion = new ReservacionEntity();
                oAuxReservacion = ReservacionBLL.ReservacionAPrestamo(Convert.ToInt32(IdReserva));
                MaterialEntity oMaterialEntity = new MaterialEntity();
                oMaterialEntity.IdMaterial = oAuxReservacion.MaterialEntity.IdMaterial;
                oMaterialEntity.Reservado = oAuxReservacion.Cantidad;
                if (MaterialBLL.EntregarReservacion(oMaterialEntity))
                { 
                msg = "Ok";
                }   
            }
            else
            {
                msg = "Error";
            }

            return new { Result = msg };

        }
    }
}