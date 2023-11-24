using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.AudioBooks
{
    public partial class GestionAudioBooks_Bibliotecario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LnkBtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cAudiobook.aspx");
        }

        protected void GdvShowAB_PreRender(object sender, EventArgs e)
        {
            GdvShowAB.DataSource = AudiobookBLL.ShowAudiobook();
            GdvShowAB.DataBind();
        }

        protected void LnkBtnModificar_Command(object sender, CommandEventArgs e)
        {
            GdvShowAB.Columns[1].Visible = true;
            string Id = e.CommandArgument.ToString();
            GdvShowAB.Columns[1].Visible = false;
            Response.Redirect("mAudiobook.aspx?Id=" + Id);
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