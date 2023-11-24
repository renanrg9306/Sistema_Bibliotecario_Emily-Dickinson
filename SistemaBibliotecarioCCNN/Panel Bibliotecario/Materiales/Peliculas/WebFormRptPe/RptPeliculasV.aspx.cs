using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Peliculas.WebFormRptPe
{
    public partial class RptPeliculasV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DdlProtagonista_PreRender(object sender, EventArgs e)
        {
            DdlProtagonista.DataSource = ProtagonistaBLL.ShowProtagonista();
            DdlProtagonista.DataTextField = "Nombre Protagonista";
            DdlProtagonista.DataValueField = "idProtagonista";
            DdlProtagonista.DataBind();
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

        protected void DdlProtagonista2_PreRender(object sender, EventArgs e)
        {
            DdlProtagonista2.DataSource = ProtagonistaBLL.ShowProtagonista();
            DdlProtagonista2.DataTextField = "Nombre Protagonista";
            DdlProtagonista2.DataValueField = "idProtagonista";
            DdlProtagonista2.DataBind();
        }

        protected void BtnCrearReportexProtagonista_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVReportesPelicuaV.SizeToReportContent = true;
            RptVReportesPelicuaV.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Peliculas/Reportes/RptLiPelxPro.rdlc");
            RptVReportesPelicuaV.LocalReport.DataSources.Clear();
            ReportDataSource Dts = new ReportDataSource("DstLiPexPro", PeliculaBLL.ReportePeliculaxProtagonista(Convert.ToInt32(DdlProtagonista.SelectedValue)));
            RptVReportesPelicuaV.LocalReport.DataSources.Add(Dts);
            RptVReportesPelicuaV.LocalReport.Refresh();
        }

        protected void BtnReportexClasificacion_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVReportesPelicuaV.SizeToReportContent = true;
            RptVReportesPelicuaV.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Peliculas/Reportes/RptLiPexCla.rdlc");
            RptVReportesPelicuaV.LocalReport.DataSources.Clear();
            ReportDataSource Dts = new ReportDataSource("DtsLiPexCla", PeliculaBLL.ReportePeliculaxClasificacion(Convert.ToInt32(DdlClasificacion.SelectedValue)));
            RptVReportesPelicuaV.LocalReport.DataSources.Add(Dts);
            RptVReportesPelicuaV.LocalReport.Refresh();
        }

        protected void BtnClayPro_Click(object sender, EventArgs e)
        {
            BtnRegresar.Visible = true;
            RptVReportesPelicuaV.SizeToReportContent = true;
            RptVReportesPelicuaV.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Peliculas/Reportes/RptLiPexClayPro.rdlc");
            RptVReportesPelicuaV.LocalReport.DataSources.Clear();
            ReportDataSource Dts = new ReportDataSource("DstLiPexClayAu", PeliculaBLL.ReportePexClayPro(Convert.ToInt32(DdlClasificacion2.SelectedValue), Convert.ToInt32(DdlProtagonista2.SelectedValue)));
            RptVReportesPelicuaV.LocalReport.DataSources.Add(Dts);
            RptVReportesPelicuaV.LocalReport.Refresh();

        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GestionPeliculas_Bibliotecario.aspx");
        }

    }
}