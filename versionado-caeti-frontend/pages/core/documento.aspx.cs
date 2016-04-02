using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using versionado_caeti_core;
using versionado_caeti_core.bussines;
using versionado_caeti_core.security;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.enums;
using versionado_caeti_entity.exception;

namespace versionado_caeti_frontend.pages.core
{
    public partial class documento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
           
            if (usuario == null)
            {
                String message = "not have permission to access this page : documento.aspx";
                HttpContext.Current.Session["message"] = message; 
                LogManager.getinstance().registrar( message,ActionLogEnum.type.LOGIN.ToString(),"versionado-caeti",null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }

            if (IsPostBack == false)
            {
                grillaDocumento.DataSource = DocumentoManager.getInstance().consultarDocumento(new Documento());

                comboTipo.DataTextField = "area";
                comboTipo.DataValueField = "codigo";

                comboPopupTipo.DataTextField = "area";
                comboPopupTipo.DataValueField = "codigo";

                List<Tipo> tipos = TipoManager.getInstance().consultarTodos();
                comboTipo.DataSource = tipos;
                comboPopupTipo.DataSource = tipos;

                grillaDocumento.DataBind();
                comboTipo.DataBind();
                comboPopupTipo.DataBind();
            }
            
            LogManager.getinstance().registrar(" documento.aspx visitada por " + usuario.nombre, ActionLogEnum.type.VISITAR.ToString(), "versionado-caeti", null);
                
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentoManager.getInstance().agregar(createDocumento());
                lblMessage.Text ="Se ha ejecutado exitosamente";
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

        private Documento createDocumento() {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            Documento item = new Documento();
            item.auditoria.usuario = usuario;
            item.auditoria.fechaRegistro = DateTime.Now;

            item.descripcion = txtDescripcion.Text;
            item.nombre = txtNombre.Text;
            item.tipo.codigo =Convert.ToInt16( comboTipo.SelectedValue);
            
            return item;
        }
        private void refresh() {
            grillaDocumento.DataSource = DocumentoManager.getInstance().consultarDocumento(new Documento());
            grillaDocumento.DataBind();
        }
        protected void btnSaveLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            cleanMessage();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                grillaDocumento.DataSource=DocumentoManager.getInstance().consultar(txtBuscar.Text);
                grillaDocumento.DataBind();
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

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;
            cleanMessage();
            refresh();
        }

        protected void grillaDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            String ids = grillaDocumento.SelectedItem.Cells[0].Text;
            String nombre = grillaDocumento.SelectedItem.Cells[1].Text;    
            Console.WriteLine("ejecuta" );
            HttpContext.Current.Session["document_id"] =ids;
            HttpContext.Current.Session["document_nombre"] = nombre;

            Response.Redirect(VersionadoConstante.PAGE_VERSION_ADDRESS);
        }

       
        protected void modify(object sender, CommandEventArgs e)
        {
           
            cleanMessage();
            string[] row = e.CommandArgument.ToString().Split(';');
            Int16 docId = Convert.ToInt16(row[0]);
            Documento old = DocumentoManager.getInstance().consultarId(docId);
            
            txtPopupNombre.Text = old.nombre;
            txtPopupDescripcion.Text = old.descripcion;

            List<Tipo> tipos = TipoManager.getInstance().consultarTodos();
            List<Tipo> ordenado = tipos.OrderByDescending(x=> x.codigo == old.tipo.codigo).ToList();
            comboPopupTipo.DataSource = ordenado;
            comboPopupTipo.DataBind();
            lblId.Text = Convert.ToString(old.id);
            modal.Show();
               

        }
        protected void delete(object sender, CommandEventArgs e)
        {
            string name = e.CommandName.ToString();
            string[] row = e.CommandArgument.ToString().Split(';');
            Int16 id =Convert.ToInt16(row[0]);
            try
            {
                DocumentoManager.getInstance().eliminar(new Documento(id));
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
        protected void viewdetails(object sender, CommandEventArgs e)
        {
            string val1 = e.CommandName.ToString();

            string[] row = e.CommandArgument.ToString().Split(';');

            String ids = row[0];
            String nombre = row[1];
            Console.WriteLine("ejecuta");
            HttpContext.Current.Session["document_id"] = ids;
            HttpContext.Current.Session["document_nombre"] = nombre;

            Response.Redirect(VersionadoConstante.PAGE_VERSION_ADDRESS);

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
            try
            {
                cleanMessage();
                DocumentoManager.getInstance().modificar(createDocumentPopup());
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

        private Documento createDocumentPopup()
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];

            Documento doc = new Documento();
            doc.id = Convert.ToInt16(lblId.Text);
            doc.nombre = txtPopupNombre.Text;
            doc.descripcion = txtPopupDescripcion.Text;
            doc.tipo.codigo = Convert.ToInt16(comboPopupTipo.SelectedValue);

            doc.auditoria.usuario = usuario;
            doc.auditoria.fechaRegistro = DateTime.Now;

            return doc;
        }

        private void cleanMessage()
        {
            lblMessage.Text = String.Empty;
            lblPopupMessage.Text = String.Empty;
        }
    }
}