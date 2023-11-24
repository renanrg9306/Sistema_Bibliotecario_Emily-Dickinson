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
    public partial class PrestamosEntregados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GdvPrestamosEntregados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GdvPrestamosEntregados_PreRender(object sender, EventArgs e)
        {
            GdvPrestamosEntregados.DataSource = PrestamoBLL.ShowPrestamosEntregados(VisitanteBLL.GetIdVisitante(Session["username"].ToString()));
            GdvPrestamosEntregados.DataBind();
        }
    }
}