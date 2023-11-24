using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Visitante
{
    public partial class Visitante : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                LbUser.Text = VisitanteBLL.GetDatoUserByCodUsuario(Session["username"].ToString());
            }
            else
            {
                Response.Redirect("~/Panel Visitante/InicioSesionVisitante.aspx");
            }

           
        }

        protected void BtnCerraSesion2_ServerClick(object sender, EventArgs e)
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
    }
}