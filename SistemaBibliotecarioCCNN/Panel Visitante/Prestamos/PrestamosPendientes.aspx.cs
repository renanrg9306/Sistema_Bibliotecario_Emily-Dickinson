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
    public partial class PrestamosPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GdvPrestamosPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GdvPrestamosPendientes_PreRender(object sender, EventArgs e)
        {
            GdvPrestamosPendientes.DataSource = PrestamoBLL.ShowPrestamosPendientes(VisitanteBLL.GetIdVisitante(Session["username"].ToString()));
            GdvPrestamosPendientes.DataBind();
        }

      
    }
}