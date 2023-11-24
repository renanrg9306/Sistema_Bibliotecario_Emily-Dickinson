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
    public partial class RptAllPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptListarTodasPeliculas.SizeToReportContent = true;
                RptListarTodasPeliculas.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Peliculas/Reportes/RptListAllPeliculas.rdlc");
                RptListarTodasPeliculas.LocalReport.DataSources.Clear();
                ReportDataSource Dts = new ReportDataSource("DstLiAllPeliculas", PeliculaBLL.ShowPelicula());
                RptListarTodasPeliculas.LocalReport.DataSources.Add(Dts);
                RptListarTodasPeliculas.LocalReport.Refresh();
            }
        }
    }
}