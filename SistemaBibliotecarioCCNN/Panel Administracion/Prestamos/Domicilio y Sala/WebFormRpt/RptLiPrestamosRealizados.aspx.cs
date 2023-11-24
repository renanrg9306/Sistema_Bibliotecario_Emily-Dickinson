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
    public partial class RptLiPrestamosRealizados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DdlPrestadoPor_PreRender(object sender, EventArgs e)
        {
            DdlPrestadoPor.DataSource = BibliotecarioBLL.ShowEmpleados();
            DdlPrestadoPor.DataTextField = "Nombre Completo";
            DdlPrestadoPor.DataValueField = "idEmpleado";
            DdlPrestadoPor.DataBind();
        }

        protected void DdlPrestado_por_PreRender(object sender, EventArgs e)
        {
            DdlPrestado_por.DataSource = BibliotecarioBLL.ShowEmpleados();
            DdlPrestado_por.DataTextField = "Nombre Completo";
            DdlPrestado_por.DataValueField = "idEmpleado";
            DdlPrestado_por.DataBind();
        }

        protected void BtnEmpleado_Date_Click(object sender, EventArgs e)
        {
            RptPrestamosRealizados.SizeToReportContent = true;
            RptPrestamosRealizados.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptPrestamoxRangoFecha.rdlc");
            RptPrestamosRealizados.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsPrestamoRF", PrestamoBLL.RptPrestamosRealizados(Convert.ToDateTime("1/1/1753"), Convert.ToDateTime(TxtFecha.Text), Convert.ToInt32(DdlPrestado_por.SelectedValue)));
            RptPrestamosRealizados.LocalReport.DataSources.Add(RptDts);
            RptPrestamosRealizados.LocalReport.Refresh();
        }

        protected void BtnReportePrestadoPor_Click(object sender, EventArgs e)
        {
            RptPrestamosRealizados.SizeToReportContent = true;
            RptPrestamosRealizados.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptPrestamoxRangoFecha.rdlc");
            RptPrestamosRealizados.LocalReport.DataSources.Clear();
            ReportDataSource RptDts = new ReportDataSource("DtsPrestamoRF", PrestamoBLL.RptPrestamosRealizados(Convert.ToDateTime("1/1/1753"), Convert.ToDateTime("1/1/1753"), Convert.ToInt32(DdlPrestadoPor.SelectedValue)));
            RptPrestamosRealizados.LocalReport.DataSources.Add(RptDts);
            RptPrestamosRealizados.LocalReport.Refresh();
        }

        protected void BtnReportexRangoFecha_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtSegundaFecha.Text) >= Convert.ToDateTime(TxtPrimeraFecha.Text))
            {
                RptPrestamosRealizados.SizeToReportContent = true;
                RptPrestamosRealizados.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptPrestamoxRangoFecha.rdlc");
                RptPrestamosRealizados.LocalReport.DataSources.Clear();
                ReportDataSource RptDts = new ReportDataSource("DtsPrestamoRF", PrestamoBLL.RptPrestamosRealizados(Convert.ToDateTime(TxtPrimeraFecha.Text), Convert.ToDateTime(TxtSegundaFecha.Text), 0));
                RptPrestamosRealizados.LocalReport.DataSources.Add(RptDts);
                RptPrestamosRealizados.LocalReport.Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('la segunda fecha ingresada es menor que la primera. Verifique e intente nuevamente','Error en fecha ingresada');", true);
            }
        }
           
    }
}