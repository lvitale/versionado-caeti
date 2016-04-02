using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.entity;

namespace versionado_caeti_core.security
{
   public class MailManager
    {
        private static MailManager instance = new MailManager();
       private MailManager() { }

       public static MailManager getInstance()
       {
            return instance;
        }

       public void enviarCorreo(Mail correo)
       {
           MailMessage mailMessage = new MailMessage();
           try
           {
               mailMessage.From = correo.source;
               mailMessage.To.Add(correo.destination);
               mailMessage.Subject = correo.subject;
               mailMessage.Body = correo.body;
               SmtpClient client = new SmtpClient();
               client.EnableSsl = true;
               client.DeliveryMethod = SmtpDeliveryMethod.Network;
               // envia el correo
               // <network host="smtp.gmail.com" userName="reserva.hotel.california@gmail.com" password="campo2014" port="587" />
               /** https://www.google.com/settings/security  **/
               client.Send(mailMessage);
           }
           catch (Exception ex) {
               //GestorErroresFacade.getInstance().gestionarError(ex);
               Console.WriteLine(ex.Message);
           }
       }
       public Mail configurarCorreo(String body)
       {
               Mail newMail = new Mail();
               newMail.source = new MailAddress(VersionadoConstante.EMAIL_APLICACION_RESERVA_HOTELERA);
               newMail.destination = new MailAddress(VersionadoConstante.EMAIL_ADMINISTRADOR_APLICACION);
               newMail.subject = VersionadoConstante.MAIL_MESSAGE_SUBJECT;
               newMail.body = body ;
               return newMail;
               
           }

       public String crearMensajeError(Exception ex) {
           StringBuilder mensaje = new StringBuilder();
           DateTime now = DateTime.Today;
           
           mensaje.Append(" Ha ocurrio un error en la aplicacion \r\n");
           mensaje.Append(" hora       : " + String.Format("{0:dddd, MMMM d, yyyy}", now) + " \r\n  ");
           mensaje.Append("------------------------------------------ \r\n");
           mensaje.Append(" Mensaje    : " + ex.Message + " \r\n ");
           mensaje.Append(" Origen     : " + ex.Source + " \r\n ");
           mensaje.Append(" Exception  : " + ex.TargetSite.GetType().Name + " \r\n ");
           mensaje.Append(" Clase      : " + ex.GetType().Name + " \r\n  ");
           mensaje.Append("------------------------------------------ \r\n");
           mensaje.Append(" StakeTrace : " + ex.StackTrace + " \r\n ");
           mensaje.Append("------------------------------------------ \r\n");
           return mensaje.ToString();
       }
    }
    
}
