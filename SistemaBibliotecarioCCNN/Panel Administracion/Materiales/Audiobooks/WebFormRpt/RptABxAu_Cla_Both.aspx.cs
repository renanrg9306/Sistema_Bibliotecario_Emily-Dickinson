using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Audiobooks.WebFormRpt
{
    public partial class RptABxAu_Cla_Both : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
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
            RptABxAutor_Cla_Both.SizeToReportContent = true;
            RptABxAutor_Cla_Both.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Audiobooks/Reportes/RptABByAu_Cla.rdlc");
            RptABxAutor_Cla_Both.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsABByAu_Cla", AudiobookBLL.RptABByClas_Autor(Convert.ToInt32(DdlAutor.SelectedValue), 0));
            RptABxAutor_Cla_Both.LocalReport.DataSources.Add(RptDts);
            RptABxAutor_Cla_Both.LocalReport.Refresh();
            
            
        }

        protected void BtnReportexClasificacion_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptABxAutor_Cla_Both.SizeToReportContent = true;
            RptABxAutor_Cla_Both.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Audiobooks/Reportes/RptABByAu_Cla.rdlc");
            RptABxAutor_Cla_Both.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsABByAu_Cla", AudiobookBLL.RptABByClas_Autor(0,Convert.ToInt32(DdlClasificacion.SelectedValue)));
            RptABxAutor_Cla_Both.LocalReport.DataSources.Add(RptDts);
            RptABxAutor_Cla_Both.LocalReport.Refresh();
        }

        protected void BtnClayAu_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptABxAutor_Cla_Both.SizeToReportContent = true;
            RptABxAutor_Cla_Both.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Audiobooks/Reportes/RptABByAu_Cla.rdlc");
            RptABxAutor_Cla_Both.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsABByAu_Cla", AudiobookBLL.RptABByClas_Autor(Convert.ToInt32(DdlAutor2.SelectedValue), Convert.ToInt32(DdlClasificacion2.SelectedValue)));
            RptABxAutor_Cla_Both.LocalReport.DataSources.Add(RptDts);
            RptABxAutor_Cla_Both.LocalReport.Refresh();
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GestionAudiobooks.aspx");
        }
    }
}