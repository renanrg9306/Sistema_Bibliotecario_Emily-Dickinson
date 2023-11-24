using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Visitante.Materiales
{
    public partial class Pelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GdvShowPeliculas_PreRender(object sender, EventArgs e)
        {
            GdvShowPeliculas.DataSource = PeliculaBLL.ShowPelicula();
            GdvShowPeliculas.DataBind();
        }
        protected void GdvShowPeliculas_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void LnkBtnReservar_Command(object sender, CommandEventArgs e)
        {
            GdvShowPeliculas.Columns[2].Visible = true;
            string Id = e.CommandArgument.ToString();
            GdvShowPeliculas.Columns[2].Visible = false;
            Response.Redirect("ReservacionMaterial.aspx?Id=" + Id);
        }
    }
}