using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Registro_Entrada
{
    public partial class cRegistroEntrada : System.Web.UI.Page
    {
        RegEntradaEntity oReE = new RegEntradaEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                oReE.Origen = TxtOrigen.Text;
                oReE.Estado = true;
                if (RegEntradaBLL.InsertRegEntrada(oReE))
                {
                    Response.Redirect("GestionRegistroEntrada.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}