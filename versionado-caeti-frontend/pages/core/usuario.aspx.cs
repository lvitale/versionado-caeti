using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using versionado_caeti_core.bussines;
using versionado_caeti_core.security;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.enums;
using versionado_caeti_entity.exception;

namespace versionado_caeti_frontend.pages.core
{
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            txtPopupIntento.Text = "0";
            if (usuario == null)
            {
                String message = "not have permission to access this page : documento.aspx";
                HttpContext.Current.Session["message"] = message;
                LogManager.getinstance().registrar(message, ActionLogEnum.type.LOGIN.ToString(), "versionado-caeti", null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }

            if (IsPostBack == false)
            {
               
                refresh();
            }

            LogManager.getinstance().registrar(" usuario.aspx visitada por " + usuario.nombre, ActionLogEnum.type.VISITAR.ToString(), "versionado-caeti", null);
          
        }

        protected void grillaDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cleanMessage();
                UsuarioManager.getInstance().agregar(createUser());
                lblMessage.Text = "Se ha ejecutado exitosamente";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;

                refresh();
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

        private Usuario createUser() {
            Usuario newUser = new Usuario();
            newUser.nombre = txtNombre.Text;
            newUser.clave = txtClave.Text;
            newUser.activo = estaActivo.Checked;
            newUser.intentos = Convert.ToInt16(txtIntentos.Text);
            return newUser;
        }

        private void refresh()
        {
            grillaUsuario.DataSource = UsuarioManager.getInstance().consultar(new Usuario());
            grillaUsuario.DataBind();
        }

        protected void btnSaveLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtClave.Text = String.Empty;
            txtIntentos.Text = String.Empty;
            estaActivo.Checked = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cleanMessage();
                grillaUsuario.DataSource = UsuarioManager.getInstance().consultar(txtBuscar.Text);
                grillaUsuario.DataBind();
                lblMessage.Text = "Se ha ejecutado exitosamente";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;


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

        protected void modify(object sender, CommandEventArgs e)
        {
            cleanMessage();
            string[] row = e.CommandArgument.ToString().Split(';');
            txtPopupNombre.Text = row[0];
            txtPopupIntento.Text = row[2];
            activoPopup.Checked = Convert.ToBoolean(row[1]);
            txtPopupClave.Text = UsuarioManager.getInstance().getMaskPasword(); 
            modal.Show();


        }
        protected void delete(object sender, CommandEventArgs e)
        {
            cleanMessage();
            string userId = e.CommandArgument.ToString();
            
            try
            {
                UsuarioManager.getInstance().eliminar(new Usuario());
                lblMessage.Text = "Se ha ejecutado exitosamente";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;

                refresh();
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
        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        /**    POPUP**/
        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void modifyPopup_Click(object sender, EventArgs e)
        {
            try {
                cleanMessage();
                UsuarioManager.getInstance().modificar(createUserPopup());
                lblPopupMessage.Text = "Se ha ejecutado exitosamente";
                lblPopupMessage.Visible = true;
                lblPopupMessage.ForeColor = Color.Green;
                refresh();
            }
            catch (SecurityException ex)
            {
                lblPopupMessage.Text = ex.Message;
                lblPopupMessage.Visible = true;
                lblPopupMessage.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                lblPopupMessage.Text = ex.Message;
                lblPopupMessage.Visible = true;
                lblPopupMessage.ForeColor = Color.Red;
            }
            finally
            {

            }
              
        }

        protected void cancelPopup_Click(object sender, EventArgs e)
        {

        }

        private Usuario createUserPopup() {
            Usuario user = new Usuario();
            user.nombre = txtPopupNombre.Text;
            user.intentos =Convert.ToInt16(txtPopupIntento.Text);
            user.activo = activoPopup.Checked;
            user.clave = txtPopupClave.Text;
            return user;
        }

        private void cleanMessage() {
            lblMessage.Text = String.Empty;
            lblPopupMessage.Text = String.Empty;
        }
    }
}