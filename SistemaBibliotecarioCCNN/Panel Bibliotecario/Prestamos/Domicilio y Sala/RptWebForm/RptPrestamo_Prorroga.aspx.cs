using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala.RptPrestamo
{
    public partial class RptPrestamo_Prorroga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnRptPrestamoProrroga_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtSegundaFecha.Text) >= Convert.ToDateTime(TxtPrimeraFecha.Text))
            {
                RptPrePro.SizeToReportContent = true;
                RptPrePro.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Prestamos/Domicilio y Sala/RptPrestamos/RptPrestamo_Prorroga.rdlc");
                RptPrePro.LocalReport.DataSources.Clear();
                ReportDataSource RptDts = new ReportDataSource("DtsPrePro", PrestamoBLL.RptPrePro(Convert.ToDateTime(TxtPrimeraFecha.Text), Convert.ToDateTime(TxtSegundaFecha.Text)));
                RptPrePro.LocalReport.DataSources.Add(RptDts);
                RptPrePro.LocalReport.Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('la segunda fecha ingresada es menor que la primera. Verifique e intente nuevamente','Error en fecha ingresada');", true);
            }
        }
    }
}