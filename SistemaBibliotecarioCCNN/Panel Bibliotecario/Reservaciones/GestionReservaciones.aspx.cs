using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Reservaciones
{
    public partial class GestionReservaciones : System.Web.UI.Page
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
            GdvReservacionesSinEntregar.DataSource = ReservacionBLL.ShowAllReservaciones();
            GdvReservacionesSinEntregar.DataBind();
        }

        protected void LnkBtnEntregar_Command(object sender, CommandEventArgs e)
        {

            string Id = e.CommandArgument.ToString();

            Response.Redirect("Reservacion_Prestamo.aspx?Id=" + Id);

        }
    }
}