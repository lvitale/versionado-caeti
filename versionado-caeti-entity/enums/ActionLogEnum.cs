using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.enums
{
   public class ActionLogEnum
    {
         public enum type { 
            ERROR,
            LOGIN,
            LOGOUT,
            BACKUP,
            RESTORE,
            MODIFICAR,
            ELIMINAR,
            INSERTAR,
            CONSULTAR,
            VISITAR
       }

       public static List<String> getAllActions()
       {
           List<String> listado = new List<String>();
           listado.Add(type.ERROR.ToString().ToLower());
           listado.Add(type.LOGIN.ToString().ToLower());
           listado.Add(type.LOGOUT.ToString().ToLower());

           listado.Add(type.BACKUP.ToString().ToLower());
           listado.Add(type.RESTORE.ToString().ToLower());

           listado.Add(type.MODIFICAR.ToString().ToLower());
           listado.Add(type.ELIMINAR.ToString().ToLower());
           listado.Add(type.INSERTAR.ToString().ToLower());

           return listado;
       }
    }
}

