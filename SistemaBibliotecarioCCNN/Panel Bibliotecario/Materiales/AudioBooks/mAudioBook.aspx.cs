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
    public partial class mAudioBook : System.Web.UI.Page
    {
        AudioBookEntity oAB = new AudioBookEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oAB = AudiobookBLL.GetAllDataAudioBook(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtNombreMaterial.Text = oAB.Nombre;
                    TxtDescripcion.Text = oAB.Desripcion;
                    TxtCantidad.Text = oAB.Cantidad.ToString();
                    TxtComponentes.Text = oAB.Componentes;
                    LbIdMateiral.Text = oAB.IdMaterial.ToString();
                }
            }    
        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.DataBind();
            ListItem Item = DdlClasificacion.Items.FindByValue(oAB.ClasificacionEntity.IdClasificacion.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void DdlCondicion_PreRender(object sender, EventArgs e)
        {
            DdlCondicion.SelectedValue = oAB.Condicion;
        }

        protected void DdlRegEntrada_PreRender(object sender, EventArgs e)
        {
            DdlRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
            DdlRegEntrada.DataTextField = "Origen";
            DdlRegEntrada.DataValueField = "idRegEntrada";
            DdlRegEntrada.DataBind();
            ListItem Item = DdlRegEntrada.Items.FindByValue(oAB.RegEntradaEntity.IdRegEntrada.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void DdlAutor_PreRender(object sender, EventArgs e)
        {
            DdlAutor.DataSource = AutorBLL.ShowAutor();
            DdlAutor.DataTextField = "Nombre Autor";
            DdlAutor.DataValueField = "idAutor";
            DdlAutor.DataBind();
            ListItem Item = DdlAutor.Items.FindByValue(oAB.AutorEntity.IdAutor.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void BtnActualizarAudioBook_Click(object sender, EventArgs e)
        {
            try{
            AudioBookEntity oAuxAB = new AudioBookEntity();
            oAuxAB = AudiobookBLL.GetCantidadAudiobook(Convert.ToInt32(LbIdMateiral.Text));
            oAB.Nombre = TxtNombreMaterial.Text;
            oAB.Desripcion = TxtDescripcion.Text;
            oAB.Componentes = TxtComponentes.Text;
            oAB.Condicion = DdlCondicion.SelectedValue;
            oAB.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            oAB.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
            oAB.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
            oAB.AutorEntity.IdAutor = Convert.ToInt32(DdlAutor.SelectedValue);
            oAB.IdMaterial = Convert.ToInt32(LbIdMateiral.Text);
            oAB.IdAudiobook = Convert.ToInt32(Request.QueryString["Id"]);
            if (oAB.Cantidad >= oAuxAB.Cantidad || oAuxAB.Prestado == 0)
            {
                if (AudiobookBLL.UpdateAudioBook(oAB))
                {
                    if (ImgAudioBook.HasFile == true)
                    {
                        MaterialEntity oMaterial = new MaterialEntity();
                        oMaterial.IdMaterial = oAB.IdMaterial;
                        oMaterial.ImgMaterial = ImgAudioBook.FileBytes;
                        MaterialBLL.ActualizarImgMaterial(oMaterial);
                    }
                    Response.Redirect("GestionAudioBooks_Bibliotecario.aspx");
                }
            }
            else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorActualizarExistencia();", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionAudioBooks_Bibliotecario.aspx");
        }

        protected void BtnGuardarClasificacionAtajo_Click(object sender, EventArgs e)
        {
            ClasificacionEntity oCla = new ClasificacionEntity();
            oCla.Clasificacion = TxtClasificacion.Text;
            oCla.Descripcion = TxtDescripcionClasificacion.Text;
            oCla.Estado = true;
            if (ClasificacionBLL.InsertClasificacion(oCla) > 0)
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BtnGuardarRegEntradaAtajo_Click(object sender, EventArgs e)
        {
            RegEntradaEntity oRegE = new RegEntradaEntity();
            oRegE.Origen = TxtOrigen.Text;
            oRegE.Estado = true;
            if (RegEntradaBLL.InsertRegEntrada(oRegE))
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BtnGuardarAutorAtajo_Click(object sender, EventArgs e)
        {
            AutorEntity oAutor = new AutorEntity();
            oAutor.NombreAutor = TxtNombreAutor.Text;
            oAutor.ApellidoAutor = TxtApellidoAutor.Text;
            oAutor.Estado = true;
            if (AutorBLL.InsertAutor(oAutor))
            {
                Response.Redirect(Request.RawUrl);
            }
        }


    }
}