using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Entity;


namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class cAdim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LbFecha.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void CargarDropDownListNivelAca()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = NivelAcademicoBLL.ShowNivelAcademico();
                DdlistShowNivelAca.DataTextField = "Descripcion";
                DdlistShowNivelAca.DataValueField = "idNivelAca";
                DdlistShowNivelAca.DataSource = dt;
                DdlistShowNivelAca.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DdlistShowNivelAca_PreRender(object sender, EventArgs e)
        {
            CargarDropDownListNivelAca();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //TOMANDO LOS VALORES PARA LA TABLA EMPLEADO QUE PERTENECE AL ADMINISTRADOR
                AdministradorEntity oAdmin = new AdministradorEntity();
                oAdmin.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(DdlistShowNivelAca.SelectedValue);
                oAdmin.Nombres = TxtNombres.Text;
                oAdmin.Apellidos = TxtApellidos.Text;
                oAdmin.Cedula = TxtCedula.Text;
                oAdmin.Edad = Convert.ToInt16(TxtEdad.Text);
                oAdmin.Genero = Convert.ToChar(ddlGenero.SelectedValue);
                oAdmin.Direccion = TxtDireccion.Text;
                oAdmin.Telefono = TxtTelefono.Text;
                oAdmin.Correo = TxtEmail.Text;
                oAdmin.FechaIngreso = Convert.ToDateTime(LbFecha.Text);
                oAdmin.Estado = true;
                oAdmin.CantidadPrestamosRealizados = 0;
                if (AdministradorBLL.VerificarCedulaAdmin(oAdmin.IdEmpleado, oAdmin.Cedula) == 0)
                {
                    oAdmin.IdAdministador = AdministradorBLL.InsertAdmin(oAdmin);
                    oAdmin.CodUsuario = AdministradorBLL.CreateCodUsuarioAdmin(Convert.ToDateTime(LbFecha.Text), oAdmin.IdAdministador, Convert.ToChar(ddlGenero.SelectedValue));
                    oAdmin.AutenticacionEntity.CodUsuario = oAdmin.CodUsuario;
                    oAdmin.AutenticacionEntity.Password = AdministradorBLL.CreatePassword(oAdmin.Telefono);
                   
                    if (AdministradorBLL.AutenticacionAdministrador(oAdmin))
                    {
                        string DatosAcceso = AdministradorBLL.RecoverPasswordAdmin(oAdmin.CodUsuario, oAdmin.Correo);
                        EnvioCorreoBLL.EnviarCorreo("Bienvenido a SISBIPREM - CCNN", DatosAcceso , oAdmin.Correo);
                        Response.Redirect("GestionAdmins.aspx");
                    }
                }
                else { 
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('El numero de cedula ingresada pertenece a otro usuario','Error al registrar usuario');", true);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void LbtnNuevoNicalAca_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Panel Administracion/Nivel Academico/cNivelAcademico.aspx");
        }

        protected void BtnGuardarNivelAcademicoAtajo_Click(object sender, EventArgs e)
        {
            NivelAcademicoEntity oNA = new NivelAcademicoEntity();
            oNA.NivelAca = TxtNivelAca.Text;
            oNA.Estado = true;
            if (NivelAcademicoBLL.InsertNivelAca(oNA))
            {
                TxtNivelAca.Text = "";
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionAdmins.aspx");
        }

  
    
        
    }
}