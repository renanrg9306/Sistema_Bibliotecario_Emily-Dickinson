using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala
{
    public partial class cPrestamoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LbFecha.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void DdlMaterialLibro_PreRender(object sender, EventArgs e)
        {
            DdlMaterialLibro.DataSource = LibroBLL.ShowMateriaLibro();
            DdlMaterialLibro.DataTextField = "MaterialLibro";
            DdlMaterialLibro.DataValueField = "idMaterial";
            DdlMaterialLibro.DataBind();
        }

        protected void DdlVisitante_PreRender(object sender, EventArgs e)
        {
            DdlVisitante.DataSource = VisitanteBLL.ShowVisitante();
            DdlVisitante.DataTextField = "Nombre Completo";
            DdlVisitante.DataValueField = "idVisitante";
            DdlVisitante.DataBind();
        }

        protected void DdlTipoPrestamo_PreRender(object sender, EventArgs e)
        {
            DdlTipoPrestamo.DataSource = TipoPrestamoBLL.ShowTipoPrestamo();
            DdlTipoPrestamo.DataTextField = "Descripcion";
            DdlTipoPrestamo.DataValueField = "idTipoprestamos";
            DdlTipoPrestamo.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {


            try
            {
                EntregaPrestamoEntity oPrestamo = new EntregaPrestamoEntity();
                oPrestamo.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterialLibro.SelectedValue);
                oPrestamo.TipoPrestamo.IdTipoPrestamo = Convert.ToInt32(DdlTipoPrestamo.SelectedValue);
                oPrestamo.EmpleadoEntity.IdEmpleado = AdministradorBLL.GetIdAdmin(Session["username"].ToString());
                oPrestamo.VisitanteEntity.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                oPrestamo.FechaPrestamo = Convert.ToDateTime(LbFecha.Text);
                oPrestamo.FechaDevolucion = Convert.ToDateTime(TxtFecha.Text);
                oPrestamo.Cantidad = Convert.ToInt32(TxtCantidadM.Text);

                LibroEntity oLibro = new LibroEntity();
                oLibro = LibroBLL.GetCantidadLibro(oPrestamo.MaterialEntity.IdMaterial);
                int Existencia = oLibro.Cantidad - oLibro.Prestado;
                if (Existencia > 0 && oPrestamo.Cantidad <= Existencia)
                {
                    oLibro.IdMaterial = oPrestamo.MaterialEntity.IdMaterial;
                    oLibro.Prestado = PrestamoBLL.InsertEntregaPrestamo(oPrestamo);
                    if (LibroBLL.AsiganarCantidadPrestadaLibro(oLibro))
                    {
                        BibliotecarioEntity oBibliotecario = new BibliotecarioEntity();
                        oBibliotecario.IdEmpleado = oPrestamo.EmpleadoEntity.IdEmpleado;
                        oBibliotecario.CantidadPrestamosRealizados = BibliotecarioBLL.VerificarPrestamoEmpleado(oBibliotecario.IdEmpleado);
                        if (BibliotecarioBLL.AsignarCantidadPrestamosRealizados(oBibliotecario))
                        {
                            VisitanteEntity oVisita = new VisitanteEntity();
                            VisitanteEntity oVisitante = new VisitanteEntity();
                            oVisita.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                            oVisita.Prestado = VisitanteBLL.VerificarPrestamosVisitante(oVisita.IdVisitante);
                            oVisitante = VisitanteBLL.GetVisitante(Convert.ToInt32(DdlVisitante.SelectedValue));
                            if (VisitanteBLL.AsignarCantidadPrestamosVisitante(oVisita)) { 
                            EnvioCorreoBLL.EnviarCorreo("Libro Prestado: ", "Titulo del Libro:" + " " + oLibro.Nombre + " Prestado por: " + BibliotecarioBLL.GetDatosBibliotByCodUsuario(Session["username"].ToString()) + " Que será devuelto: " + oPrestamo.FechaDevolucion.ToShortDateString(), oVisitante.Email);
                            Response.Redirect("GestionPrestamos_Bibliotecarios.aspx");
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
            Response.Redirect("GestionPrestamos_Bibliotecarios.aspx");
        }
         
    }
}