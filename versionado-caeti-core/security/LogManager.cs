using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.entity;
using versionado_caeti_entity.enums;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.security
{
   public class LogManager
    {
       private static LogManager instance = new LogManager();
       private LogManager() { }

       public static LogManager getinstance()
        {
            return instance;
        }

        public void registrar(Log bitacora) {
            try
            {
                LogDao.getinstance().insertar(bitacora);
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
            catch (Exception ex) {
                ErrorManager.getInstance().gestionarError(ex);
            }
        }

        public List<Log> consultar(Log log)
        {
            return LogDao.getinstance().consultar(log);
        }

       

        public void registrar(String message, String accion,String usuario,String pila)
        {
            Log log = new Log();
            log.accion = accion;
            log.descripcion = message;
            log.fecha = new DateTime();
            log.usuario = new Usuario(usuario);
            log.pila = pila;
            LogDao.getinstance().insertar(log);

        }
       
        /**Devuelve todas las acciones que se graban en la bitacora y se agrega un item vacio si es true **/
        public List<String> consultarTodasAcciones(Boolean addEmpty) {
            List<String> listado = new List<string>();
            if (addEmpty) {
                listado.Add(String.Empty);
            }
            listado.AddRange(ActionLogEnum.getAllActions());
            return listado;
        }
    }
}
