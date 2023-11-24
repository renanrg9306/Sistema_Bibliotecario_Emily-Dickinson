using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Autor_Materiales
{
    public partial class GestionAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GdvAutores_PreRender(object sender, EventArgs e)
        {
            GdvAutores.DataSource = AutorBLL.ShowAutor();
            GdvAutores.DataBind();
        }

        protected void LinkBtnNnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cAutorMateriales.aspx");
        }

        protected void LnkBtnActualizar_Command(object sender, CommandEventArgs e)
        {

            GdvAutores.Columns[1].Visible = true;
            string Id = e.CommandArgument.ToString();
            LbIdAutor.Text = Id;
            //string Id = GdvAutores.Columns[1].ToString();
            GdvAutores.Columns[1].Visible = false;
            
            Response.Redirect("mAutor.aspx?Id="+ Id);
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            GdvAutores.Columns[1].Visible = true;
            string Id = e.CommandArgument.ToString();
            //LbIdAutor.Text = Id;
            AutorEntity oAutor = new AutorEntity();
            oAutor.IdAutor = Convert.ToInt32(Id);
            if (AutorBLL.DeleteAutor(oAutor))
            {
                Response.Redirect("GestionAutores.aspx");
            }
        }

        
    
    }
}