using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Revistas
{
    public partial class mRevista : System.Web.UI.Page
    {
        RevistaEntity oRevista = new RevistaEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oRevista = RevistaBLL.GetRevista(Convert.ToInt32(Request.QueryString["Id"]));
                    LbIdMateiral.Text = oRevista.IdMaterial.ToString();
                    LbIdRevista.Text = Request.QueryString["Id"].ToString();
                    TxtNombreRevista.Text = oRevista.Nombre.ToString();
                    TxtVol.Text = oRevista.Volumen;
                    TxtCantidad.Text = oRevista.Cantidad.ToString();
                    TxtDescripcionRevista.Text = oRevista.Desripcion;

                    DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
                    DdlClasificacion.DataTextField = "Clasificacion";
                    DdlClasificacion.DataValueField = "idClasificacion";
                    DdlClasificacion.DataBind();
                    ListItem item = DdlClasificacion.Items.FindByValue(oRevista.ClasificacionEntity.IdClasificacion.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                
                }
            }
        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.DataBind();
            ListItem item = DdlClasificacion.Items.FindByValue(oRevista.ClasificacionEntity.IdClasificacion.ToString());
            if(item != null)
            {
                item.Selected = true;
            }
        }
          
        protected void DdlEditorial_PreRender(object sender, EventArgs e)
        {
            DdlEditorial.DataSource = EditorialBLL.ShowEditorial();
            DdlEditorial.DataTextField = "Editorial";
            DdlEditorial.DataValueField = "idEditorial";
            DdlEditorial.DataBind();
            ListItem item = DdlEditorial.Items.FindByValue(oRevista.EditorialEntity.IdEditorial.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }

        protected void DdlRegEntrada_PreRender(object sender, EventArgs e)
        {
                DdlRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
                DdlRegEntrada.DataTextField = "Origen";
                DdlRegEntrada.DataValueField = "idRegEntrada";
                DdlRegEntrada.DataBind();
                ListItem item  = DdlRegEntrada.Items.FindByValue(oRevista.RegEntradaEntity.IdRegEntrada.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
        }

        protected void DdlAutor_PreRender(object sender, EventArgs e)
        {
            DdlAutor.DataSource = AutorBLL.ShowAutor();
            DdlAutor.DataTextField = "Nombre Autor";
            DdlAutor.DataValueField = "idAutor";
            DdlAutor.DataBind();
            ListItem item = DdlAutor.Items.FindByValue(oRevista.AutorEntity.IdAutor.ToString());
            if (item != null)
            {
                item.Selected = true;
            }

        }

        protected void DdlEdicion_PreRender(object sender, EventArgs e)
        {
            DdlEdicion.DataSource = EdicionBLL.ShowEdicion();
            DdlEdicion.DataTextField = "Edicion";
            DdlEdicion.DataValueField = "idEdicion";
            DdlEdicion.DataBind();
            ListItem item = DdlAutor.Items.FindByValue(oRevista.AutorEntity.IdAutor.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }

        protected void BtnActializarRevista_Click(object sender, EventArgs e)
        {
            RevistaEntity oAuxRevista = new RevistaEntity();
            oAuxRevista = RevistaBLL.GetCantidadRevista(Convert.ToInt32(LbIdMateiral.Text));
            oRevista.IdMaterial = Convert.ToInt32(LbIdMateiral.Text);
            oRevista.IdRevista = Convert.ToInt32(LbIdRevista.Text);
            oRevista.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
            oRevista.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
            oRevista.AutorEntity.IdAutor = Convert.ToInt32(DdlAutor.SelectedValue);
            oRevista.EdicionEntity.IdEdicion = Convert.ToInt32(DdlEdicion.SelectedValue);
            oRevista.EditorialEntity.IdEditorial = Convert.ToInt32(DdlEditorial.SelectedValue);
            oRevista.Condicion = DdlCondicion.SelectedValue;


            oRevista.Nombre = TxtNombreRevista.Text;
            oRevista.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            oRevista.Desripcion = TxtDescripcionRevista.Text;
            oRevista.Volumen = TxtVol.Text;
            if (oRevista.Cantidad >= oAuxRevista.Cantidad || oAuxRevista.Prestado == 0)
            {
                if (RevistaBLL.UpdateRevista(oRevista))
                {
                    if (ImgRevista.HasFile == true)
                    {
                        MaterialEntity oMaterial = new MaterialEntity();
                        oMaterial.IdMaterial = oRevista.IdMaterial;
                        oMaterial.ImgMaterial = ImgRevista.FileBytes;
                        MaterialBLL.ActualizarImgMaterial(oMaterial);
                    
                    }
                    Response.Redirect("GestionRevista.aspx");
                }
            }
            else {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorActualizarExistencia();", true);
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
            Response.Redirect("GestionRevista.aspx");
        }

      

    }
}