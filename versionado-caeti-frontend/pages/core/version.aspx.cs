

using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using versionado_caeti_core.bussines;
using versionado_caeti_core.security;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.enums;
using versionado_caeti_entity.exception;
using versionado_caeti_core;
using versionado_caeti_core.utils;
using System.Web.UI.WebControls;
namespace versionado_caeti_frontend.pages.core
{
    public partial class version : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            String ids = (String)HttpContext.Current.Session["document_id"];
            String nombre = (String)HttpContext.Current.Session["document_nombre"];

            lblHeader.Text = nombre;
            // Verifica que el usuario este logueado y exista
            if (usuario == null)
            {
                String message = "not have permission to access this page : versionado.aspx";
                HttpContext.Current.Session["message"] = message;
                LogManager.getinstance().registrar(message, ActionLogEnum.type.LOGIN.ToString(), "versionado-caeti", null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }
            // Verifica que se halla informado el documento correspondiente
            if (ids == null)
            {
                String message = "No se ingreso correctamente a la pagina";
                HttpContext.Current.Session["message"] = message;
                LogManager.getinstance().registrar(message, ActionLogEnum.type.LOGIN.ToString(), "versionado-caeti", null);
                Response.Redirect(VersionadoConstante.PAGE_ERROR_ADDRESS);
            }
            // Guardo el objeto documento en sesion
            List<Documento> documentos = DocumentoManager.getInstance().consultar(Convert.ToInt16(ids));
            HttpContext.Current.Session["documento_item"] = documentos.First();
            if (!this.IsPostBack)
            {
                // refresca la grilla
                refreshGrid();
                // Refresca la version en pantalla
                refreshLastVersion();

                comboEstado.DataTextField = "descripcion";
                comboEstado.DataValueField = "codigo";

                comboPopupEstado.DataTextField = "descripcion";
                comboPopupEstado.DataValueField = "codigo";

                comboEstado.DataSource = EstadoManager.getInstance().consultar(new Estado());
                comboEstado.DataBind();
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Uploader.HasFile)
                {
                    VersionManager.getInstance().agregar(createVersion());
                    lblMessage.Text = "Se ha ejecutado exitosamente";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.Green;
                    refreshGrid();
                    refreshLastVersion();
                    txtObervacion.Text = String.Empty;
                }
                else
                {
                    lblMessage.Text = "Por favor agruege un archivo";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.Red;
                }
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


        private Versionado createVersion()
        {
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            Documento documento = (Documento)HttpContext.Current.Session["documento_item"];
            Versionado item = new Versionado();
            item.auditoria.usuario = usuario;
            item.observacion = txtObervacion.Text;
            item.auditoria.fechaRegistro = DateTime.Now;
            item.documento.id = Convert.ToInt16((String)HttpContext.Current.Session["document_id"]);
            item.activo = true;
            item.version = Convert.ToInt16(txtVersion.Text);
            item.subversion = Convert.ToInt16(txtsubversion.Text);
            item.nombre = documento.nombre;
            item.estado.codigo = Convert.ToInt16(comboEstado.SelectedValue);
            
            if (Uploader.HasFile)
            {
                item.nombreOriginal = Uploader.PostedFile.FileName;
                item.tipoContenido = Uploader.PostedFile.ContentType;
                VersionManager.getInstance().armarNombreVersion(item);

                using (Stream fs = Uploader.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        item.archivo = br.ReadBytes((Int32)fs.Length);
                    }
                }
            }
           return item;
        }
        private void refreshGrid()
        {
           
            String ids = (String)HttpContext.Current.Session["document_id"];
            int id = Convert.ToInt16(ids);
            List<Versionado> listado = VersionManager.getInstance().consultarPorDoc(id);
            grillaVersion.DataSource = listado;
            grillaVersion.DataBind();
            
        }

        protected void btnSaveLimpiar_Click(object sender, EventArgs e)
        {
            txtObervacion.Text = String.Empty;
           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
               
                grillaVersion.DataSource = VersionManager.getInstance().consultar(Convert.ToInt16((String)HttpContext.Current.Session["document_id"]),txtBuscar.Text);
                grillaVersion.DataBind();
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

        }

