using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_core.validator;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.security
{
   public class UserManager
    {
       private static UserManager instance = new UserManager();
       private UserManager() { }

       public static UserManager getinstance()
        {
            return instance;
        }

        public Usuario consultarUno(Usuario filtro) {
            Usuario usuarioEncontrado=null;
            try
            {
                usuarioEncontrado = UsuarioDao.getInstance().consultarUno(filtro);
            }
            catch (DaoException ex) {
                ErrorManager.getInstance().gestionarError(ex);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
                return usuarioEncontrado;
        }

        public List<Usuario> consultar(Usuario filtro)
        {
            List<Usuario> listado = new List<Usuario>();
            try
            {
                listado = UsuarioDao.getInstance().consultar(filtro);
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
            return listado;
        }

        public List<Usuario> consultarTodos()
        {
            List<Usuario> usuarios = null;
            try
            {
                usuarios = UsuarioDao.getInstance().consultarTodos();
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ex);
            
            }
            return usuarios;
        }
        /**Devuelve un listado con todos los usuarios incluyendo un objeto vacio**/
        public List<Usuario> consultarTodosUsuarios(Boolean addEmpty)
        {
            List<Usuario> usuarios = new List<Usuario>();
            if (addEmpty) {
                usuarios.Add(new Usuario(String.Empty));
            }
            try
            {
                usuarios.AddRange( UsuarioDao.getInstance().consultarTodos());
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ex);
            
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ex);
            
            
            }
            return usuarios;
        }
        public void agregar(Usuario filtro) {
            try
            {

                UserValidator.getInstance().validate(filtro);
                if (existeUsuario(filtro)) {
                    throw new UserException(ErrorConstante.WARNING_USUARIO_505.ToString(), ErrorConstante.WARNING_USUARIO_505.ToString());
                }
                filtro.clave = Encryptor.getInstance().encriptar(filtro.clave);
                LogManager.getinstance().registrar("Se inserto el usuario[" + filtro.nombre + "]", "insertar", Session.getInstance().getAlias(), null);
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (UserException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_NO_ESPERADA_101.ToString(), ErrorConstante.ERROR_EXCEPTION_NO_ESPERADA_101);
            }
        }

        public void modificar(Usuario old,Usuario filtro)
        {
            try
            {

                UserValidator.getInstance().validate(filtro);
                
                if (!existeUsuario(filtro))
                {
                    throw new UserException(ErrorConstante.WARNING_USUARIO_504.ToString(), ErrorConstante.WARNING_USUARIO_504.ToString());
                }
                if (UserValidator.getInstance().compare(old, filtro))
                {
                    throw new UserException(ErrorConstante.WARNING_USUARIO_506.ToString(), ErrorConstante.WARNING_USUARIO_506.ToString());
                }
                
                LogManager.getinstance().registrar("Se modifico el usuario[" + filtro.nombre + "]", "modificar", Session.getInstance().getAlias(), null);
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (UserException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE.ToString(), ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
        }
        public void eliminar(Usuario filtro)
        {
            try
            {
                if (!UserValidator.getInstance().existe(filtro.nombre))
                {
                    throw new SecurityException(ErrorConstante.WARNING_USUARIO_504.ToString(), ErrorConstante.WARNING_USUARIO_504);
                }
                
                UsuarioDao.getInstance().eliminar(filtro);
            }
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE.ToString(), ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
            }
        }

        public void incrementarIntentos(Usuario filtro) {

            try
            {
                filtro.incrementarIntentos();
                UsuarioDao.getInstance().modificar(filtro);
            }
            catch (Exception ex) {
                ErrorManager.getInstance().gestionarError(ex);
            }
        
        }
        private Boolean existeUsuario(Usuario filtro) {
            Boolean existe = false;
            try
            {
                Usuario usuario = UsuarioDao.getInstance().consultarUno(filtro);
                if(usuario!=null && !usuario.isEmpty()){
                    existe = true;
                }
            }
            catch (Exception ex) { 
            }
            return existe;
        }

        public Boolean changePassword(Usuario userOld,Usuario userNew,String mask) {
            Boolean change = false;
            if (!mask.Equals(userNew.clave)){
                if(!Encryptor.getInstance().encriptar(userNew.clave).Equals(userOld.clave)) {
                    change = true;
                }
            }
            return change;
        }
    }
}
