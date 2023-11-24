using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Visitantes
{
    public partial class GestionVisitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridVisitante_PreRender(object sender, EventArgs e)
        {
            GridVisitante.DataSource = VisitanteBLL.ShowVisitante();
            GridVisitante.DataBind();
        }

        protected void LinkBtnNuevoVisitante_Click(object sender, EventArgs e)
        {
            Response.Redirect("cVisitante.aspx");
        }

        protected void LBtnModifcar_Command(object sender, CommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            Response.Redirect("mVisitante.aspx?Id=" + Id);
        }

        protected void LBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            VisitanteEntity oVisitante = new VisitanteEntity();
            oVisitante.IdVisitante = Convert.ToInt32(Id);
            if (VisitanteBLL.DeleteVisitante(oVisitante))
            {
                Response.Redirect("GestionVisitante.aspx");
            }
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteVisitante(string IdVisitante)
        {
            VisitanteEntity oVisitante = new VisitanteEntity();
            oVisitante.IdVisitante = Convert.ToInt32(IdVisitante);
            oVisitante.Estado = false;
            string msg = "";
            if (VisitanteBLL.DeleteVisitante(oVisitante))
            {
                msg = "OK";
            }
            else {
                msg = "Error";
            }
            return new { Result = msg };
        
        }

        protected void GridVisitante_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}