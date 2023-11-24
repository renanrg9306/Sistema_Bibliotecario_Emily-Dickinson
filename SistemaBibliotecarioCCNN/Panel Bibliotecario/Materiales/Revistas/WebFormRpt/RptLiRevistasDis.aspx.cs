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
    public partial class RptLiRevistasDis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptVLiRevistaDispo.SizeToReportContent = true;
                RptVLiRevistaDispo.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Revistas/Reportes/RrptLiRevistaDis.rdlc");
                RptVLiRevistaDispo.LocalReport.DataSources.Clear();
                ReportDataSource RpDts = new ReportDataSource("DtsLiRevistaDis", RevistaBLL.ShowMaterialRevista());
                RptVLiRevistaDispo.LocalReport.DataSources.Add(RpDts);
                RptVLiRevistaDispo.LocalReport.Refresh();

            }
        }
    }
}