using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;


namespace SistemaBibliotecarioCCNN.Panel_Administracion.Anio
{
    public partial class cAnio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        //protected void BtnGuardar_Click(object sender, EventArgs e)
        //{
        //    AnioEntity oAnio = new AnioEntity();
        //    oAnio.Anio = Convert.ToInt32(TxtAnio.Text);
        //    oAnio.Estado = true;
        //    if (AnioBLL.InsertAnio(oAnio))
        //    {
        //        object refUrl = ViewState["RefUrl"];
        //        if (refUrl != null)
        //            Response.Redirect((string)refUrl);
        //    }
        //}
    }
}