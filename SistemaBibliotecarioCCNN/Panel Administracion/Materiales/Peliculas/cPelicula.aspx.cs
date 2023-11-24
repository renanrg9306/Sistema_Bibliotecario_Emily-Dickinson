using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Peliculas
{
    public partial class cPelicula : System.Web.UI.Page
    {
        PeliculaEntity oPelicula = new PeliculaEntity();
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

        protected void BtnGuardarPelicula_Click(object sender, EventArgs e)
        {
            oPelicula.Nombre = TxtMaterialNombre.Text;
            oPelicula.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(DdlRegEntrada.SelectedValue);
            oPelicula.ClasificacionEntity.IdClasificacion = Convert.ToInt32(DdlClasificacion.SelectedValue);
            oPelicula.GeneroEntity.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
            oPelicula.DirectorEntity.IdDirector = Convert.ToInt32(DdlDirector.SelectedValue);
            oPelicula.Protagonista.IdProtagonistra = Convert.ToInt32(DdlProtagonista.SelectedValue);
            oPelicula.Condicion = DdlCondicion.SelectedValue;
            oPelicula.Duracion1 = TxtDuracion.Text;
            oPelicula.Sinopsis = TxtSinopsis.Text;
            oPelicula.Subtitulo = Convert.ToBoolean(DdlSubtitulo.SelectedValue);
            oPelicula.Anio = Convert.ToInt32(TxtAnio.Text);
            oPelicula.Desripcion = TxtDescripcion.Text;
            oPelicula.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            oPelicula.Prestado = 0;
            oPelicula.Reservado = 0;
            oPelicula.Fecha_Recep = Convert.ToDateTime(LbFecha.Text);
            oPelicula.Estado = true;
            oPelicula.ImgMaterial = ImgPelicula.FileBytes;
            if (PeliculaBLL.InsertPelicula(oPelicula))
            {
                Response.Redirect("GestionPeliculas.aspx");
            
            }


        }

        protected void DdlProtagonista_PreRender(object sender, EventArgs e)
        {
            DdlProtagonista.DataSource = ProtagonistaBLL.ShowProtagonista();
            DdlProtagonista.DataTextField = "Nombre Protagonista";
            DdlProtagonista.DataValueField = "idProtagonista";
            DdlProtagonista.DataBind();
        }

        protected void DdlDirector_PreRender(object sender, EventArgs e)
        {
            DdlDirector.DataSource = DirectorBLL.ShowDirector();
            DdlDirector.DataTextField = "Nombre Director";
            DdlDirector.DataValueField = "idDirector";
            DdlDirector.DataBind();
        }

        protected void DdlGenero_PreRender(object sender, EventArgs e)
        {
            DdlGenero.DataSource = GeneroBLL.ShowGenero();
            DdlGenero.DataTextField = "Genero";
            DdlGenero.DataValueField = "idGenero";
            DdlGenero.DataBind();
        }

        protected void BtnGuardaDirectorAtajo_Click(object sender, EventArgs e)
        {
            DirectorEntity oDirec = new DirectorEntity();
            oDirec.NombreDirector = TxtNombreDirector.Text;
            oDirec.ApellidosDirector = TxtApellidoDirector.Text;
            oDirec.Estado = true;
            if (DirectorBLL.InsertDirector(oDirec))
            {
                TxtNombreDirector.Text = "";
                TxtApellidoDirector.Text = "";
            }
        }

        protected void BtnGuardarGeneroAtajo_Click(object sender, EventArgs e)
        {
            GeneroEntity oGenero = new GeneroEntity();
            oGenero.Genero = TxtGenero.Text;
            oGenero.Estado = true;
            if (GeneroBLL.InsertGenero(oGenero))
            {
                TxtGenero.Text = "";
            }
        }

        protected void BtnGuardarProtagnistaAtajo_Click(object sender, EventArgs e)
        {
            ProtagonistaEntity oProt = new ProtagonistaEntity();
            oProt.NombreProtagonista = TxtNombreProtagnista.Text;
            oProt.ApellidoProtagonista = TxtApellidoProtagonista.Text;
            oProt.Estado = true;
            if (ProtagonistaBLL.InsertProtagonista(oProt))
            {
                TxtNombreProtagnista.Text = "";
                TxtApellidoProtagonista.Text = "";
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
            if (ClasificacionBLL.InsertClasificacion(oCla)>0)
            {
                TxtClasificacion.Text = "";
                TxtDescripcionClasificacion.Text = "";
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPeliculas.aspx");
        }
    }
}