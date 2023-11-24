using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.AudioBooks.WebFormRpt
{
    public partial class RptLiaABDis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RptLiAuDis.SizeToReportContent = true;
                RptLiAuDis.LocalReport.ReportPath = Server.MapPath("~/Panel Bibliotecario/Materiales/Audiobooks/Reportes/RptLiAuDis.rdlc");
                RptLiAuDis.LocalReport.DataSources.Clear();
                ReportDataSource dstLiAuDis = new ReportDataSource("DstLiAuDis", AudiobookBLL.ShowMaterialAudiobook());
                RptLiAuDis.LocalReport.DataSources.Add(dstLiAuDis);
                RptLiAuDis.LocalReport.Refresh();
            }
        }
    }
}