using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.constante
{
   public class VersionadoConstante
    {
       public static string PROCEDURE_CONNECTION_STRING = "Data Source=(localdb)\\local;Initial Catalog=versionado-caeti;Integrated Security=true";

       public const String PAGE_HOME_ADDRESS = "/pages/core/home.aspx",
                           PAGE_ERROR_ADDRESS = "/pages/core/errorpages.aspx",
                           PAGE_VERSION_ADDRESS = "/pages/core/version.aspx";

       public static String EMAIL_APLICACION_RESERVA_HOTELERA = "bando.web.master.lppa.2013@gmail.com";
       public static String EMAIL_ADMINISTRADOR_APLICACION = "luisalejovitale@gmail.com";
       public static String MAIL_MESSAGE_SUBJECT = " ERROR APLICACION RESERVA HOTEL CALIFORNIA";
       public static String MAIL_MESSAGE_BODY = "Ha ocurrido un error en la aplicacion : ";

       public static int USER_INTENT = 3;
    }
}
