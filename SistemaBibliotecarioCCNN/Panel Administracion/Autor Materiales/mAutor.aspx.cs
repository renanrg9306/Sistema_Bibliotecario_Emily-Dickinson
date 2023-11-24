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
    public partial class mAutor : System.Web.UI.Page
    {
        AutorEntity oAutor = new AutorEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"]!=null)
                {
                    oAutor = AutorBLL.GetAutorById(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtNombreAutor.Text = oAutor.NombreAutor;
                    TxtApellidoAutor.Text = oAutor.ApellidoAutor;
               }
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                oAutor.IdAutor = Convert.ToInt32(Request.QueryString["Id"]);
                oAutor.NombreAutor = TxtNombreAutor.Text;
                oAutor.ApellidoAutor = TxtApellidoAutor.Text;
                if (AutorBLL.UpdateAutor(oAutor))
                {
                    Response.Redirect("GestionAutores.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}