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

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Nivel_Academico
{

    public partial class mNivelAcademico : System.Web.UI.Page
    {
        NivelAcademicoEntity oNivelAca = new NivelAcademicoEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (Request.QueryString["Id"] != null)
                {
                    oNivelAca = NivelAcademicoBLL.GetNivelAcaById(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtNivelAcademico.Text = oNivelAca.NivelAca;
                }

        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                oNivelAca.IdNivelAca = Convert.ToInt32(Request.QueryString["Id"]);
                oNivelAca.NivelAca = TxtNivelAcademico.Text;
                if (NivelAcademicoBLL.ActualizarNivelAca(oNivelAca))
                {
                    Response.Redirect("cNivelAcademico.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            





        }
    }
}