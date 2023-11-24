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
    public partial class RptListarPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
            RptListPeDis.SizeToReportContent = true;
            RptListPeDis.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Peliculas/Reportes/RptLiPeliculas.rdlc");
            RptListPeDis.LocalReport.DataSources.Clear();
            ReportDataSource dts = new ReportDataSource("DstLiPelicula", PeliculaBLL.ShowMaterialPelicula());
            RptListPeDis.LocalReport.DataSources.Add(dts);
            RptListPeDis.LocalReport.Refresh();
            }
        }

    }
}