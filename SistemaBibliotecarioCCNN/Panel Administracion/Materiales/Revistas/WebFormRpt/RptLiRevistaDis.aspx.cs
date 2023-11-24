using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Revistas.WebFormRpt
{
    public partial class RptLiRevistaDis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptVLiRevistaDispo.SizeToReportContent = true;
                RptVLiRevistaDispo.LocalReport.ReportPath = MapPath("~/Panel Administracion/Materiales/Revistas/Reportes/RrptLiRevistaDis.rdlc");
                RptVLiRevistaDispo.LocalReport.DataSources.Clear();
                ReportDataSource RpDts = new ReportDataSource("DtsLiRevistaDis", RevistaBLL.ShowMaterialRevista());
                RptVLiRevistaDispo.LocalReport.DataSources.Add(RpDts);
                RptVLiRevistaDispo.LocalReport.Refresh();

            }
        }
    }
}