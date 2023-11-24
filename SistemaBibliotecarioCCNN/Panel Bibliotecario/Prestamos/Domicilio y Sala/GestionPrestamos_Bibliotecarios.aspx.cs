using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;

namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala
{
    public partial class GestionPrestamos_Bibliotecarios : System.Web.UI.Page
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
            Response.Redirect("cPrestamoAudiobook.aspx");
        }

        protected void LinkBtnNRevista_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoRevista.aspx");
        }

        protected void LinkBtnNPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("cPrestamoPelicula.aspx");
        }

        protected void LBtRecepcionar_Command(object sender, CommandEventArgs e)
        {
            int idEntrega_Prestamo = Convert.ToInt32(e.CommandArgument.ToString());
            try
            {
                //if(Convert.ToBoolean(ConfirmMaRecep.Text)==true){ 
                EntregaPrestamoEntity oEP = new EntregaPrestamoEntity();
                MaterialEntity oMaterial = new MaterialEntity();
                oEP = PrestamoBLL.GetCantidadPrestamo(idEntrega_Prestamo);
                oMaterial.Prestado = oEP.MaterialEntity.Prestado - oEP.Cantidad;// RETORNONANDO AL VALOR ANTES DEL PRESTAMO VALOR EXISTENCIAL
                oMaterial.IdMaterial = oEP.MaterialEntity.IdMaterial;
                if (MaterialBLL.ActualizarExistenciaMaterialPrestado(oMaterial))
                {
                    oEP.POR = true;
                    oEP.Fecha_Recepcion = DateTime.Now;
                    oEP.Recepcionado_Por = BibliotecarioBLL.GetDatosBibliotByCodUsuario(Session["username"].ToString());

                    if (PrestamoBLL.UMaterialRecepcionado(oEP))
                    {
                        BibliotecarioEntity oBibliotecario = new BibliotecarioEntity();
                        oBibliotecario.IdEmpleado = oEP.EmpleadoEntity.IdEmpleado;
                        oBibliotecario.CantidadPrestamosRealizados = BibliotecarioBLL.VerificarPrestamoEmpleado(oBibliotecario.IdEmpleado) - 1 ;
                        if (BibliotecarioBLL.AsignarCantidadPrestamosRealizados(oBibliotecario))
                        {
                            Response.Redirect("GestionPrestamos_Bibliotecarios.aspx");
                        }
                       
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
                oEP.Recepcionado_Por = BibliotecarioBLL.GetDatosBibliotByCodUsuario(HttpContext.Current.Session["username"].ToString());
                BibliotecarioEntity oBibliotecario = new BibliotecarioEntity();
                oBibliotecario.IdEmpleado = oEP.EmpleadoEntity.IdEmpleado;
                oBibliotecario.CantidadPrestamosRealizados = BibliotecarioBLL.VerificarPrestamoEmpleado(oBibliotecario.IdEmpleado) - 1;
                if (PrestamoBLL.UMaterialRecepcionado(oEP))
                {            
                    if (BibliotecarioBLL.AsignarCantidadPrestamosRealizados(oBibliotecario))
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
            Response.Redirect("../Prorroga/Prorroga.aspx?Id=" + Id);
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