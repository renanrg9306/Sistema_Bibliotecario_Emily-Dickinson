using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;
namespace SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Domicilio
{
    public partial class GestionPrestamos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkBtnNLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoLibro.aspx");
        }

        protected void GridVPrestamos_PreRender(object sender, EventArgs e)
        {
            GridVPrestamos.DataSource = PrestamoBLL.ShowPrestamos();
            GridVPrestamos.DataBind();
        }

        protected void LinkBtnNAB_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoAudioBook.aspx");
        }

        protected void LinkBtnNRevista_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoRevista.aspx");
        }

        protected void LinkBtnNPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoPelicula.aspx");
        }

    
        [WebMethod(EnableSession = true)]
        public static object RecepcionarPrestamo(string IdEntrega_Prestamo)
        {
            string msg = "";
            EntregaPrestamoEntity oEP = new EntregaPrestamoEntity();
            MaterialEntity oMaterial = new MaterialEntity();
            oEP = PrestamoBLL.GetCantidadPrestamo(Convert.ToInt32(IdEntrega_Prestamo));
            oMaterial.Prestado = oEP.MaterialEntity.Prestado - oEP.Cantidad;// RETORNONANDO AL VALOR ANTES DEL PRESTAMO VALOR EXISTENCIAL
            oMaterial.IdMaterial = oEP.MaterialEntity.IdMaterial;
            if (MaterialBLL.ActualizarExistenciaMaterialPrestado(oMaterial))
            {
                oEP.POR = true;
                oEP.Fecha_Recepcion = DateTime.Now;
                oEP.Recepcionado_Por = AdministradorBLL.GetDatosAdminByCodUsuario(HttpContext.Current.Session["username"].ToString());
                AdministradorEntity oAdmin = new AdministradorEntity();
                oAdmin.IdEmpleado = oEP.EmpleadoEntity.IdEmpleado;
                oAdmin.CantidadPrestamosRealizados = AdministradorBLL.VerificarPrestamosEmpleados(oAdmin.IdEmpleado) - 1;
                if (PrestamoBLL.UMaterialRecepcionado(oEP))
                {
                    if (AdministradorBLL.AsignarCantidadPrestamos(oAdmin))
                    {
                        VisitanteEntity oVisitante = new VisitanteEntity();
                        oVisitante.IdVisitante = oEP.VisitanteEntity.IdVisitante;
                        oVisitante.Prestado = VisitanteBLL.VerificarPrestamosVisitante(oVisitante.IdVisitante);
                        VisitanteBLL.AsignarCantidadPrestamosVisitante(oVisitante);  
                    }
                    msg = "OK";
                }
                else
                {
                    msg = "Error";
                }

            }
            return new { Result = msg };
            
        }

        protected void LBtnProrroga_Command(object sender, CommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("../Prorroga/Prorroga.aspx?Id="+Id);
        }

        protected void GridVPrestamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}