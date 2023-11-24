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
    public partial class RptHistorialPrestamoVisitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DdlVisitante_PreRender(object sender, EventArgs e)
        {
            DdlVisitante.DataSource = VisitanteBLL.ShowVisitante();
            DdlVisitante.DataTextField = "Nombre Completo";
            DdlVisitante.DataValueField = "idVisitante";
            DdlVisitante.DataBind();

        }

        protected void BtnRptPrestamosVisitante_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtSegundaFecha.Text) > Convert.ToDateTime(TxtPrimeraFecha.Text))
            {
                RptHisPreVi.SizeToReportContent = true;
                RptHisPreVi.LocalReport.ReportPath = MapPath("~/Panel Administracion/Prestamos/Domicilio y Sala/RptPrestamos/RptHisPreVisitante.rdlc");
                RptHisPreVi.LocalReport.DataSources.Clear();
                ReportDataSource RptDts = new ReportDataSource("DtsHistPreVi", PrestamoBLL.RptHistorialVisitante(Convert.ToDateTime(TxtPrimeraFecha.Text), Convert.ToDateTime(TxtSegundaFecha.Text), Convert.ToInt32(DdlVisitante.SelectedValue)));
                RptHisPreVi.LocalReport.DataSources.Add(RptDts);
                RptHisPreVi.LocalReport.Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('la segunda fecha ingresada es menor que la primera. Verifique e intente nuevamente','Error en fecha ingresada');", true);
            
            }
        }
    }
}