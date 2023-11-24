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
    public partial class RptLiAllAB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RrpLiAubook.SizeToReportContent = true;
                RrpLiAubook.LocalReport.ReportPath = Server.MapPath("~/Panel Bibliotecario/Materiales/Audiobooks/Reportes/RptLiAu.rdlc");
                RrpLiAubook.LocalReport.DataSources.Clear();
                ReportDataSource DatasetLiAu = new ReportDataSource("DstLiAu", AudiobookBLL.ShowAudiobook());
                RrpLiAubook.LocalReport.DataSources.Add(DatasetLiAu);
                RrpLiAubook.LocalReport.Refresh();

            }
        }
    }
}