        protected void grillaVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ids = Convert.ToInt16(grillaVersion.SelectedItem.Cells[4].Text);
                Versionado item = VersionManager.getInstance().consultar(ids);
               downloadFile(item);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Red;

            }
        }

        private void downloadFile(Versionado item)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = item.tipoContenido;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + VersionManager.getInstance().armarNombre(item));
            Response.BinaryWrite(item.archivo);
            Response.Flush();
            Response.End();
        }
 
        private void refreshLastVersion() {
             String ids = (String)HttpContext.Current.Session["document_id"];
             int id = Convert.ToInt16(ids);
            List<Versionado> listado = VersionManager.getInstance().consultarPorDoc(id);
            if (listado == null || listado.Count < 1)
            {
                txtVersion.Text = "1";
                txtsubversion.Text = "1";
            }
            else
            {
                Int16 ultimaVersion = listado.Max(x => x.version);
                List<Versionado> ulimaVersionesOrdenadas = listado.FindAll(x => x.version == ultimaVersion).ToList();
                Int16 ultimaSubversion = ulimaVersionesOrdenadas.Max(x => x.subversion);

                if (ultimaSubversion == 9)
                {
                    txtVersion.Text = (ultimaVersion + 1).ToString();
                    txtsubversion.Text = "1";
                }
                else {
                    txtVersion.Text = ultimaVersion.ToString();
                    txtsubversion.Text = (ultimaSubversion + 1).ToString();  
                }
            }


            
        }

        protected void nextVersion_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            refreshLastVersion();

            Int16 number = Convert.ToInt16(txtVersion.Text);
            number++;
            txtVersion.Text = number.ToString();
            txtsubversion.Text = "1"; 

        }

        protected void backVersion_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            refreshLastVersion();
        }

        protected void modify(object sender, CommandEventArgs e)
        {
            cleanMessage();
            string[] row = e.CommandArgument.ToString().Split(';');
            Int16 versId = Convert.ToInt16(row[0]);
            Versionado old = VersionManager.getInstance().consultar(versId);
            
            txtPopupNombre.Text = old.nombre;
            txtPopupObservacion.Text = old.observacion;
            idpopup.Text = Convert.ToString(versId);

            List<Estado> estado = EstadoManager.getInstance().consultar(new Estado());
            List<Estado> ordenado = estado.OrderByDescending(x => x.codigo == old.estado.codigo).ToList();
            comboPopupEstado.DataSource = ordenado;
            comboPopupEstado.DataBind();
            idpopup.Text = Convert.ToString(old.id);

            HttpContext.Current.Session["versionado"] = old;
            modal.Show();

        }
        protected void delete(object sender, CommandEventArgs e)
        {
            string name = e.CommandName.ToString();
            string[] row = e.CommandArgument.ToString().Split(';');
            Int16 id = Convert.ToInt16(row[0]);
            try
            {
                VersionManager.getInstance().eliminar(new Versionado(id));
                lblMessage.Text = "Se ha ejecutado exitosamente";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;

                refreshGrid();
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
        protected void download(object sender, CommandEventArgs e)
        {
            string val1 = e.CommandName.ToString();

            string[] row = e.CommandArgument.ToString().Split(';');

            String id = row[0];
            String nombre = row[1];

            try
            {
                int ids = Convert.ToInt16(id);
                Versionado item = VersionManager.getInstance().consultar(ids);
                downloadFile(item);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Red;

            }

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
                VersionManager.getInstance().modificar(createVersionPopup());
                lblPopupMessage.Text = "Se ha ejecutado exitosamente";
                lblPopupMessage.Visible = true;
                lblPopupMessage.ForeColor = Color.Green;
                refreshGrid();
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

        private Versionado createVersionPopup()
        {
            
            Usuario usuario = (Usuario)HttpContext.Current.Session["usuario"];
            Documento documento = (Documento)HttpContext.Current.Session["documento_item"];
            Versionado item  = (Versionado)HttpContext.Current.Session["versionado"];
            
            item.auditoria.usuario = usuario;
            item.observacion = txtPopupObservacion.Text;
            item.auditoria.fechaRegistro = DateTime.Now;
            item.documento.id = Convert.ToInt16((String)HttpContext.Current.Session["document_id"]);
            item.activo = true;
            
            item.estado.codigo = Convert.ToInt16(comboPopupEstado.SelectedValue);
            
            if (UpPopupLoader.HasFile)
            {
                item.nombreOriginal = UpPopupLoader.PostedFile.FileName;
                item.tipoContenido = UpPopupLoader.PostedFile.ContentType;
                VersionManager.getInstance().armarNombreVersion(item);

                using (Stream fs = UpPopupLoader.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        item.archivo = br.ReadBytes((Int32)fs.Length);
                    }
                }
            }
           return item;
        }
        

        private void cleanMessage()
        {
            lblMessage.Text = String.Empty;
            lblPopupMessage.Text = String.Empty;
        }

        private void refresh()
        {
            grillaVersion.DataSource = DocumentoManager.getInstance().consultar(new Documento());
            grillaVersion.DataBind();
        }

    }
}