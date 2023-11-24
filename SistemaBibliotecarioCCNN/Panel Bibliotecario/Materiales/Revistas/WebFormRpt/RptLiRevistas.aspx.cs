using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Revistas.WebFormRpt
{
    public partial class RptLiRevistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptVListarRevistas.SizeToReportContent = true;
                RptVListarRevistas.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Materiales/Revistas/Reportes/RptLiRevista.rdlc");
                RptVListarRevistas.LocalReport.DataSources.Clear();
                ReportDataSource Rdts = new ReportDataSource("DtsLiRevista", RevistaBLL.ShowRevista());
                RptVListarRevistas.LocalReport.DataSources.Add(Rdts);
                RptVListarRevistas.LocalReport.Refresh();

            }
        }
    }
}