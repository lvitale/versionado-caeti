using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.constante
{
    public class BaseDatoConstante
    {
        // nombre de la base de datos
        public static String NAME_DATABASE_VERSIONADO_CAETI = "seguridaddatabase";
        public static String NAME_DATABASE_BACKUP_SEGURIDAD_RESERVA = "seguridaddatabase";
        public static String NAME_DATABASE_BACKUP_HOTEL_RESERVA = "seguridaddatabase"; 
        public static String NAME_DATABASE_MASTER = "master";
        // CAMPO TABLA USUARIO
        public static String PROPERTY_TABLE_USUARIO_ID = "ID";
        public static String PROPERTY_TABLE_USUARIO_NOMBRE = "NOMBRE";
        public static String PROPERTY_TABLE_USUARIO_CLAVE = "CLAVE";
        public static String PROPERTY_TABLE_USUARIO_INTENTOS = "INTENTOS";
        public static String PROPERTY_TABLE_USUARIO_ACTIVO = "ACTIVO";
        public static String NAME_DATABASE_SEGURIDAD_CORREO_ELECTRONICO = "CORREO";
        // CAMPO TABLA AUDITORIA
        public static String PROPERTY_TABLE_AUDITORIA_USUARIO = "USUARIO_ID";
        public static String PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO = "FECHA_REGISTRO";
        
        // CAMPO TABLA  DOCUMENTO
        public static String PROPERTY_TABLE_DOCUMENTO_ID = "ID";
        public static String PROPERTY_TABLE_DOCUMENTO_NOMBRE = "NOMBRE";
        public static String PROPERTY_TABLE_DOCUMENTO_EXTENSION = "EXTENSION";
        public static String PROPERTY_TABLE_DOCUMENTO_DESCRIPCION = "DESCRIPCION";
        public static String PROPERTY_TABLE_DOCUMENTO_TIPO_ID = "TIPO_ID";
        public static String PROPERTY_TABLE_DOCUMENTO_ACTIVO = "ACTIVO";

       // CAMPO TABLA VERSION
        public static String PROPERTY_TABLE_VERSION_ID = "ID";
        public static String PROPERTY_TABLE_VERSION_VERSION_ = "VERSION";
        public static String PROPERTY_TABLE_VERSON_SUBVERSION = "SUBVERSION";
        public static String PROPERTY_TABLE_VERSION_ESTADO = "ESTADO_ID";
        public static String PROPERTY_TABLE_VERSION_ARCHIVO = "ARCHIVO";
        public static String PROPERTY_TABLE_VERSION_DOCUMENTO = "DOCUMENTO_ID";
        public static String PROPERTY_TABLE_VERSION_NOMBRE = "NOMBRE";
        public static String PROPERTY_TABLE_VERSION_OBSERVACION = "OBSERVACION";
        public static String PROPERTY_TABLE_VERSION_EXTENSION = "EXTENSION";
        public static String PROPERTY_TABLE_VERSION_NOMBRE_ORIGINAL = "NOMBRE_ORIGINAL";
        public static String PROPERTY_TABLE_VERSION_TIPO_CONTENIDO = "TIPO_CONTENIDO";
        public static String PROPERTY_TABLE_VERSION_ESTADO_ID = "ESTADO_ID";
        // CAMPO TABLA TIPO
        public static String PROPERTY_TABLE_TIPO_ID = "ID";
        public static String PROPERTY_TABLE_TIPO_AREA = "AREA";
        public static String PROPERTY_TABLE_TIPO_DESCRIPCION ="DESCRIPCION";
        // CAMPO TABLA ESTADO
        public static String PROPERTY_TABLE_ESTADO_CODIGO = "ID";
        public static String PROPERTY_TABLE_ESTADO_DESCRIPCION = "DESCRIPCION";
        // CAMPO TABLA LOG
        public static String PROPERTY_TABLE_BITACORA_ACCION = "ACCION";
        public static String PROPERTY_TABLE_BITACORA_DESCRIPCION = "DESCRIPCION";
        public static String PROPERTY_TABLE_BITACORA_FECHA = "FECHA";
        public static String PROPERTY_TABLE_BITACORA_USUARIO = "USUARIO";
        public static String PROPERTY_TABLE_BITACORA_PILA = "PILA";
    }
}
