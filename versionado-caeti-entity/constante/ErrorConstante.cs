using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.constante
{
    public class ErrorConstante
    {
        //Error general de exception 
        public static String ERROR_EXCEPTION_NO_ESPERADA_101 = "Exception no esperada";
        // Error de base de datos;
        public static string  ERROR_DB_201="No se puede conectar a la base de datos";
        public static string ERROR_IN_301 = "Base de datos corrupta";
        //Error de idioma
        public static String ERROR_IDIOMA_401 = "No se pudo actualizar el idioma";
        public static String ERROR_IDIOMA_402 = "Idioma ya existe";
        public static String ERROR_IDIOMA_404 = "Idioma No existe";
        public static String ERROR_IDIOMA_405 = "No se puede eliminar el idioma.Hay usuarios que poseen este idioma";
        // Error de usuario
        public static string WARNING_USUARIO_501 = "Usuario o clave invalida";
        public static string WARNING_USUARIO_502 = "Usuario bloqueado , por favor contactese con el administrador";
        public static string WARNING_USUARIO_503 = "Por favor complete el usuario o la clave";
        public static string WARNING_USUARIO_504 = "El usuario no existe";
        public static string WARNING_USUARIO_505 = "El usuario ya existe";
        public static string WARNING_USUARIO_506 = "No se ha modificado ningun dato ";
        //Error de Leyenda
        public static String ERROR_LEYENDA_601 = "No se pudo actualizar La leyenda";
        public static String ERROR_LEYENDA_602 = "Leyenda ya existe";
        public static String ERROR_LEYENDA_602_NAME = "Leyenda_existe";
        public static String ERROR_LEYENDA_603 = "Leyenda No existe";
       // Error de documento
        public static string WARNING_DOCUMENTO_903 = "Por favor complete el formulario";
        public static string WARNING_DOCUMENTO_904 = "El documento no existe";
         public static string WARNING_DOCUMENTO_906 = "No se ha modificado ningun dato ";
        // Error general de formulario
        public static string ERROR_EXCEPTION_FORMULARIO = "Por favor vuelva a intertarlo mas tarde";
        public static string ERROR_EXCEPTION_INSERT_DELETE_UPDATE = "No se pudo ejecutar la operacion";
        // errores de BACKUP
        public static string WARNING_BACKUP_401 = "Direccion o nombre invalido";
        public static string WARNING_BACKUP_402 = "No se pudo ejecutar el backup";
        // warning generales
        public static string WARNING_GENERAL_601= "Por favor complete los casilleros ";
        
        public static string WARNING_PERMISO_701 = "No se modifcaron los permisos";
        public static string WARNING_PERMISO_702 = "Por favor agregue los permisos";
        public static string WARNING_PERMISO_703 = "No esta el permiso en la base";
        public static string WARNING_PERMISO_704 = "No se puede eliminar el perfil.Hay usuarios que poseen este perfil";

        public static string WARNING_PERFIL_EXISTE = "El perfil no existe";
        public static string WARNING_PERFIL_EXISTE_MESSAGE = "perfilExiste";

    }
}
