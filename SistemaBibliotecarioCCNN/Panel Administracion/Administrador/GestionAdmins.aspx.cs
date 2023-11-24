    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data.SqlClient;
using System.Data;
using Entity;
using System.Web.Services;

namespace SistemaBibliotecarioCCNN.Panel_Administracion
{
    public partial class defaultAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void LinkBtnNnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cAdim.aspx");
        }

        protected void GridVAdministrador1_PreRender(object sender, EventArgs e)
        {
            GridVAdministrador1.DataSource = AdministradorBLL.ShowAdmins(Convert.ToString(Session["username"]));
            GridVAdministrador1.DataBind();
        }

        protected void LBtnModifcar_Command(object sender, CommandEventArgs e)
        {

            GridVAdministrador1.Columns[1].Visible = true;
            LbIdAdmin.Text = e.CommandArgument.ToString();
            string Id = LbIdAdmin.Text;
            Response.Redirect("mAdmin.aspx?Id=" + Id);
        }


        [WebMethod(EnableSession = true)]
        public static object DeleteAdmin(string IdEmpleado)
        {
            AdministradorEntity oAdmin = new AdministradorEntity();
            oAdmin.IdEmpleado = Convert.ToInt32(IdEmpleado);
            oAdmin.Estado = false;
            string msg = "";
            if (AdministradorBLL.VerificarPrestamosEmpleados(oAdmin.IdEmpleado) == 0)
            {
                if (AdministradorBLL.DeleteAdmin(oAdmin))
                {
                    msg = "OK";
                }
                else
                {
                    msg = "Error";
                }
            }
            else {
                ScriptManager.RegisterStartupScript((Page)(HttpContext.Current.Handler), typeof(Page), "MisJS", "MensajeError('Usuario no Eliminado, tiene prestamos sin recepcionar','Error');", true);
            
            }
            return new { Result = msg };
        }

        protected void GridVAdministrador1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }


      }

}