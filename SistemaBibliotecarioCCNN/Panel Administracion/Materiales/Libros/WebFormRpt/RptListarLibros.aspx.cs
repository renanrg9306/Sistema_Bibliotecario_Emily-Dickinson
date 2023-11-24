using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros.WebFormRpt
{
    public partial class RptListarLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptListarLibro.SizeToReportContent = true;
                RptListarLibro.LocalReport.ReportPath = Server.MapPath("~/Panel Administracion/Materiales/Libros/Reportes/RptLiLibros.rdlc");
                RptListarLibro.LocalReport.DataSources.Clear();
                ReportDataSource DstLiLibro = new ReportDataSource("DstLiLibros", LibroBLL.ShowLibros());
                RptListarLibro.LocalReport.DataSources.Add(DstLiLibro);
                RptListarLibro.LocalReport.Refresh();
                
            }
        }
    }
}