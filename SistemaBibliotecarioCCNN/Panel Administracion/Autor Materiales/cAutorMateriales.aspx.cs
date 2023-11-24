using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Autor_Materiales
{
    public partial class cAutorMateriales : System.Web.UI.Page
    {
        AutorEntity oAutor = new AutorEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                oAutor.NombreAutor = TxtNombreAutor.Text;
                oAutor.ApellidoAutor = TxtApellidoAutor.Text;
                oAutor.Estado = true;
                if (AutorBLL.InsertAutor(oAutor))
                {
                    Response.Redirect("GestionAutores.aspx");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}