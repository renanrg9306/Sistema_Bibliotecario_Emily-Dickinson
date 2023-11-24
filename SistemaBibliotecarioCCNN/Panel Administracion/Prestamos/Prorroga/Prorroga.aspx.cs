using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Prorroga
{

    public partial class Prorroga : System.Web.UI.Page
    {

        
        EntregaPrestamoEntity oEP = new EntregaPrestamoEntity();
        ProrrogaPrestamoEntity oProrroga = new ProrrogaPrestamoEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtFechaDevolucion.Text = ProrrogaBLL.GetFechaDevolucion(Convert.ToInt32(Request.QueryString["Id"]));
            oProrroga = ProrrogaBLL.GetIdPrrogaC(Convert.ToInt32(Request.QueryString["Id"]));
            oEP = PrestamoBLL.GetCantidadPrestamo(Convert.ToInt32(Request.QueryString["Id"]));
            VerificarProrroga(oProrroga.CantidadProrroga);
        }

   
        protected void BtnDarProrroga_Click(object sender, EventArgs e)
        {
            try
            {     
                    if (oProrroga.CantidadProrroga == 1)
                    {
                        if (TxtDatePickerProrroga2.Text != "")
                        {

                            oProrroga.CantidadProrroga = 2;
                            oProrroga.Prorroga2 = Convert.ToDateTime(TxtDatePickerProrroga2.Text);

                            if (ProrrogaBLL.SegundaProrroga(oProrroga))
                            {
                                Response.Redirect("../Domicilio y Sala/GestionPrestamos.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('Fecha de segunda prorroga vacía. Verifique e intente nuevamente','Error en fecha ingresada');", true);
                        }
                    }
                    else
                        {

                           
                            //oProrroga.PrestamoEntity.IdPrestamo = oEP.IdPrestamo; 
                           
                            if (TxtDatePickerProrroga1.Text != "")
                            {
                                oProrroga.Prorroga1 = Convert.ToDateTime(TxtDatePickerProrroga1.Text);
                                oProrroga.CantidadProrroga = 1;
                                if (ProrrogaBLL.PrimerProrroga(oProrroga))
                                {
                                    Response.Redirect("../Domicilio y Sala/GestionPrestamos.aspx");
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeError('Fecha de primera prorroga vacía. Verifique e intente nuevamente','Error en fecha ingresada');", true);
                            }
                        }

          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void VerificarProrroga(int CantidadProrroga)
        {
                ProrrogaPrestamoEntity oPrimeraProrroga = new ProrrogaPrestamoEntity();
                ProrrogaPrestamoEntity oSegundaProrroga = new ProrrogaPrestamoEntity();
            if (CantidadProrroga == 1)
            {
                
                oPrimeraProrroga = ProrrogaBLL.GetPrimeraProrroga(oProrroga.IdProrroga);
                TxtDatePickerProrroga1.Text = oPrimeraProrroga.Prorroga1.ToShortDateString() ;
                TxtDatePickerProrroga1.Enabled = false;
            }
            else
                if (CantidadProrroga == 2)
                {

                    oSegundaProrroga = ProrrogaBLL.GetSegundaProrroga(oProrroga.IdProrroga);
                    oPrimeraProrroga = ProrrogaBLL.GetPrimeraProrroga(oProrroga.IdProrroga);
                    TxtFechaDevolucion.Text = ProrrogaBLL.GetFechaDevolucion(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtDatePickerProrroga1.Text = oPrimeraProrroga.Prorroga1.ToShortDateString();
                    TxtDatePickerProrroga2.Text = oSegundaProrroga.Prorroga2.ToShortDateString();
                    TxtDatePickerProrroga1.Enabled = false;
                    TxtDatePickerProrroga2.Enabled = false;
                    BtnDarProrroga.Enabled = false;

                }

                else
                {
                    //TxtFechaDevolucion.Enabled = false;
                    
                    TxtDatePickerProrroga2.Enabled = false;
                }


        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Domicilio y Sala/GestionPrestamos.aspx");
        }

    }
}