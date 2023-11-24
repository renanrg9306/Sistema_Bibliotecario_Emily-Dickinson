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
    public partial class mRegEntrada : System.Web.UI.Page
    {
        RegEntradaEntity oRegE = new RegEntradaEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oRegE = RegEntradaBLL.GetById(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtOrigen.Text = oRegE.Origen;
                    LbIdRegEntrada.Text = oRegE.IdRegEntrada.ToString();
                }
            }

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                oRegE.IdRegEntrada = Convert.ToInt32(Request.QueryString["Id"]);
                oRegE.Origen = TxtOrigen.Text;
                if (RegEntradaBLL.UpdateRegEntrada(oRegE))
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