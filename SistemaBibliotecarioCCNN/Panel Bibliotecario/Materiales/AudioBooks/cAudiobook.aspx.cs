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
    public partial class cAudiobook : System.Web.UI.Page
    {
        AudioBookEntity oAB = new AudioBookEntity();
        int UltimoDato;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LbFecha.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void DdlRegEntrada_PreRender(object sender, EventArgs e)
        {
     
            DdlRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
            DdlRegEntrada.DataTextField = "Origen";
            DdlRegEntrada.DataValueField = "idRegEntrada";
            DdlRegEntrada.DataBind();

        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.DataBind();
          
        }

        protected void DdlAutor_PreRender(object sender, EventArgs e)
        {
            DdlAutor.DataSource = AutorBLL.ShowAutor();
            DdlAutor.DataTextField = "Nombre Autor";
            DdlAutor.DataValueField = "idAutor";
            DdlAutor.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
             try
            {
                oAB.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
                oAB.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
                oAB.AutorEntity.IdAutor = Convert.ToInt32(DdlAutor.SelectedValue);
                oAB.Condicion = DdlCondicion.SelectedValue.ToString();
                oAB.Desripcion = TxtDescripcion.Text;
                oAB.Componentes = TxtComponentes.Text;
                oAB.Cantidad = Convert.ToInt32(TxtCantidad.Text);
                oAB.Nombre = TxtMaterialNombre.Text;
                oAB.Prestado = 0;
                oAB.Estado = true;
                oAB.Fecha_Recep = Convert.ToDateTime(LbFecha.Text);
                oAB.ImgMaterial = ImgAudioBook.FileBytes;
                if (AudiobookBLL.InsertAudioBook(oAB))
                {
                    Response.Redirect("GestionAudioBooks_Bibliotecario.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void BtnGuardarRegEntradaAtajo_Click(object sender, EventArgs e)
        {
            RegEntradaEntity oRegE = new RegEntradaEntity();
            oRegE.Origen = TxtOrigen.Text;
            oRegE.Estado = true;
            if (RegEntradaBLL.InsertRegEntrada(oRegE))
            {
                TxtOrigen.Text = "";
            }
        }

        protected void BtnGuardarClasificacionAtajo_Click(object sender, EventArgs e)
        {
            ClasificacionEntity oCla = new ClasificacionEntity();
            oCla.Clasificacion = TxtClasificacion.Text;
            oCla.Descripcion = TxtDescripcionClasificacion.Text;
            oCla.Estado = true;
            UltimoDato = ClasificacionBLL.InsertClasificacion(oCla);
            if(UltimoDato>0)
            {
                TxtClasificacion.Text = "";
                TxtDescripcionClasificacion.Text = "";
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
                TxtNombreAutor.Text = "";
                TxtApellidoAutor.Text = "";

            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionAudioBooks_Bibliotecario.aspx");
        }
        
    }
}