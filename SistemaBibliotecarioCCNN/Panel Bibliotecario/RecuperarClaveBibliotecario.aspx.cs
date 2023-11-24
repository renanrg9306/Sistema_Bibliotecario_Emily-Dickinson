using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;


namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario
{
    public partial class RecuperarClaveBibliotecario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos(string Vacio)
        {
            TxtCodUsuario.Text = Vacio;
            TxtCorreo.Text = Vacio;

        }
        protected void BtnEnviarClave_Click(object sender, EventArgs e)
        {
            string Correo = TxtCorreo.Text;
            string CodUsuario = TxtCodUsuario.Text;

            string DatosUsuario = BibliotecarioBLL.RecoverAcountBibliotecario(CodUsuario, Correo);

            try
            {
                if (DatosUsuario != "")
                {
                    if (EnvioCorreoBLL.EnviarCorreo("Recuperación de Cuenta", DatosUsuario, Correo))
                    {
                        LimpiarCampos("");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "CorreoEnviado();", true);
                    }
                }
                else
                {
                    LimpiarCampos("");
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "MensajeError('Los datos ingresados no coiciden con los de la base de datos!Verifque e intente nuevamente','Correo no Enviado');", true);
                }
                   

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}