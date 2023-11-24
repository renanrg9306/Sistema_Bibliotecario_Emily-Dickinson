using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Domicilio_y_Sala.WebFormRpt
{
    public partial class RptListarPrestamosRecepcionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DdlRecepcionadoPor_PreRender(object sender, EventArgs e)
        {
            DdlRecepcionadoPor.DataSource = BibliotecarioBLL.ShowEmpleados();
            DdlRecepcionadoPor.DataTextField = "Nombre Completo";
            DdlRecepcionadoPor.DataValueField = "Nombre Completo";
            DdlRecepcionadoPor.DataBind();
        }

        protected void DdlRecepcionado_por_PreRender(object sender, EventArgs e)
        {
            DdlRecepcionado_por.DataSource = BibliotecarioBLL.ShowEmpleados();
            DdlRecepcionado_por.DataTextField = "Nombre Completo";
            DdlRecepcionado_por.DataValueField = "Nombre Completo";
            DdlRecepcionado_por.DataBind();

        }

        protected void BtnRptRecepcionF_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtSegundaFecha.Text) > Convert.ToDateTime(TxtPrimeraFecha.Text))
            {
                RptMaRecepcionado.SizeToReportContent = true;
                RptMaRecepcionado.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptMaterialRecepcionado.rdlc");
                RptMaRecepcionado.LocalReport.DataSources.Clear();
                ReportDataSource RptDts = new ReportDataSource("DtsMaterialRecepcionado", PrestamoBLL.RptPrestamosRecepcionados(Convert.ToDateTime(TxtPrimeraFecha.Text), Convert.ToDateTime(TxtSegundaFecha.Text), string.Empty));
                RptMaRecepcionado.LocalReport.DataSources.Add(RptDts);
                RptMaRecepcionado.LocalReport.Refresh();
            }
            else {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('la segunda fecha ingresada es menor que la primera. Verifique e intente nuevamente','Error en fecha ingresada');", true);
            }
        }

        protected void BtnReporteRecepcionadoPor_Click(object sender, EventArgs e)
        {
            RptMaRecepcionado.SizeToReportContent = true;
            RptMaRecepcionado.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptMaterialRecepcionado.rdlc");
            RptMaRecepcionado.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsMaterialRecepcionado", PrestamoBLL.RptPrestamosRecepcionados(Convert.ToDateTime("1/1/1753"), Convert.ToDateTime("1/1/1753"),DdlRecepcionadoPor.SelectedValue.ToString()));
            RptMaRecepcionado.LocalReport.DataSources.Add(RptDts);
            RptMaRecepcionado.LocalReport.Refresh();
        }

        protected void BtnRecepcionado_Date_Click(object sender, EventArgs e)
        {
            RptMaRecepcionado.SizeToReportContent = true;
            RptMaRecepcionado.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptMaterialRecepcionado.rdlc");
            RptMaRecepcionado.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsMaterialRecepcionado", PrestamoBLL.RptPrestamosRecepcionados(Convert.ToDateTime("1/1/1753"), Convert.ToDateTime(TxtFecha.Text), DdlRecepcionado_por.SelectedValue.ToString()));
            RptMaRecepcionado.LocalReport.DataSources.Add(RptDts);
            RptMaRecepcionado.LocalReport.Refresh();

        }
    }
}