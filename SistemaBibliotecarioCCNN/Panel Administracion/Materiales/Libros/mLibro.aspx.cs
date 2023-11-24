using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros
{
    public partial class mLibro : System.Web.UI.Page
    {
        LibroEntity oLibro = new LibroEntity();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"]!= null)
                {
                    oLibro = LibroBLL.GetAllDataLibro(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtNombreMaterial.Text = oLibro.Nombre;
                    TxtDescripcion.Text = oLibro.Desripcion;
                    TxtISBN.Text = oLibro.ISBN;
                    TxtCantidad.Text = oLibro.Cantidad.ToString();
                    LbIdMateiral.Text = oLibro.IdMaterial.ToString();
                    
                }
            }
        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.DataBind();
            ListItem Item = DdlClasificacion.Items.FindByValue(oLibro.ClasificacionEntity.IdClasificacion.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void DdlRegEntrada_PreRender(object sender, EventArgs e)
        {
            DdlRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
            DdlRegEntrada.DataTextField = "Origen";
            DdlRegEntrada.DataValueField = "idRegEntrada";
            DdlRegEntrada.DataBind();
            ListItem Item = DdlRegEntrada.Items.FindByValue(oLibro.RegEntradaEntity.IdRegEntrada.ToString());
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
            ListItem Item = DdlAutor.Items.FindByValue(oLibro.AutorEntity.IdAutor.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void DdlEdicion_PreRender(object sender, EventArgs e)
        {
            DdlEdicion.DataSource = EdicionBLL.ShowEdicion();
            DdlEdicion.DataTextField = "Edicion";
            DdlEdicion.DataValueField = "idEdicion";
            DdlEdicion.DataBind();
            ListItem Item = DdlEdicion.Items.FindByValue(oLibro.EdicionEntity.IdEdicion.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
            
        }

        protected void DdlEditorial_PreRender(object sender, EventArgs e)
        {
            DdlEditorial.DataSource = EditorialBLL.ShowEditorial();
            DdlEditorial.DataTextField = "Editorial";
            DdlEditorial.DataValueField = "idEditorial";
            DdlEditorial.DataBind();
            ListItem Item = DdlEditorial.Items.FindByValue(oLibro.EdicionEntity.IdEdicion.ToString());
            if (Item != null)
            {
                Item.Selected = true;
            }
        }

        protected void BtnActializarLibro_Click(object sender, EventArgs e)
        {
            LibroEntity oAuxLibro = new LibroEntity();
            oAuxLibro = LibroBLL.GetCantidadLibro(Convert.ToInt32(LbIdMateiral.Text));
            try
            {
                    oLibro.IdMaterial = Convert.ToInt32(LbIdMateiral.Text);                   
                    oLibro.IdLibro = Convert.ToInt32(Request.QueryString["Id"]);
                    oLibro.Nombre = TxtNombreMaterial.Text;
                    oLibro.Desripcion = TxtDescripcion.Text;
                    oLibro.Condicion = DdlCondicion.SelectedValue;
                    oLibro.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
                    oLibro.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
                    oLibro.EdicionEntity.IdEdicion = Convert.ToInt32(DdlEdicion.SelectedValue);
                    oLibro.EditorialEntity.IdEditorial = Convert.ToInt32(DdlEditorial.SelectedValue);
                    oLibro.AutorEntity.IdAutor = Convert.ToInt32(DdlAutor.SelectedValue);
                    oLibro.CuentaConCD = Convert.ToBoolean(DdlCD.SelectedValue);
                    oLibro.ISBN = TxtISBN.Text;
                    oLibro.Cantidad = Convert.ToInt32(TxtCantidad.Text);
                    if (oLibro.Cantidad >= oAuxLibro.Cantidad || oAuxLibro.Prestado == 0)
                    {
                        if (LibroBLL.VerificarISBNLibro(oLibro.IdLibro,oLibro.ISBN))
                        {
                            if (LibroBLL.UpdateLibro(oLibro))
                            {
                                if (ImgLibro.HasFile == true)
                                {
                                    MaterialEntity oMaterial = new MaterialEntity();
                                    oMaterial.IdMaterial = oLibro.IdMaterial;
                                    oMaterial.ImgMaterial = ImgLibro.FileBytes;
                                    MaterialBLL.ActualizarImgMaterial(oMaterial);
                                }
                                Response.Redirect("GestionLibros.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorISBNExistente();", true);
                        }
                    }
                    else {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorActualizarExistencia();", true);
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
                Response.Redirect(Request.RawUrl);
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

        protected void BtnGuardarEditorialAtajo_Click(object sender, EventArgs e)
        {
            EditorialEntity oEditorial = new EditorialEntity();
            oEditorial.Editorial = TxtEditorial.Text;
            oEditorial.Estado = true;
            if (EditorialBLL.InsertEditorial(oEditorial))
            {
                Response.Redirect(Request.RawUrl);
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
                Response.Redirect(Request.RawUrl);
            }
        }



        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionLibros.aspx");
        }

        protected void DdlCD_PreRender(object sender, EventArgs e)
        {
            DdlCD.SelectedValue = oLibro.CuentaConCD.ToString();
        }
    }
}