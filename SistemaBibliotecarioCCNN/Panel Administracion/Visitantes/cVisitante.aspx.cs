using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Entity;
namespace SistemaBibliotecarioCCNN.Panel_Administracion.Visitantes
{
    public partial class cVisitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbFecha.Text = DateTime.Now.ToShortDateString();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            VisitanteEntity oVisitante = new VisitanteEntity();
                oVisitante.ProgramEntity.IdProgram = Convert.ToInt32(DdlProgram.SelectedValue);
                oVisitante.Nombre = TxtNombresVisitante.Text;
                oVisitante.Apellido = TxtApellidosVisitante.Text;
                oVisitante.Cedula = TxtCedulaVisitante.Text;
                oVisitante.Edad = Convert.ToInt16(TxtEdadVisitante.Text);
                oVisitante.Direccion = TxtDireccionVisitante.Text;
                oVisitante.OcupacionEntity.IdOcupacion = Convert.ToInt32(DdlOcupacion.SelectedValue);
                oVisitante.Telefono = TxtNumero.Text;
                //oVisitante.IdVisitante = Convert.ToInt32(DdlOcupacion.SelectedValue);
                oVisitante.Email = TxtCorreo.Text;
                oVisitante.Genero = Convert.ToChar(ddlGenero.SelectedValue);
                oVisitante.FechaIngreso = Convert.ToDateTime(LbFecha.Text);
                oVisitante.Prestado = 0;
                oVisitante.Estado = true;
              
                    oVisitante.IdVisitante = VisitanteBLL.InsertVisitante(oVisitante);
                    oVisitante.CodUsuario = VisitanteBLL.GenerarCarnetVisitante(Convert.ToDateTime(LbFecha.Text), oVisitante.IdVisitante, Convert.ToChar(ddlGenero.SelectedValue));
                    oVisitante.AutenticacionEntity.CodUsuario = oVisitante.CodUsuario;
                    oVisitante.AutenticacionEntity.Password = VisitanteBLL.CreatePassowrd(oVisitante.Telefono);
                    if (VisitanteBLL.InsertAutenticacionVisitante(oVisitante))
                    {
                        string DatosAcceso = VisitanteBLL.RecoverPasswordVisitante(oVisitante.CodUsuario, oVisitante.Email);
                        EnvioCorreoBLL.EnviarCorreo("Bienvenido a SISBIPRE-CCNN Biblioteca Emily Dickinson", DatosAcceso, oVisitante.Email);
                        Response.Redirect("GestionVisitante.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Validaciones", "MensajeError('Error al registrar');", true);
                    }
      }

        protected void BtnGuardarProgramAtajo_Click(object sender, EventArgs e)
        {
            ProgramEntity oProgram = new ProgramEntity();
            oProgram.Descripcion = TxtProgram.Text;
            if (ProgramBLL.InsertProgram(oProgram))
            {
                TxtProgram.Text = "";
            }
        }

        protected void DdlProgram_PreRender(object sender, EventArgs e)
        {
            DdlProgram.DataSource = ProgramBLL.ShowProgram();
            DdlProgram.DataTextField = "Descripcion";
            DdlProgram.DataValueField = "idProgram";
            DdlProgram.DataBind();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionVisitante.aspx");
        }

        protected void BtnGuardarOcupacionAtajo_Click(object sender, EventArgs e)
        {
            OcupacionEntity oOcupacion = new OcupacionEntity();
            oOcupacion.Ocupacion = TxtOcupacion.Text;
            oOcupacion.Estado = true;
            if (OcupacionBLL.InsertOcupacion(oOcupacion))
            {
                TxtOcupacion.Text = "";
            }
        }

        protected void DdlOcupacion_PreRender(object sender, EventArgs e)
        {
            DdlOcupacion.DataSource = OcupacionBLL.ShowOcupacion();
            DdlOcupacion.DataTextField = "Ocupacion";
            DdlOcupacion.DataValueField = "idOcupacion";
            DdlOcupacion.DataBind();
        }

        protected void BtnGuardarProgramAtajo_Click1(object sender, EventArgs e)
        {
            ProgramEntity oProgram = new ProgramEntity();
            oProgram.Descripcion = TxtProgram.Text;
            if (ProgramBLL.InsertProgram(oProgram))
            {
                TxtProgram.Text = "";
            }
        }
    }
}