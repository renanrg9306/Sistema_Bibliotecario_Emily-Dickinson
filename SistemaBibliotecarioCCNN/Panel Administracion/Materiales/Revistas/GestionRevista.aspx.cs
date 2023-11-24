using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Revistas
{
    public partial class GestionRevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LnkBtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cRevista.aspx");
        }

        protected void GdvShowRevista_PreRender(object sender, EventArgs e)
        {
            GdvShowRevista.DataSource = RevistaBLL.ShowRevista();
            GdvShowRevista.DataBind();
        }

        protected void LnkBtnModificar_Command(object sender, CommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            Response.Redirect("mRevista.aspx?Id="+Id);
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            string IdMaterial = e.CommandArgument.ToString();
            RevistaEntity oRevista = new RevistaEntity();
            oRevista.IdMaterial = Convert.ToInt32(IdMaterial);
            if (RevistaBLL.DeleteRevista(oRevista))
            {
                Response.Redirect("GestionRevista.aspx");
            }

        }

        [WebMethod(EnableSession = true)]
        public static object DeleteRevista(string IdMaterial)
        {
            RevistaEntity oRevista = new RevistaEntity();
            oRevista.IdMaterial = Convert.ToInt32(IdMaterial);
            string msg = "";
            if (RevistaBLL.DeleteRevista(oRevista))
            {
                msg = "Ok";
            }
            else {
                msg = "Error";
            
            }

            return new { Result = msg };
        }

        protected void GdvShowRevista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void LnkBtnVerImg_Command(object sender, CommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());

            byte[] Imagenbyte = MaterialBLL.MostrarImagenMaterial(Id);
            string StrBase64 = Convert.ToBase64String(Imagenbyte);
            MaterialEntity oMaterial = new MaterialEntity();
            oMaterial = MaterialBLL.GetCantidadMaterial(Id);

            ImagenLibro.ImageUrl = "data:Image/png;base64," + StrBase64;
            LbMaterial.Text = oMaterial.Nombre;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MostrarModalImagen();", true);
        }
       
    }
}