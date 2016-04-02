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
    public partial class tiposDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];

            if (usuario == null)
            {
                String message = "not have permission to access this page : tipoDocumento.aspx";
                HttpContext.Current.Session["message"] = message;
                LogManager.getinstance().registrar(message, ActionLogEnum.type.LOGIN.ToString(), "versionado-caeti", null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }
            if (IsPostBack == false)
            {
                grillaTipo.DataSource = TipoManager.getInstance().consultar(new Tipo());
                grillaTipo.DataBind();
            }
        }

        protected void modify(object sender, CommandEventArgs e)
        {
            string val1 = e.CommandName.ToString();

            string[] othervals = e.CommandArgument.ToString().Split(',');

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
            TxtDescripcion.Text = String.Empty;
            txtArea.Text = String.Empty;
            cleanMessage();
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;
            cleanMessage();
            refresh();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TipoManager.getInstance().agregar(createTipo());
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                grillaTipo.DataSource = TipoManager.getInstance().consultar(txtBuscar.Text);
                grillaTipo.DataBind();
                lblPopupMessage.Text = "Se ha ejecutado exitosamente";
                lblPopupMessage.Visible = true;
                lblPopupMessage.ForeColor = Color.Green;


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

        protected void grillaDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Tipo createTipo()
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            Tipo item = new Tipo();
           
            item.descripcion = TxtDescripcion.Text;
            item.area = txtArea.Text;
          
            return item;
        }
        private void refresh()
        {
            grillaTipo.DataSource =TipoManager.getInstance().consultar(new Tipo());
            grillaTipo.DataBind();
        }

        private void cleanMessage()
        {
            lblMessage.Text = String.Empty;
            lblPopupMessage.Text = String.Empty;

        }
    }
}