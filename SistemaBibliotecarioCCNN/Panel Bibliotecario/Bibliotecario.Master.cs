using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario
{
    public partial class Bibliotecario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                LbUser.Text = BibliotecarioBLL.GetDatosBibliotByCodUsuario(Convert.ToString(Session["username"]));
            }
            else
            {
                Response.Redirect("~/Panel Bibliotecario/InicioSesionBibliotecario.aspx");
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

            catch(Exception ex)
            {
                throw ex;
            
            }
        }

        protected void BtnActualizarDatos_Click(object sender, EventArgs e)
        {
            int id = BibliotecarioBLL.GetIdBibliotecario(Convert.ToString(Session["username"]));
            Response.Redirect("~/Panel Bibliotecario/mBibliotecario.aspx?Id=" + id);
        }
    }
}