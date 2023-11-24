using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Clasificacion
{
    public partial class GestionClasificacion : System.Web.UI.Page
    {
        ClasificacionEntity oCla = new ClasificacionEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void CargarDatosGdv()
        {
            GdvClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            GdvClasificacion.DataBind();
        }
        protected void GdvClasificacion_PreRender(object sender, EventArgs e)
        {
            if (TxtBusquedaClasificacion.Text != "")
            {
                GdvClasificacion.DataSource = ClasificacionBLL.SearchClasificacion(TxtBusquedaClasificacion.Text);
                GdvClasificacion.DataBind();
            }
            else
            {
                CargarDatosGdv();
            }

        }
        protected void LnkBtnActualizar_Command(object sender, CommandEventArgs e)
        {
            GdvClasificacion.Columns[1].Visible = true;
            LbIdClasificacion.Text = e.CommandArgument.ToString();
            GdvClasificacion.Columns[1].Visible = false;
            Response.Redirect("mClasificacion.aspx?Id=" + LbIdClasificacion.Text);
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            GdvClasificacion.Columns[1].Visible = true;
            LbIdClasificacion.Text = e.CommandArgument.ToString();
            GdvClasificacion.Columns[1].Visible = false;
            oCla.IdClasificacion = Convert.ToInt32(LbIdClasificacion.Text);
            if (ClasificacionBLL.DeleteClasificacion(oCla))
            {
                Response.Redirect("GestionClasificacion.aspx");
            }
        }

        protected void GdvClasificacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvClasificacion.PageIndex = e.NewPageIndex;
            DataBind();
        }

        protected void LinkBtnNnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cClasificacion.aspx");
        }
    }
}