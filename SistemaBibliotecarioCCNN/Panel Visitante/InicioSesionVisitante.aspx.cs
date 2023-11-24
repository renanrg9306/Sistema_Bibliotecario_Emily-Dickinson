using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace SistemaBibliotecarioCCNN.Panel_Visitante
{
    public partial class InicioSesionVisitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLoginVistante_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = VisitanteBLL.SesionVisitante(TextCodUsuario.Text, TextContra.Text);
            if (dt.Rows.Count > 0)
            {
                Session.Add("username", TextCodUsuario.Text);
                Response.Redirect("DefaultVisitante.aspx");
            }
            else {
                ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "MensajeError('Los datos ingresados no corresponde a ningún usuario en la base de datos','Error');", true);
            }
            
        }
    }
}