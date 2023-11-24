using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Libros.WebFormRpt
{
    public partial class RptLiLibrosDis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptListarLibrosDisponibles.SizeToReportContent = true;
                RptListarLibrosDisponibles.LocalReport.ReportPath = Server.MapPath("~/Panel Bibliotecario/Materiales/Libros/Reportes/RptLiLibrosDis.rdlc");
                RptListarLibrosDisponibles.LocalReport.DataSources.Clear();
                ReportDataSource Dts = new ReportDataSource("DstLiLibrosDis", LibroBLL.ShowMateriaLibro());
                RptListarLibrosDisponibles.LocalReport.DataSources.Add(Dts);
                RptListarLibrosDisponibles.LocalReport.Refresh();
            }
        }
    }
}