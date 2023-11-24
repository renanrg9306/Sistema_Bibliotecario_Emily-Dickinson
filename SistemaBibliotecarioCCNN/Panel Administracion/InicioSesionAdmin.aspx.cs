using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class InicioSesionAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void BtnAcceder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
           
            try
            {
                dt = AdministradorBLL.SesionAdmin(TextCodUsuario.Text, TextContra.Text);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("username", TextCodUsuario.Text);
                    Response.Redirect("~/Panel Administracion/Administrador/DefaultAdmins.aspx");
                }
                else {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "MensajeError('Los datos de acceso no son correcto! Verifique e intente nuevamente','Datos incorrectos');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        

        }

        private void LoginAdmin()
        {
            
        }
    }
}