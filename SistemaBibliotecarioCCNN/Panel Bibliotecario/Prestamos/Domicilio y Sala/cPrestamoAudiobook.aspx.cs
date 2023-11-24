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
    public partial class cPrestamoAudiobook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbFecha.Text = DateTime.Now.ToShortDateString();
        }
        protected void DdlMaterialAB_PreRender(object sender, EventArgs e)
        {
            DdlMaterialAB.DataSource = AudiobookBLL.ShowMaterialAudiobook();
            DdlMaterialAB.DataTextField = "MaterialAudiobook";
            DdlMaterialAB.DataValueField = "idMaterial";
            DdlMaterialAB.DataBind();
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
                oPrestamo.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterialAB.SelectedValue);
                oPrestamo.TipoPrestamo.IdTipoPrestamo = Convert.ToInt32(DdlTipoPrestamo.SelectedValue);
                oPrestamo.EmpleadoEntity.IdEmpleado = AdministradorBLL.GetIdAdmin(Session["username"].ToString());
                oPrestamo.VisitanteEntity.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                oPrestamo.FechaPrestamo = Convert.ToDateTime(LbFecha.Text);
                oPrestamo.FechaDevolucion = Convert.ToDateTime(TxtFecha.Text);
                oPrestamo.Cantidad = Convert.ToInt32(TxtCantidadM.Text);

                AudioBookEntity oAB = new AudioBookEntity();
                oAB = AudiobookBLL.GetCantidadAudiobook(oPrestamo.MaterialEntity.IdMaterial);
                int Existencia = (oAB.Cantidad - oAB.Prestado) - oAB.Reservado;
                if ((Existencia > 0 && oPrestamo.Cantidad <= Existencia))
                {
                    oAB.IdMaterial = oPrestamo.MaterialEntity.IdMaterial;
                    oAB.Prestado = PrestamoBLL.InsertEntregaPrestamo(oPrestamo);
                        if (AudiobookBLL.AsiganarCantidadPrestadaAudiobook(oAB))
                        {
                            BibliotecarioEntity oBiblio = new BibliotecarioEntity();
                            oBiblio.IdEmpleado = oPrestamo.EmpleadoEntity.IdEmpleado;
                            oBiblio.CantidadPrestamosRealizados = BibliotecarioBLL.VerificarPrestamoEmpleado(oBiblio.IdEmpleado);
                            if (BibliotecarioBLL.AsignarCantidadPrestamosRealizados(oBiblio))
                            {
                                VisitanteEntity oVisita = new VisitanteEntity();
                                VisitanteEntity oVisitante = new VisitanteEntity();
                                oVisita.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                                oVisita.Prestado = VisitanteBLL.VerificarPrestamosVisitante(oVisita.IdVisitante);
                                oVisitante = VisitanteBLL.GetVisitante(Convert.ToInt32(DdlVisitante.SelectedValue));
                                if (VisitanteBLL.AsignarCantidadPrestamosVisitante(oVisita))
                                {
                                    EnvioCorreoBLL.EnviarCorreo("Audiobook Prestado: ", "Titulo Audiobook:" + " " + oAB.Nombre + " Prestado por: " + BibliotecarioBLL.GetDatosBibliotByCodUsuario(Session["username"].ToString()) + " Que será entregado: " + oPrestamo.FechaDevolucion.ToShortDateString(), oVisitante.Email);
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