using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Entity;
using System.Web.Services;

namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class GestionBibliotecario : System.Web.UI.Page
    {
        BibliotecarioEntity oBiblio = new BibliotecarioEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

       
        protected void LinkBtnNnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cBibliotecario.aspx");
        }

        protected void LnkBtnActualizar_Command(object sender, CommandEventArgs e)
        {
            GridVBibliotecario.Columns[1].Visible = true;
            LbIdBibliotecario.Text = e.CommandArgument.ToString();
            string Id = LbIdBibliotecario.Text;
            Response.Redirect("mBibliotecario.aspx?Id=" + Id);
        }

    
        protected void GridVBibliotecario_PreRender(object sender, EventArgs e)
        {
            GridVBibliotecario.DataSource = BibliotecarioBLL.ShowBibliotecarios();
            GridVBibliotecario.DataBind();
        }

        protected void LnkBtnEliminar_Command(object sender, CommandEventArgs e)
        {

            GridVBibliotecario.Columns[2].Visible = true;
            LbIdEmpleado.Text = e.CommandArgument.ToString();
            oBiblio.IdEmpleado = Convert.ToInt32(LbIdEmpleado.Text);

            if (BibliotecarioBLL.DeleteBibliotecario(oBiblio))
            {
                Response.Redirect("GestionBibliotecario.aspx");
            }
        }

        [WebMethod(EnableSession = true)]
        public static object DeleteBibliotecario(string IdEmpleado)
        {
            BibliotecarioEntity oBibliotecario = new BibliotecarioEntity();
            oBibliotecario.IdEmpleado = Convert.ToInt32(IdEmpleado);
            oBibliotecario.Estado = false;
            string msg = "";
            if (BibliotecarioBLL.VerificarPrestamoEmpleado(oBibliotecario.IdBibliotecario) == 0)
            { 
                if (BibliotecarioBLL.DeleteBibliotecario(oBibliotecario))
                {
                    msg = "OK";
                }
                else {
                    msg = "Error";
                }
            }
            return new { Result = msg };
        }

        protected void GridVBibliotecario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}