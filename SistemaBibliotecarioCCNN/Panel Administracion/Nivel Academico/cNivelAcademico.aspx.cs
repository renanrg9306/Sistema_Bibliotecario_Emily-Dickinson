using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;
using System.Data.SqlClient;
using System.Data;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Administrador
{
    public partial class cNivelAcademico : System.Web.UI.Page
    {
        NivelAcademicoEntity oNivelAca = new NivelAcademicoEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            NivelAcademicoEntity oNivelAca = new NivelAcademicoEntity();
            //ASIGNANDO VALORES 
            oNivelAca.NivelAca = TxtNivelAca.Text;
            oNivelAca.Estado = true;

            if (NivelAcademicoBLL.InsertNivelAca(oNivelAca))
            {
                object refUrl = ViewState["RefUrl"];
                if (refUrl != null)
                    Response.Redirect((string)refUrl);
            }


        }

        //protected void LBtnModifcar_Command(object sender, CommandEventArgs e)
        //{
        //    GdvNivelAca.Columns[1].Visible = true;
        //    LbidNivelAca.Text = e.CommandArgument.ToString();
        //    string Id = LbidNivelAca.Text;
        //    Response.Redirect("mNivelAcademico.aspx?Id=" + Id);
        //}

        //protected void LBtnEliminar_Command(object sender, CommandEventArgs e)
        //{
        //    GdvNivelAca.Columns[1].Visible = true;
        //    LbidNivelAca.Text = e.CommandArgument.ToString();
        //    string Id = LbidNivelAca.Text;

        //    try
        //    {
        //        oNivelAca.IdNivelAca = Convert.ToInt32(Id);
        //        oNivelAca.Estado = false;
        //        if (NivelAcademicoBLL.DeleteNivelAca(oNivelAca))
        //        {
        //            Response.Redirect("cNivelAcademico.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}