﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class RecuperarClaveAdmin : System.Web.UI.Page
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

            string DatosUsuario = AdministradorBLL.RecoverPasswordAdmin(CodUsuario, Correo);

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