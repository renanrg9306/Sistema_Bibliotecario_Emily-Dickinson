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
    public partial class cClasificacion : System.Web.UI.Page
    {
        ClasificacionEntity oCla = new ClasificacionEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            oCla.Clasificacion = TxtClasificacion.Text;
            oCla.Estado = true;
            oCla.Descripcion = TxtDescripcion.Text;

            if (ClasificacionBLL.InsertClasificacion(oCla)>0)
            {
                Response.Redirect("GestionClasificacion.aspx");
            }
        
        }

        protected void BntCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Panel Administracion/Administrador/DefaultAdmins.aspx");
        }

       
    }
}