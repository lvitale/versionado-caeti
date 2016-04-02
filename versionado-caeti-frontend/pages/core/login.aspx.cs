using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using versionado_caeti_core;
using versionado_caeti_core.security;
using versionado_caeti_entity;
using versionado_caeti_entity.exception;

namespace versionado_caeti_frontend.pages.core
{
    
    public partial class login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                LoginManager.getinstance().ingresar(txtUsuario.Text, txtPassword.Text);

                Response.Redirect("/pages/core/documento.aspx", false);
                Usuario usuario = new Usuario();
                usuario.nombre = txtUsuario.Text;
                HttpContext.Current.Session["usuario"] = usuario;
                
            }
            catch (SecurityException ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Red;
            }
            finally
            {

            }
        }
    }
}