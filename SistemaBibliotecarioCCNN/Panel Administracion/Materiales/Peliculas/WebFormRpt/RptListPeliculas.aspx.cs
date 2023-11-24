using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;


namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Peliculas.WebFormRpt
{
    public partial class RptListPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            RptListAllPelicula.SizeToReportContent = true;
            RptListAllPelicula.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Peliculas/Reportes/RptListAllPeliculas.rdlc");
            RptListAllPelicula.LocalReport.DataSources.Clear();
            ReportDataSource Dts = new ReportDataSource("DstLiAllPeliculas",  PeliculaBLL.ShowPelicula());
            RptListAllPelicula.LocalReport.DataSources.Add(Dts);
            RptListAllPelicula.LocalReport.Refresh();
            }
        }
    }
}