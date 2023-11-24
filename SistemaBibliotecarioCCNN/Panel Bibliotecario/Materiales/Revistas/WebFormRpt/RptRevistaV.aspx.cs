using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Revistas.WebFormRpt
{
    public partial class RptRevistaV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {



            }
        }

        protected void DdlAutor_PreRender(object sender, EventArgs e)
        {
            DdlAutor.DataSource = AutorBLL.ShowAutor();
            DdlAutor.DataTextField = "Nombre Autor";
            DdlAutor.DataValueField = "idAutor";
            DdlAutor.DataBind();
        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.DataBind();

        }

        protected void DdlClasificacion2_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion2.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion2.DataTextField = "Clasificacion";
            DdlClasificacion2.DataValueField = "idClasificacion";
            DdlClasificacion2.DataBind();
        }

        protected void DdlAutor2_PreRender(object sender, EventArgs e)
        {
            DdlAutor2.DataSource = AutorBLL.ShowAutor();
            DdlAutor2.DataTextField = "Nombre Autor";
            DdlAutor2.DataValueField = "idAutor";
            DdlAutor2.DataBind();
        }

        protected void BtnCrearReportexAutor_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVRevistaVarios.SizeToReportContent = true;
            RptVRevistaVarios.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Revistas/Reportes/RptLiRevistaxAu.rdlc");
            RptVRevistaVarios.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsLiRevistaxAu", RevistaBLL.RptRevistaxAutor(Convert.ToInt32(DdlAutor.SelectedValue)));
            RptVRevistaVarios.LocalReport.DataSources.Add(RptDts);
            RptVRevistaVarios.LocalReport.Refresh();
        }

        protected void BtnReportexClasificacion_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVRevistaVarios.SizeToReportContent = true;
            RptVRevistaVarios.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Revistas/Reportes/RptRevistaxCla.rdlc");
            RptVRevistaVarios.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DstRevistaxCla", RevistaBLL.RptRevistaxCla(Convert.ToInt32(DdlClasificacion.SelectedValue)));
            RptVRevistaVarios.LocalReport.DataSources.Add(RptDts);
            RptVRevistaVarios.LocalReport.Refresh();
        }

        protected void BtnClayPro_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVRevistaVarios.SizeToReportContent = true;
            RptVRevistaVarios.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Revistas/Reportes/RptRevistaxAuyCla.rdlc");
            RptVRevistaVarios.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("'DtsRevistaxAuyCla", RevistaBLL.RptRevistaxAuyCla(Convert.ToInt32(DdlAutor2.SelectedValue), Convert.ToInt32(DdlClasificacion2.SelectedValue)));
            RptVRevistaVarios.LocalReport.DataSources.Add(RptDts);
            RptVRevistaVarios.LocalReport.Refresh();
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GestionRevista.aspx");
        }
    }
}