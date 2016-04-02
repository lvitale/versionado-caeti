using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_entity;
using versionado_caeti_entity.entity;
using versionado_caeti_entity.enums;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.security
{
   public class ErrorManager
    {
       private static ErrorManager instance=new ErrorManager();
        // constructor privado
       private ErrorManager() { }

        public static ErrorManager getInstance()
        {
            return instance;
        }

        public Message gestionarError(Exception ex)
        {
            Message message=new Message();
            String type = ex.GetType().Name;
            
            switch (type) { 
                case "BitacoraDaoException":
                    writeFile(ex);
                    enviarCorreoMensajeError(ex);
                     break;
                case "DaoException":
                     regsitrarBitacora((SecurityException)ex);
                    break;
                 case "UsuarioException":
                    regsitrarBitacora((SecurityException)ex);
                    break;
                 case "SeguridadException":
                    regsitrarBitacora((SecurityException)ex);
                    break;
                default:
                    regsitrarBitacora(ex.Source,ex.Message,ex.StackTrace);
                    enviarCorreoMensajeError(ex);
                    break; 
            }
            return message;
        }

        private Message createMessage(Exception ex) { 
             Message message = new Message();
             message.description = ex.Message;
             
             return message;
        }
        private void enviarCorreoMensajeError(Exception ex)
        {
            try
            {
                String mensaje = MailManager.getInstance().crearMensajeError(ex);
                MailManager.getInstance().enviarCorreo(MailManager.getInstance().configurarCorreo(mensaje));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
        }
        private void regsitrarBitacora(SecurityException ex)
        {
            regsitrarBitacora(ex.code, ex.Message, ex.StackTrace);
            writeLog(ex);
        }
        private void regsitrarBitacora(String code,String message,String stacktrace) { 
            Log log = new Log();
            log.accion = ActionLogEnum.type.ERROR.ToString().ToLower();
            log.descripcion = message;
            log.fecha = new DateTime();
            log.pila = stacktrace;
            log.usuario = getCurrentUser();
            LogManager.getinstance().registrar(log);

        }

        private Usuario getCurrentUser() {
            Usuario user = null;
            try{
                user =Session.getInstance().obtenerSesionActual();
            if (user == null) {
                user = new Usuario("sistema");
            }
            }catch(Exception){
            }
                return user;
        }
        private void writeFile(Exception ex) {
            String path = "C:\\Users\\pc\\Desktop\\log\\Log.txt";//C:\Users\pc\Desktop\log
            StringBuilder value = new StringBuilder();
            value.Append("Mensaje: ");
            value.Append(ex.Message);
            value.Append(" stacktrace: ");
            value.Append(ex.StackTrace);

            StreamWriter writer;
            try
            {
                if (File.Exists(path))
                {
                    writer = new StreamWriter(File.Open(path, FileMode.OpenOrCreate));
                    writer.WriteLine(value.ToString());
                    writer.Close();
                }
                else
                {
                    writer = new StreamWriter(path, true);
                    writer.WriteLine(value.ToString());
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                writeLog(e);
            }
        
        }

        private void writeLog(Exception ex) {
            
       //     if (ex is Exception) {
       //         LoggerFacade.write(EventLogEntryType.Error ,  ex.Message);
       //     }
       //     LoggerFacade.write(EventLogEntryType.Warning, ex.Message);
            
        }

    }
    
}
