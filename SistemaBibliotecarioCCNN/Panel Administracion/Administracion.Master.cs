using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class Administracion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Header.DataBind();
            if (Session["username"] != null)
            {
                LbUser.Text = AdministradorBLL.GetDatosAdminByCodUsuario(Convert.ToString(Session["username"]));
            }
            else
            {
                Response.Redirect("~/Panel Administracion/InicioSesionAdmin.aspx");
            }


            
        }

        protected void BtnCerraSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                {
                    Session.Remove("username");
                    Response.Redirect("~/Default.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnActualizarDatos_Click(object sender, EventArgs e)
        {
            int id = AdministradorBLL.GetIdAminByCodUsuario(Convert.ToString(Session["username"]));
            Response.Redirect("~/Panel Administracion/Administrador/mAdmin.aspx?Id=" + id);
        }   
    }
}