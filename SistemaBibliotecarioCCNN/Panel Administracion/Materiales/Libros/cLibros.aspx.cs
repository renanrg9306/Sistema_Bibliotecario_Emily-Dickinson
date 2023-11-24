using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros
{
    public partial class cLibros : System.Web.UI.Page
    {
        LibroEntity oLibro = new LibroEntity();
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

        protected void DdlEditorial_PreRender(object sender, EventArgs e)
        {
            DdlEditorial.DataSource = EditorialBLL.ShowEditorial();
            DdlEditorial.DataTextField = "Editorial";
            DdlEditorial.DataValueField = "idEditorial";
            DdlEditorial.DataBind();
        }

        protected void DdlEdicion_PreRender(object sender, EventArgs e)
        {
            DdlEdicion.DataSource = EdicionBLL.ShowEdicion();
            DdlEdicion.DataTextField = "Edicion";
            DdlEdicion.DataValueField = "idEdicion";
            DdlEdicion.DataBind();
        }

        protected void BtnGuardarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                oLibro.Nombre = TxtMaterialNombre.Text;
                oLibro.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
                oLibro.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
                oLibro.AutorEntity.IdAutor = Convert.ToInt32(DdlAutor.SelectedValue);
                oLibro.EditorialEntity.IdEditorial = Convert.ToInt32(DdlEditorial.SelectedValue);
                oLibro.EdicionEntity.IdEdicion = Convert.ToInt32(DdlEdicion.SelectedValue);
                oLibro.Condicion = DdlCondicion.SelectedValue;
                oLibro.Desripcion = TxtDescripcion.Text;
                oLibro.ISBN = TxtISBN.Text;
                oLibro.CuentaConCD = Convert.ToBoolean(DdlCuentaConCD.SelectedValue);
                oLibro.Cantidad = Convert.ToInt32(TxtCantidad.Text);
                oLibro.Fecha_Recep = Convert.ToDateTime(LbFecha.Text);
                oLibro.Prestado = 0;
                oLibro.Reservado = 0;
                oLibro.Estado = true;
                oLibro.ImgMaterial = ImgLibro.FileBytes;
                if (LibroBLL.VerificarISBNLibro(oLibro.IdLibro, oLibro.ISBN))
                {
                    if (LibroBLL.InsertLibro(oLibro))
                    {
                        Response.Redirect("GestionLibros.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorISBNExistente();", true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnGuardarEdicionAtajo_Click(object sender, EventArgs e)
        {
            EdicionEntity oEdicion = new EdicionEntity();
            oEdicion.Edicion = TxtEdicion.Text;
            oEdicion.AnioEntity.Anio = Convert.ToInt32(TxtAnio.Text);
            oEdicion.Estado = true;
            if (EdicionBLL.InsertEdicion(oEdicion))
            {
                TxtEdicion.Text = "";
                TxtAnio.Text = "";
            }
        }

        protected void BtnGuardarClasificacionAtajo_Click(object sender, EventArgs e)
        {
            ClasificacionEntity oCla = new ClasificacionEntity();
            oCla.Clasificacion = TxtClasificacion.Text;
            oCla.Descripcion = TxtDescripcionClasificacion.Text;
            oCla.Estado = true;
            if (ClasificacionBLL.InsertClasificacion(oCla)>0)
            {
                TxtClasificacion.Text = "";
                TxtDescripcionClasificacion.Text = "";
                
            }

        }

        protected void BtnGuardarRegEntradaAtajo_Click(object sender, EventArgs e)
        {
            RegEntradaEntity oRegEntrada = new RegEntradaEntity();
            oRegEntrada.Origen = TxtOrigen.Text;
            oRegEntrada.Estado = true;
            if (RegEntradaBLL.InsertRegEntrada(oRegEntrada))
            {
                TxtOrigen.Text = "";

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

        protected void BtnGuardarEditorialAtajo_Click(object sender, EventArgs e)
        {
            EditorialEntity oEditorial = new EditorialEntity();
            oEditorial.Editorial = TxtEditorial.Text;
            oEditorial.Estado = true;
            if (EditorialBLL.InsertEditorial(oEditorial))
            {
                TxtEditorial.Text = "";
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionLibros.aspx");
        }

        //protected void DdlAnio_PreRender(object sender, EventArgs e)
        //{
        //    DdlAnio.DataSource = AnioBLL.GetAnio();
        //    DdlAnio.DataTextField = "Anio";
        //    DdlAnio.DataValueField = "idAnio";
        //    DdlAnio.DataBind();
        //}


    }
}