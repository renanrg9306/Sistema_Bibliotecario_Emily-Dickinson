using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Audiobooks.WebFormRpt
{
    public partial class RptLAu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RrpLiAubook.SizeToReportContent = true;
                RrpLiAubook.LocalReport.ReportPath = Server.MapPath("~/Panel Administracion/Materiales/Audiobooks/Reportes/RptLiAu.rdlc");
                RrpLiAubook.LocalReport.DataSources.Clear();
                ReportDataSource DatasetLiAu = new ReportDataSource("DstLiAu", AudiobookBLL.ShowAudiobook());
                RrpLiAubook.LocalReport.DataSources.Add(DatasetLiAu);
                RrpLiAubook.LocalReport.Refresh();

            }
        }
    }
}