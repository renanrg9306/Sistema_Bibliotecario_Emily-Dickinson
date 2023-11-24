using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario
{
    public partial class mBibliotecario : System.Web.UI.Page
    {
        BibliotecarioEntity oBiblio = new BibliotecarioEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oBiblio = BibliotecarioBLL.GetAllDataBibliotecario(Convert.ToInt32(Request.QueryString["Id"]));
                    LbIdEmpleado.Text = oBiblio.IdEmpleado.ToString();
                    LbIdBibliotecario.Text = oBiblio.IdBibliotecario.ToString();
                    LbIdUsuario.Text = oBiblio.AutenticacionEntity.IdUsuario.ToString();
                    TxtNombres.Text = oBiblio.Nombres;
                    TxtApellidos.Text = oBiblio.Apellidos;
                    TxtCedula.Text = oBiblio.Cedula;
                    TxtEdad.Text = oBiblio.Edad.ToString();
                    TxtDireccion.Text = oBiblio.Direccion;
                    TxtTelefono.Text = oBiblio.Telefono;
                    TxtCorreo.Text = oBiblio.Correo;
                    //DdlNivelAca.DataTextField = oBiblio.NivelAcademicoEntity.NivelAca;
                    TxtCodUsuario.Text = oBiblio.AutenticacionEntity.CodUsuario;
                    TxtPassword.Text = oBiblio.AutenticacionEntity.Password;

                }

            }
        }

         protected void DdlNivelAca_PreRender(object sender, EventArgs e)
        {
            DdlNivelAca.DataSource = NivelAcademicoBLL.ShowNivelAcademico();
            DdlNivelAca.DataTextField = "Descripcion";
            DdlNivelAca.DataValueField = "idNivelAca";
            DdlNivelAca.DataBind();
            ListItem item = DdlNivelAca.Items.FindByValue(oBiblio.NivelAcademicoEntity.IdNivelAca.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                oBiblio.IdEmpleado = Convert.ToInt32(LbIdEmpleado.Text);
                oBiblio.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(DdlNivelAca.SelectedValue);
                oBiblio.Nombres = TxtNombres.Text;
                oBiblio.Apellidos = TxtApellidos.Text;
                oBiblio.Cedula = TxtCedula.Text;
                oBiblio.Edad = Convert.ToInt16(TxtEdad.Text);
                oBiblio.Telefono = TxtTelefono.Text;
                oBiblio.Direccion = TxtDireccion.Text;
                oBiblio.Correo = TxtCorreo.Text;

                if (BibliotecarioBLL.UpdateEmpleadoBibliotecario(oBiblio))
                {
                    Response.Redirect("DefaultBibliotecario.aspx");
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
                oBiblio.AutenticacionEntity.IdUsuario = Convert.ToInt32(LbIdUsuario.Text);
                oBiblio.AutenticacionEntity.Password = TxtPassword.Text;
                if(BibliotecarioBLL.UpdatePasswordBibliotecario(oBiblio))
                {
                    Response.Redirect("DefaultBibliotecario.aspx");
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
            Response.Redirect("DefaultBibliotecario.aspx");
        }


    }

    
}