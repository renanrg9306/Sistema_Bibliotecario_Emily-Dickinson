using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Recepcion_de_Material
{
    public partial class RecepcionMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridVPrestamosRecepcionados_PreRender(object sender, EventArgs e)
        {
            GridVPrestamosRecepcionados.DataSource = PrestamoBLL.MaterialRecepcionado();
            GridVPrestamosRecepcionados.DataBind();
        }

        protected void GridVPrestamosRecepcionados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}