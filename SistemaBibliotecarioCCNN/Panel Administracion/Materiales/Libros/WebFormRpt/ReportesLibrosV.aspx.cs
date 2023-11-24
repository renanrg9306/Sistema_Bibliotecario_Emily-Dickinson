using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros.WebFormRpt
{
    public partial class ReportesLibrosV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void BtnCrearReportexAutor_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptLibroVarios.SizeToReportContent = true;
            RptLibroVarios.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Libros/Reportes/RptLibrosxAutor.rdlc");
            RptLibroVarios.LocalReport.DataSources.Clear();
            ReportDataSource DtsLiLibrosxAutor = new ReportDataSource("DstLiLibroxAutor", LibroBLL.ReporteLibroxAutor(Convert.ToInt32(DdlAutor.SelectedValue)));
            RptLibroVarios.LocalReport.DataSources.Add(DtsLiLibrosxAutor);
            RptLibroVarios.LocalReport.Refresh();
        }

        protected void BtnReportexClasificacion_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptLibroVarios.SizeToReportContent = true;
            RptLibroVarios.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Libros/Reportes/RptLiLibroxClasificacion.rdlc");
            RptLibroVarios.LocalReport.DataSources.Clear();
            ReportDataSource DtsLiLibrosxClasificacion = new ReportDataSource("DstLiLibroxClasificacion", LibroBLL.ReporteLibroxClasificacion(Convert.ToInt32(DdlClasificacion.SelectedValue)));
            RptLibroVarios.LocalReport.DataSources.Add(DtsLiLibrosxClasificacion);
            RptLibroVarios.LocalReport.Refresh();
        }

        protected void BtnClayAu_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptLibroVarios.SizeToReportContent = true;
            RptLibroVarios.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Libros/Reportes/RptLibroxClayAutor.rdlc");
            RptLibroVarios.LocalReport.DataSources.Clear();
            ReportDataSource DtsLiLibrosxClasificacionyAu = new ReportDataSource("DstLibroxClayAutor", LibroBLL.ReporteLibroxClayAu(Convert.ToInt32(DdlClasificacion2.SelectedValue), Convert.ToInt32(DdlAutor2.SelectedValue)));
            RptLibroVarios.LocalReport.DataSources.Add(DtsLiLibrosxClasificacionyAu);
            RptLibroVarios.LocalReport.Refresh();
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
    }
}