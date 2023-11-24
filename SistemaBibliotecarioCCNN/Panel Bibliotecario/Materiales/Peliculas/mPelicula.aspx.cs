using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Peliculas
{
    public partial class mPelicula : System.Web.UI.Page
    {
        PeliculaEntity oPel = new PeliculaEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    oPel = PeliculaBLL.GetPelicula(Convert.ToInt32(Request.QueryString["Id"]));
                    LbIdMateialPelicula.Text = oPel.IdMaterial.ToString();
                    LblPelicula.Text = Request.QueryString["Id"].ToString();
                    TxtMaterialNombre.Text = oPel.Nombre;
                    TxtSinopsis.Text = oPel.Sinopsis;
                    TxtDuracion.Text = oPel.Duracion1;
                    TxtCantidad.Text = oPel.Cantidad.ToString();
                    TxtDescripcion.Text = oPel.Desripcion;
                    TxtAnio.Text = oPel.Anio.ToString();


                }
            }
        }

        protected void DdlRegEntrada_PreRender(object sender, EventArgs e)
        {
            DdlRegEntrada.DataSource = RegEntradaBLL.ShowRegEntrada();
            DdlRegEntrada.DataTextField = "Origen";
            DdlRegEntrada.DataValueField = "idRegEntrada";
            DdlRegEntrada.SelectedValue = oPel.RegEntradaEntity.IdRegEntrada.ToString();
            DdlRegEntrada.DataBind();

        }

        protected void DdlClasificacion_PreRender(object sender, EventArgs e)
        {
            DdlClasificacion.DataSource = ClasificacionBLL.ShowClasificacion();
            DdlClasificacion.DataTextField = "Clasificacion";
            DdlClasificacion.DataValueField = "idClasificacion";
            DdlClasificacion.SelectedValue = oPel.ClasificacionEntity.IdClasificacion.ToString();
            DdlClasificacion.DataBind();
        }

        protected void DdlProtagonista_PreRender(object sender, EventArgs e)
        {
            DdlProtagonista.DataSource = ProtagonistaBLL.ShowProtagonista();
            DdlProtagonista.DataTextField = "Nombre Protagonista";
            DdlProtagonista.DataValueField = "idProtagonista";
            DdlProtagonista.SelectedValue = oPel.Protagonista.IdProtagonistra.ToString();
            DdlProtagonista.DataBind();
        }

        protected void DdlDirector_PreRender(object sender, EventArgs e)
        {
            DdlDirector.DataSource = DirectorBLL.ShowDirector();
            DdlDirector.DataTextField = "Nombre Director";
            DdlDirector.DataValueField = "idDirector";
            DdlDirector.SelectedValue = oPel.DirectorEntity.IdDirector.ToString(); ;
            DdlDirector.DataBind();
        }

        protected void DdlGenero_PreRender(object sender, EventArgs e)
        {
            DdlGenero.DataSource = GeneroBLL.ShowGenero();
            DdlGenero.DataTextField = "Genero";
            DdlGenero.DataValueField = "idGenero";
            DdlGenero.SelectedValue = oPel.GeneroEntity.IdGenero.ToString();
            DdlGenero.DataBind();

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            PeliculaEntity oAuxPelicula = new PeliculaEntity();
            oAuxPelicula = PeliculaBLL.GetCantidadPelicula(Convert.ToInt32(LbIdMateialPelicula.Text));
            oPel.IdMaterial = Convert.ToInt32(LbIdMateialPelicula.Text);
            oPel.Nombre = TxtMaterialNombre.Text;
            oPel.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            oPel.Condicion = DdlCondicion.SelectedValue;
            oPel.Desripcion = TxtDescripcion.Text;
            oPel.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
            oPel.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);

            oPel.IdPelicula = Convert.ToInt32(LblPelicula.Text);
            oPel.GeneroEntity.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
            oPel.DirectorEntity.IdDirector = Convert.ToInt32(DdlDirector.SelectedValue);
            oPel.Protagonista.IdProtagonistra = Convert.ToInt32(DdlProtagonista.SelectedValue);
            oPel.Duracion1 = TxtDuracion.Text;
            oPel.Sinopsis = TxtSinopsis.Text;
            oPel.Subtitulo = Convert.ToBoolean(DdlSubtitulo.SelectedValue);
            oPel.Anio = Convert.ToInt32(TxtAnio.Text);
            if (oPel.Cantidad >= oAuxPelicula.Cantidad || oAuxPelicula.Prestado == 0)
            {
                if (PeliculaBLL.UpdatePelicula(oPel))
                {
                    if (ImgPelicula.HasFile == true)
                    {
                        MaterialEntity oMaterial = new MaterialEntity();
                        oMaterial.IdMaterial = oPel.IdMaterial;
                        oMaterial.ImgMaterial = ImgPelicula.FileBytes;
                        MaterialBLL.ActualizarImgMaterial(oMaterial);
                    
                    }
                    Response.Redirect("GestionPeliculas_Bibliotecario.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorActualizarExistencia();", true);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPeliculas_Bibliotecario.aspx");
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

        protected void BtnGuardarProtagonista_Click(object sender, EventArgs e)
        {
            ProtagonistaEntity oProtagonista = new ProtagonistaEntity();
            oProtagonista.NombreProtagonista = TxtNombreProtagnista.Text;
            oProtagonista.ApellidoProtagonista = TxtApellidoProtagonista.Text;
            oProtagonista.Estado = true;
            if (ProtagonistaBLL.InsertProtagonista(oProtagonista))
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BtnGuardarDirector_Click(object sender, EventArgs e)
        {
            DirectorEntity oDirector = new DirectorEntity();
            oDirector.NombreDirector = TxtNombreDirector.Text;
            oDirector.ApellidosDirector = TxtApellidoDirector.Text;
            oDirector.Estado = true;
            if (DirectorBLL.InsertDirector(oDirector))
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BtnGuardarGenero_Click(object sender, EventArgs e)
        {
            GeneroEntity oGenero = new GeneroEntity();
            oGenero.Genero = TxtGenero.Text;
            oGenero.Estado = true;
            if (GeneroBLL.InsertGenero(oGenero))
            {
                Response.Redirect(Request.RawUrl);
            }
        }


    }
}