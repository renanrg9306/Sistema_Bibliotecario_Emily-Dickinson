using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario
{
    public partial class InicioSesionBibliotecario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnAcceder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BibliotecarioBLL.SesionBibliotecario(TxtCodUsuario.Text, TxtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                Session.Add("username", TxtCodUsuario.Text);
                Response.Redirect("~/Panel Bibliotecario/DefaultBibliotecario.aspx");
            }
            else {
                ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "MensajeError('Los datos ingresados no corresponde a ningún usuario en la base de datos','Error');", true);
            }


        }

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox1.Checked == true)
        //    {
        //        TxtPassword.TextMode = TextBoxMode.SingleLine;
        //    }
        //    else {

        //        TxtPassword.TextMode = TextBoxMode.Password;
        //    }
        //}

        
    }
}