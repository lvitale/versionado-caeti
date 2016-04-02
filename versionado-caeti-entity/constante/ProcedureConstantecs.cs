                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.constante
{
    public  class ProcedureConstante
    {
       /**  SEGURIDAD **/
        // ************************ USUARIO ********************** 
        public static String PROCEDURE_NAME_CONSULTAR_USUARIO = "consultarUsuario";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_USUARIO = "consultarParteNombreUsuario";
        public static String PROCEDURE_NAME_CONSULTAR_USUARIOS = "consultarUsuarios";
        public static String PROCEDURE_NAME_CONSULTAR_TODOS_USUARIOS = "obtenerTodosUsuario";
        public static String PROCEDURE_NAME_INSERTAR_USUARIO = "insertarUsuario";
        public static String PROCEDURE_NAME_MODIFICAR_USUARIO = "modificarUsuario";
        public static String PROCEDURE_NAME_ELIMINAR_USUARIO = "eliminarUsuario";
        // ************************ BITACORA ********************** 
        public static String PROCEDURE_NAME_CONSULTAR_BITACORA = "consultarBitacora";
        public static String PROCEDURE_NAME_CONSULTAR_BITACORA_TODAS_ACCIONES = "consultarTodasAccionesBitacora";
        public static String PROCEDURE_NAME_INSERTAR_BITACORA = "insertarBitacora";
        // ************************ DOUCMENTO ********************** 
        public static String PROCEDURE_NAME_CONSULTAR_DOCUMENTO = "consultarDocumento";
        public static String PROCEDURE_NAME_CONSULTAR_DOCUMENTO_ID = "consultarDocumentoPorId";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_DOCUMENTO = "consultarParteDocumento";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_DOCUMENTO_ACTIVO = "consultarParteDocumentoActivo";
        public static String PROCEDURE_NAME_CONSULTAR_CLAVE_DOCUMENTO = "consultarClaveDocumento";
        public static String PROCEDURE_NAME_INSERTAR_DOCUMENTO = "insertarDocumento";
        public static String PROCEDURE_NAME_ELIMINAR_DOCUMENTO = "eliminarDocumento";
        public static String PROCEDURE_NAME_MODIFICAR_DOCUMENTO = "modificarDocumento";
        // ************************ VERSION ********************** //
        public static String PROCEDURE_NAME_INSERTAR_VERSION = "insertarVersion";
        public static String PROCEDURE_NAME_MODIFICAR_VERSION = "modificarVersion";
        public static String PROCEDURE_NAME_ELIMINAR_VERSION = "eliminarVersion";
        public static String PROCEDURE_NAME_CONSULTAR_VERSION = "consultarVersion";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_VERSION = "consultarParteNombreVersion";
        public static String PROCEDURE_NAME_CONSULTAR_UNA_VERSION = "consultarUnaVersion";
        public static String PROCEDURE_NAME_CONSULTAR__VERSION_ID = "consultarVersionPorId";
        public static String PROCEDURE_NAME_CONSULTAR__VERSION_DOC_ID = "consultarVersionPorDocId";
        // ************************ TIPO ********************** 
        public static String PROCEDURE_NAME_CONSULTAR_TIPO = "consultarTipo";
        public static String PROCEDURE_NAME_CONSULTAR_AREA_TIPO = "consultarAreaTipo";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_TIPO = "consultarParteTipo";
        public static String PROCEDURE_NAME_ELIMINAR_TIPO = "eliminarTipo";
        public static String PROCEDURE_NAME_INSERTAR_TIPO = "insertarTipo";
        public static String PROCEDURE_NAME_MODIFICAR_TIPO = "modificarTipo";
        // ************************ ESTADO ********************** 
        public static String PROCEDURE_NAME_CONSULTAR_ESTADO = "consultarEstado";
        public static String PROCEDURE_NAME_CONSULTAR_ESTADO_ID = "consultarEstadoId"; 
        public static String PROCEDURE_NAME_CONSULTAR_NOMBRE_ESTADO = "consultarNombreEstado";
        public static String PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_ESTADO = "consultarParteDescripcionEstado";
        public static String PROCEDURE_NAME_CONSULTAR_CODIGO_ESTADO = "consultarCodigoEstado";
        public static String PROCEDURE_NAME_INSERTAR_ESTADO = "insertarEstado";
        public static String PROCEDURE_NAME_ELIMINAR_ESTADO = "eliminarEstado";
        public static String PROCEDURE_NAME_MODIFICAR_ESTADO = "modificarEstado";
    }
}
