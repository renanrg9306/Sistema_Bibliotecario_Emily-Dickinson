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
    public partial class RptHistorialPreMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DdlMaterial_PreRender(object sender, EventArgs e)
        {
            DdlMaterial.DataSource = MaterialBLL.ShowMaterial();
            DdlMaterial.DataTextField = "Nombre";
            DdlMaterial.DataValueField = "idMaterial";
            DdlMaterial.DataBind();
        }

        protected void BtnRptHisPrestamoMaterial_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtSegundaFecha.Text) > Convert.ToDateTime(TxtPrimeraFecha.Text))
            {
                RptHistorialMaterial.SizeToReportContent = true;
                RptHistorialMaterial.LocalReport.ReportPath = MapPath("~/Panel Bibliotecario/Prestamos/Domicilio y Sala/RptPrestamos/RptHistPreMaterial.rdlc");
                RptHistorialMaterial.LocalReport.DataSources.Clear();
                ReportDataSource RptDts = new ReportDataSource("DtsHistPreMaterial", PrestamoBLL.RptHistorialMa(Convert.ToDateTime(TxtPrimeraFecha.Text), Convert.ToDateTime(TxtSegundaFecha.Text), Convert.ToInt32(DdlMaterial.SelectedValue)));
                RptHistorialMaterial.LocalReport.DataSources.Add(RptDts);
                RptHistorialMaterial.LocalReport.Refresh();
            }
        }
    }
}