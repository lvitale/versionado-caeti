using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using versionado_caeti_core.security;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.enums;

namespace versionado_caeti_frontend.pages.master_page
{
    public partial class _default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            if (usuario != null)
            {
                lblUsuario.Visible = true;
                txtNameUser.Text = usuario.nombre;
                txtNameUser.Visible = true;
                btnLogout.Visible = true;
            }
            else
            {
                lblUsuario.Visible = false;
                txtNameUser.Text = null;
                txtNameUser.Visible = false;
                btnLogout.Visible = false;
            }
            
        
            

            }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["usuario"] = null;
            Response.Redirect("/pages/core/home.aspx", false);

        }
    }
}