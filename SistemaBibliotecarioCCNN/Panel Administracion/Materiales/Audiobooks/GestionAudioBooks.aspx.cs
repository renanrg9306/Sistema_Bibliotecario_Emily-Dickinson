using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;


namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales
{
    public partial class GestionAudioBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GdvShowAB_PreRender(object sender, EventArgs e)
        {
            GdvShowAB.DataSource = AudiobookBLL.ShowAudiobook();
            GdvShowAB.DataBind();
        }

        protected void LnkBtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Panel Administracion/Materiales/Audiobooks/cAudiobook.aspx");
        }

        protected void LnkBtnModificar_Command(object sender, CommandEventArgs e)
        {
            GdvShowAB.Columns[1].Visible = true;
            string Id = e.CommandArgument.ToString();
            GdvShowAB.Columns[1].Visible = false;
            Response.Redirect("mAudiobooks.aspx?Id="+Id);
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {
          
            GdvShowAB.Columns[2].Visible = true;
            string Id = e.CommandArgument.ToString();
            GdvShowAB.Columns[2].Visible = false;
            AudioBookEntity oAB = new AudioBookEntity();
            oAB.IdMaterial = Convert.ToInt32(Id);
            if (AudiobookBLL.DeleteAudioBook(oAB))
            {
                Response.Redirect("GestionAudioBooks.aspx");
            }
        }

        [WebMethod(EnableSession=true)]
        public static object DeleteAudiobook(string IdMaterial)
        {
            AudioBookEntity oAB = new AudioBookEntity();
            AudioBookEntity oAuxAB = new AudioBookEntity();
            oAB.IdMaterial = Convert.ToInt32(IdMaterial);
            oAuxAB = AudiobookBLL.GetCantidadAudiobook(oAB.IdMaterial);
            String msg = "";
            if (oAuxAB.Prestado == 0)
            {
                if (AudiobookBLL.DeleteAudioBook(oAB))
                {
                    msg = "Ok";
                }
                else
                {
                    msg = "Error";
                }
            }

            return new { Result = msg };
        }

        protected void GdvShowAB_RowDataBound(object sender, GridViewRowEventArgs e)
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
           
            ImagenAB.ImageUrl = "data:Image/png;base64," + StrBase64;
            LbMaterial.Text = oMaterial.Nombre;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MostrarModalImagen();", true);
        }
    }
}