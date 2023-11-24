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
    public partial class GestionRegistroEntrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GdvRegEntrada_PreRender(object sender, EventArgs e)
        {
            GdvRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
            GdvRegEntrada.DataBind();
        }

        protected void LinkBtnNnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cRegistroEntrada.aspx");
        }

        protected void LnkBtnActualizar_Command(object sender, CommandEventArgs e)
        {
             GdvRegEntrada.Columns[1].Visible = true;
             string Id = e.CommandArgument.ToString();
             GdvRegEntrada.Columns[1].Visible = false;
             Response.Redirect("mRegEntrada.aspx?Id=" + Id);
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            GdvRegEntrada.Columns[1].Visible = true;
            string Id = e.CommandArgument.ToString();
            GdvRegEntrada.Columns[1].Visible = false;
            RegEntradaEntity oRegE = new RegEntradaEntity();
            oRegE.IdRegEntrada = Convert.ToInt32(Id);
            if (RegEntradaBLL.DeleteRegEntrada(oRegE))
            {
                Response.Redirect("GestionRegistroEntrada.aspx");
            }
        }

    }
}