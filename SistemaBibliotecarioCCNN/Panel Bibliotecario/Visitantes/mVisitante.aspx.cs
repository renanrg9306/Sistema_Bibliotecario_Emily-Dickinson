using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Visitantes
{
    public partial class mVisitante : System.Web.UI.Page
    {
        VisitanteEntity oVisitante = new VisitanteEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oVisitante = VisitanteBLL.GetVisitante(Convert.ToInt32(Request.QueryString["Id"]));
                    LbIdVisitante.Text = oVisitante.IdVisitante.ToString();
                    LbIdUsuario.Text = oVisitante.AutenticacionEntity.IdUsuario.ToString();
                    TxtNombresV.Text = oVisitante.Nombre;
                    TxtApellidosV.Text = oVisitante.Apellido;
                    TxtCedulaV.Text = oVisitante.Cedula;
                    TxtDireccionV.Text = oVisitante.Direccion;
                    TxtEdadV.Text = oVisitante.Edad.ToString();
                    TxtEmail.Text = oVisitante.Email;
                    TxtCodUsuario.Text = oVisitante.AutenticacionEntity.CodUsuario;
                    TxtPassword.Text = oVisitante.AutenticacionEntity.Password;
                    TxtTelefonoV.Text = oVisitante.Telefono;



                }
            }
        }
        protected void DdlOcupacion_PreRender(object sender, EventArgs e)
        {
            DdlOcupacion.DataSource = OcupacionBLL.ShowOcupacion();
            DdlOcupacion.DataTextField = "Ocupacion";
            DdlOcupacion.DataValueField = "idOcupacion";
            DdlOcupacion.DataBind();
        }

        protected void DdlProgram_PreRender(object sender, EventArgs e)
        {
            DdlProgram.DataSource = ProgramBLL.ShowProgram();
            DdlProgram.DataTextField = "Descripcion";
            DdlProgram.DataValueField = "idProgram";
            DdlProgram.DataBind();
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

        protected void BtnActualizarV_Click(object sender, EventArgs e)
        {
            //oVisitante.Nombre   = TxtNombresV.Text;
            //oVisitante.Apellido = TxtApellidosV.Text;
            oVisitante.IdVisitante = Convert.ToInt32(LbIdVisitante.Text);
            oVisitante.Cedula = TxtCedulaV.Text;
            oVisitante.Direccion = TxtDireccionV.Text;
            oVisitante.Edad = Convert.ToInt16(TxtEdadV.Text);
            oVisitante.Telefono = TxtTelefonoV.Text;
            oVisitante.Email = TxtEmail.Text;
            oVisitante.OcupacionEntity.IdOcupacion = Convert.ToInt32(DdlOcupacion.SelectedValue);
            oVisitante.ProgramEntity.IdProgram = Convert.ToInt32(DdlProgram.SelectedValue);
            if (VisitanteBLL.UpdateVisitante(oVisitante))
            {
                Response.Redirect("GestionVisitantes.aspx");
            }

        }

        protected void BtnActualizaClaveAcessoV_Click(object sender, EventArgs e)
        {
            oVisitante.AutenticacionEntity.IdUsuario = Convert.ToInt32(LbIdUsuario.Text);
            oVisitante.AutenticacionEntity.Password = TxtPassword.Text;
            if (VisitanteBLL.UpdatePassowrd(oVisitante))
            {
                Response.Redirect("GestionVisitantes.aspx");
            }
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

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionVisitantes.aspx");
        }
    }
}