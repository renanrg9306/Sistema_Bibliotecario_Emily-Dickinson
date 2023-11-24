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
    public partial class mAdmin : System.Web.UI.Page
    {
        AdministradorEntity oAdmin = new AdministradorEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oAdmin = AdministradorBLL.GetAllDataAdmin(Convert.ToInt32(Request.QueryString["Id"]));
                    LbId.Text =  oAdmin.IdAdministador.ToString();
                    LbIdEmpleado.Text = oAdmin.IdEmpleado.ToString();
                    LbIdUsuario.Text = oAdmin.AutenticacionEntity.IdUsuario.ToString();
                    TxtNombres.Text = oAdmin.Nombres;
                    TxtApellidos.Text = oAdmin.Apellidos;
                    TxtCedula.Text = oAdmin.Cedula;
                    TxtEdad.Text = oAdmin.Edad.ToString();
                    TxtDireccion.Text = oAdmin.Direccion;
                    TxtTelefono.Text = oAdmin.Telefono;
                    TxtCorreo.Text = oAdmin.Correo;           
                    TxtCodUsuario.Text = oAdmin.AutenticacionEntity.CodUsuario;
                    TxtPassword.Text = oAdmin.AutenticacionEntity.Password;


                }
                
            }
        }

        protected void DdlNivelAca_PreRender(object sender, EventArgs e)
        {
            DdlNivelAca.DataSource = NivelAcademicoBLL.ShowNivelAcademico();
            DdlNivelAca.DataTextField = "Descripcion";
            DdlNivelAca.DataValueField = "idNivelAca";
            DdlNivelAca.DataBind();
            ListItem item = DdlNivelAca.Items.FindByValue(oAdmin.NivelAcademicoEntity.IdNivelAca.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
          
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                oAdmin.IdEmpleado = Convert.ToInt32(LbIdEmpleado.Text);
                oAdmin.IdAdministador = Convert.ToInt32(LbId.Text);
                oAdmin.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(DdlNivelAca.SelectedValue);
                oAdmin.Nombres = TxtNombres.Text;
                oAdmin.Apellidos = TxtApellidos.Text;
                oAdmin.Cedula = TxtCedula.Text;
                oAdmin.Edad = Convert.ToInt16(TxtEdad.Text);
                oAdmin.Direccion = TxtDireccion.Text;
                oAdmin.Correo = TxtCorreo.Text;
                oAdmin.Telefono = TxtTelefono.Text;
                if (AdministradorBLL.VerificarCedulaAdmin(oAdmin.IdEmpleado, oAdmin.Cedula) == 0)
                {

                    if (AdministradorBLL.UpdateEmpleadoAdmin(oAdmin))
                    {
                        Response.Redirect("GestionAdmins.aspx");
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

        protected void BtnActualizaClaveAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                oAdmin.AutenticacionEntity.IdUsuario = Convert.ToInt32(LbIdUsuario.Text);
                oAdmin.AutenticacionEntity.Password = Convert.ToString(TxtPassword.Text);

                if (AdministradorBLL.UpdatePassowordAdmin(oAdmin))
                {
                    Response.Redirect("GestionAdmins.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnGuardarNivelAcademicoAtajo_Click(object sender, EventArgs e)
        {
            NivelAcademicoEntity oNA = new NivelAcademicoEntity();
            oNA.NivelAca = TxtNivelAca.Text;
            oNA.Estado = true;
            if (NivelAcademicoBLL.InsertNivelAca(oNA))
            {
                Response.Redirect(Request.RawUrl); 
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionAdmins.aspx");
        }
    }
}