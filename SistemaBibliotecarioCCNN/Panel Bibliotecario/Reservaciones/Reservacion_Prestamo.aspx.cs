using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Reservaciones
{
    public partial class Reservacion_Prestamo : System.Web.UI.Page
    {
        EntregaPrestamoEntity oPrestamo = new EntregaPrestamoEntity();
        ReservacionEntity oReservacion = new ReservacionEntity();
        MaterialEntity oMaterial = new MaterialEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    LbFecha.Text = DateTime.Now.ToShortDateString();
                    oReservacion = ReservacionBLL.ReservacionAPrestamo(Convert.ToInt32(Request.QueryString["Id"]));
                    TxtCantidadM.Text = oReservacion.Cantidad.ToString();
                }

            }
        }
        protected void DdlMaterial_PreRender(object sender, EventArgs e)
        {
            DdlMaterial.DataSource = MaterialBLL.ShowMaterial();
            DdlMaterial.DataTextField = "Nombre";
            DdlMaterial.DataValueField = "idMaterial";
            DdlMaterial.DataBind();
            DdlMaterial.SelectedValue = oReservacion.MaterialEntity.IdMaterial.ToString();
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
            DdlMaterial.SelectedValue = oReservacion.VisitanteEntity.IdVisitante.ToString();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionReservaciones.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                oPrestamo.VisitanteEntity.IdVisitante = Convert.ToInt32(DdlVisitante.SelectedValue);
                oPrestamo.MaterialEntity.IdMaterial = Convert.ToInt32(DdlMaterial.SelectedValue);
                oPrestamo.EmpleadoEntity.IdEmpleado = BibliotecarioBLL.GetIdBibliotecario(Session["username"].ToString());
                oPrestamo.TipoPrestamo.IdTipoPrestamo = Convert.ToInt32(DdlTipoPrestamo.SelectedValue);
                oPrestamo.FechaPrestamo = Convert.ToDateTime(LbFecha.Text);
                oPrestamo.Cantidad = Convert.ToInt32(TxtCantidadM.Text);
                oPrestamo.FechaDevolucion = Convert.ToDateTime(TxtFecha.Text);


                oMaterial.IdMaterial = oPrestamo.MaterialEntity.IdMaterial;
                oMaterial.Reservado = oPrestamo.Cantidad;

                if (MaterialBLL.EntregarReservacion(oMaterial))
                {
                    oMaterial = MaterialBLL.GetCantidadMaterial(oPrestamo.MaterialEntity.IdMaterial);
                    int Existencia = oMaterial.Cantidad - (oMaterial.Prestado - oMaterial.Reservado);
                    if (Existencia > 0 && oPrestamo.Cantidad <= Existencia)
                    {
                        oMaterial.Prestado = PrestamoBLL.InsertEntregaPrestamo(oPrestamo);
                        if (MaterialBLL.AsignarCantidadPrestada(oMaterial))
                        {
                            AdministradorEntity oAdmin = new AdministradorEntity();
                            oAdmin.IdEmpleado = oPrestamo.EmpleadoEntity.IdEmpleado;
                            oAdmin.CantidadPrestamosRealizados = AdministradorBLL.VerificarPrestamosEmpleados(oAdmin.IdEmpleado);
                            if (AdministradorBLL.AsignarCantidadPrestamos(oAdmin))
                            {
                                oReservacion.IdResercacion = Convert.ToInt32(Request.QueryString["Id"]);
                                oReservacion.Estado = false;
                                if (ReservacionBLL.EstadoEntregadoReservacion(oReservacion))
                                {
                                    Response.Redirect("GestionReservaciones.aspx");
                                }
                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}