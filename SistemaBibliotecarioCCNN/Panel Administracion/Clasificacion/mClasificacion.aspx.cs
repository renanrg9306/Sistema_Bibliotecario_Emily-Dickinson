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
    public partial class mClasificacion : System.Web.UI.Page
    {
        ClasificacionEntity oCla = new ClasificacionEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oCla = ClasificacionBLL.GetClasificacioById(Convert.ToInt32(Request.QueryString["Id"]));
                    //LbIdClasificacion.Text = oCla.IdClasificacion.ToString();
                    TxtClasificacion.Text = oCla.Clasificacion;
                    TxtDescripcion.Text = oCla.Descripcion;
                }
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            oCla.IdClasificacion = Convert.ToInt32(Request.QueryString["Id"]);
            oCla.Clasificacion = TxtClasificacion.Text;
            oCla.Descripcion = TxtDescripcion.Text;

            if (ClasificacionBLL.UpdateClasificacion(oCla))
            {
                Response.Redirect("GestionClasificacion.aspx");
            }
        }
    }
}