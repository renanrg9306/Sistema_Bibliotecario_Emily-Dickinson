using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala
{
    public partial class cPrestamoRevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbFecha.Text = DateTime.Now.ToShortDateString();
        }
        protected void DdlMaterialRevista_PreRender(object sender, EventArgs e)
        {
            DdlMaterialRevista.DataSource = RevistaBLL.ShowMaterialRevista();
            DdlMaterialRevista.DataTextField = "MaterialRevista";
            DdlMaterialRevista.DataValueField = "idMaterial";
            DdlMaterialRevista.DataBind();
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EntregaPrestamoEntity oPrestamo = new EntregaPrestamoEntity();
                oPrestamo.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterialRevista.SelectedValue);
                oPrestamo.TipoPrestamo.IdTipoPrestamo = Convert.ToInt32(DdlTipoPrestamo.SelectedValue);
                oPrestamo.EmpleadoEntity.IdEmpleado = AdministradorBLL.GetIdAdmin(Session["username"].ToString());
                oPrestamo.VisitanteEntity.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                oPrestamo.FechaPrestamo = Convert.ToDateTime(LbFecha.Text);
                oPrestamo.FechaDevolucion = Convert.ToDateTime(TxtFecha.Text);
                oPrestamo.Cantidad = Convert.ToInt32(TxtCantidadM.Text);

                RevistaEntity oRevista = new RevistaEntity();
                oRevista = RevistaBLL.GetCantidadRevista(oPrestamo.MaterialEntity.IdMaterial);
                int Existencia = oRevista.Cantidad - oRevista.Prestado;
                if (Existencia > 0 && oPrestamo.Cantidad <= Existencia)
                {
                    oRevista.IdMaterial = oPrestamo.MaterialEntity.IdMaterial;
                    oRevista.Prestado = PrestamoBLL.InsertEntregaPrestamo(oPrestamo);
                    if (RevistaBLL.AsignarCantidadPrestadaRevista(oRevista))
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
                            EnvioCorreoBLL.EnviarCorreo("Revista Prestado: ", "Titulo de Revista:" + " " + oRevista.Nombre + " Prestado por: " + BibliotecarioBLL.GetDatosBibliotByCodUsuario(Session["username"].ToString()) + " Que será entregado: " + oPrestamo.FechaDevolucion.ToShortDateString(), oVisitante.Email);
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