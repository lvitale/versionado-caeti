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
    public partial class estado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];

            if (usuario == null)
            {
                String message = "not have permission to access this page : documento.aspx";
                HttpContext.Current.Session["message"] = message;
                LogManager.getinstance().registrar(message, ActionLogEnum.type.LOGIN.ToString(), "versionado-caeti", null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }

            if (IsPostBack == false)
            {
                grillaEstado.DataSource = EstadoManager.getInstance().consultar(new Estado());
                grillaEstado.DataBind();

            }

            LogManager.getinstance().registrar(" estado.aspx visitada por " + usuario.nombre, ActionLogEnum.type.VISITAR.ToString(), "versionado-caeti", null);
      
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cleanMessage();
                EstadoManager.getInstance().agregar(createEstado());
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

        private void refresh()
        {
            grillaEstado.DataSource = EstadoManager.getInstance().consultar(new Estado());
            grillaEstado.DataBind();
        }

        private Estado createEstado()
        {
           
            Estado item = new Estado();
            
            item.descripcion = txtDescripcion.Text;
            return item;
        }

        protected void modify(object sender, CommandEventArgs e)
        {
           

        }
        protected void delete(object sender, CommandEventArgs e)
        {
            string name = e.CommandName.ToString();
            string[] row = e.CommandArgument.ToString().Split(';');
            Int16 id = Convert.ToInt16(row[0]);
            try
            {
                TipoManager.getInstance().eliminar(new Tipo(id));
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

        protected void btnSaveLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = String.Empty;
            refresh();
            cleanMessage();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                grillaEstado.DataSource = EstadoManager.getInstance().consultar(txtBuscar.Text);
                grillaEstado.DataBind();
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

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;
        }

        protected void grillaEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cleanMessage() {
            lblMessage.Text = String.Empty;
            lblPopupMessage.Text = String.Empty;

        }

       
    }
}