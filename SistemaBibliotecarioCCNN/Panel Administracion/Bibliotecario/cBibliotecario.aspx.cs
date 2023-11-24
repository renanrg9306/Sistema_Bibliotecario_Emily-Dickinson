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
    public partial class cBibliotecario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LbFecha.Text = DateTime.Now.ToShortDateString();
            } 
        }

        protected void DdlistShowNivelAca_PreRender(object sender, EventArgs e)
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            BibliotecarioEntity oBibliotecario = new BibliotecarioEntity();
            ////ASIGNANDO VALOR DE PERSONALES DE EMPLEADO DE UN BIBLIOTECARIO
            try
            {
                oBibliotecario.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(DdlistShowNivelAca.SelectedValue);
                oBibliotecario.Nombres = TxtNombres.Text;
                oBibliotecario.Apellidos = TxtApellidos.Text;
                oBibliotecario.Cedula = TxtCedula.Text;
                oBibliotecario.Edad = Convert.ToInt16(TxtEdad.Text);
                oBibliotecario.Genero = Convert.ToChar(ddlGenero.SelectedValue);
                oBibliotecario.Direccion = TxtDireccion.Text;
                oBibliotecario.Telefono = TxtTelefono.Text;
                oBibliotecario.Correo = TxtEmail.Text;
                oBibliotecario.FechaIngreso = Convert.ToDateTime(LbFecha.Text);
                oBibliotecario.Estado = true;
                oBibliotecario.CantidadPrestamosRealizados = 0;

                //INSERTANDO BIBLIOTECARIO

                if (BibliotecarioBLL.VerificarCedulaBibliotecario(oBibliotecario.IdEmpleado, oBibliotecario.Cedula) == 0)
                {
                    oBibliotecario.IdBibliotecario = BibliotecarioBLL.InsertBibliotecario(oBibliotecario);
                    oBibliotecario.AutenticacionEntity.CodUsuario = BibliotecarioBLL.CreateCodUsuarioBibliotecario(Convert.ToDateTime(LbFecha.Text), oBibliotecario.IdBibliotecario, Convert.ToChar(ddlGenero.SelectedValue));
                    oBibliotecario.AutenticacionEntity.Password = BibliotecarioBLL.CreatePassword(oBibliotecario.Telefono);
                    oBibliotecario.CodUsuario = oBibliotecario.AutenticacionEntity.CodUsuario;

                    if (BibliotecarioBLL.AutenticacionBibliotecario(oBibliotecario))
                    {
                        string DatoAcceso = BibliotecarioBLL.RecoverAcountBibliotecario(oBibliotecario.CodUsuario, oBibliotecario.Correo);
                        EnvioCorreoBLL.EnviarCorreo("Bienvenido a SISBIPREM - CCNN", DatoAcceso, oBibliotecario.Correo);
                        Response.Redirect("GestionBibliotecario.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('No puedo ser registrado, verifique e intente nuevamente','Error en registro');", true);
                    }
                }
                else
                {
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
            Response.Redirect("GestionBibliotecario.aspx");
        }
    }
}