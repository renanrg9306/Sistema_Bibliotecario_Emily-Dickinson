using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Domicilio
{
    public partial class cPrestamoPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbFecha.Text = DateTime.Now.ToShortDateString();
        }
        protected void DdlTipoPrestamo_PreRender(object sender, EventArgs e)
        {
            DdlTipoPrestamo.DataSource = TipoPrestamoBLL.ShowTipoPrestamo();
            DdlTipoPrestamo.DataTextField = "Descripcion";
            DdlTipoPrestamo.DataValueField = "idTipoprestamos";
            DdlTipoPrestamo.DataBind();
        }

        protected void DdlVisitante_PreRender(object sender, EventArgs e)
        {
            DdlVisitante.DataSource = VisitanteBLL.ShowVisitante();
            DdlVisitante.DataTextField = "Nombre Completo";
            DdlVisitante.DataValueField = "idVisitante";
            DdlVisitante.DataBind();
        }

        protected void DdlMaterialPelicula_PreRender(object sender, EventArgs e)
        {
            DdlMaterialPelicula.DataSource = PeliculaBLL.ShowMaterialPelicula();
            DdlMaterialPelicula.DataTextField = "MaterialPelicula";
            DdlMaterialPelicula.DataValueField = "idMaterial";
            DdlMaterialPelicula.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EntregaPrestamoEntity oPrestamo = new EntregaPrestamoEntity();
                oPrestamo.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterialPelicula.SelectedValue);
                oPrestamo.TipoPrestamo.IdTipoPrestamo = Convert.ToInt32(DdlTipoPrestamo.SelectedValue);
                oPrestamo.EmpleadoEntity.IdEmpleado = AdministradorBLL.GetIdAdmin(Session["username"].ToString());
                oPrestamo.VisitanteEntity.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                oPrestamo.FechaPrestamo = Convert.ToDateTime(LbFecha.Text);
                oPrestamo.FechaDevolucion = Convert.ToDateTime(TxtFecha.Text);
                oPrestamo.Cantidad = Convert.ToInt32(TxtCantidadM.Text);

                PeliculaEntity oPelicula = new PeliculaEntity();
                oPelicula = PeliculaBLL.GetCantidadPelicula(oPrestamo.MaterialEntity.IdMaterial);
                int Existencia = oPelicula.Cantidad - (oPelicula.Prestado + oPelicula.Reservado);
                if (Existencia > 0 && oPrestamo.Cantidad <= Existencia)
                {
                    oPelicula.IdMaterial = oPrestamo.MaterialEntity.IdMaterial;
                    oPelicula.Prestado = PrestamoBLL.InsertEntregaPrestamo(oPrestamo);
                    if (PeliculaBLL.AsignarCantidadPrestaPelicula(oPelicula))
                    {
                        AdministradorEntity oAdmin = new AdministradorEntity();
                        oAdmin.IdEmpleado = oPrestamo.EmpleadoEntity.IdEmpleado;
                        oAdmin.CantidadPrestamosRealizados = AdministradorBLL.VerificarPrestamosEmpleados(oAdmin.IdEmpleado);
                        if (AdministradorBLL.AsignarCantidadPrestamos(oAdmin))
                        {
                            VisitanteEntity oVisita = new VisitanteEntity();
                            VisitanteEntity oVisitante = new VisitanteEntity();
                            oVisitante = VisitanteBLL.GetVisitante(Convert.ToInt32(DdlVisitante.SelectedValue));
                            oVisita.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                            oVisita.Prestado = VisitanteBLL.VerificarPrestamosVisitante(oVisita.IdVisitante);
                            if (VisitanteBLL.AsignarCantidadPrestamosVisitante(oVisita)) { 
                            EnvioCorreoBLL.EnviarCorreo("Pelicula Prestado: ", "Titulo Pelicula:" + " " + oPelicula.Nombre + " Prestado por: " + AdministradorBLL.GetDatosAdminByCodUsuario(Session["username"].ToString()) + " Que será devuelto: " + oPrestamo.FechaDevolucion.ToShortDateString(), oVisitante.Email);
                            Response.Redirect("GestionPrestamos.aspx");
                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MisJs", "MensajeErrorExistencia();", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPrestamos.aspx");
        }

      
    }
}