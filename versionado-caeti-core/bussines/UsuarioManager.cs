using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_core.utils;
using versionado_caeti_core.validator;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.bussines
{
    public class UsuarioManager
    {
        private static UsuarioManager instance = new UsuarioManager();
        private UsuarioManager() { }

        public static UsuarioManager getInstance()
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
              
            }
            catch (Exception ex)
            {
               
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
               
            }
            catch (Exception ex)
            {
                
            }
            return listado;
        }
                                                   
        public List<Usuario> consultar(String parteNombre)
        {
            List<Usuario> listado = new List<Usuario>();
            try
            {
                listado = UsuarioDao.getInstance().consultar(parteNombre);
            }
            catch (DaoException ex)
            {

            }
            catch (Exception ex)
            {

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
                
            }
            catch (Exception ex)
            {
               
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
                
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ex);
            
            }
            catch (Exception ex)
            {
                
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE, ex);
            
            
            }
            return usuarios;
        }
        public void agregar(Usuario filtro) {
            try
            {

                UserValidator.getInstance().validate(filtro);
                if (existeUsuario(filtro)) {
                    throw new SecurityException(ErrorConstante.WARNING_USUARIO_505.ToString(), ErrorConstante.WARNING_USUARIO_505.ToString());
                }
                filtro.clave = Encriptor.getInstance().encriptar(filtro.clave);
                UsuarioDao.getInstance().insertar(filtro);
                
            }
            catch (DaoException ex)
            {
                throw new SecurityException(ex.code, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (SecurityException ex)
            {
                
                throw new SecurityException(ex.code, ex.Message);
            }
            catch (Exception ex)
            {
               
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_NO_ESPERADA_101.ToString(), ErrorConstante.ERROR_EXCEPTION_NO_ESPERADA_101);
            }
        }

        public void modificar(Usuario filtro)
        {
            try
            {
                Usuario old = UsuarioDao.getInstance().consultarUno(filtro);
                UserValidator.getInstance().validate(filtro);
                if (changePassword(old, filtro, getMaskPasword())) {
                    filtro.clave = Encriptor.getInstance().encriptar(filtro.clave);
                }

                if (!existeUsuario(filtro))
                {
                    throw new SecurityException(ErrorConstante.WARNING_USUARIO_504.ToString(), ErrorConstante.WARNING_USUARIO_504.ToString());
                }
                if (UserValidator.getInstance().compare(old, filtro)) {
                    throw new SecurityException(ErrorConstante.WARNING_USUARIO_506.ToString(), ErrorConstante.WARNING_USUARIO_506.ToString());
                }
                
                 UsuarioDao.getInstance().modificar(filtro);
            }
            catch (DaoException ex)
            {

                throw new SecurityException(ex.code, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (SecurityException ex)
            {

                throw new SecurityException(ex.code, ex.Message);
            }
            catch (Exception ex)
            {

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

                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE.ToString(), ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
            }
            catch (Exception ex)
            {
               
            }
        }

        public void incrementarIntentos(Usuario filtro) {

            try
            {
                filtro.incrementarIntentos();
                UsuarioDao.getInstance().modificar(filtro);
               
            }
            catch (Exception ex) {
                
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
                if(!Encriptor.getInstance().encriptar(userNew.clave).Equals(userOld.clave)) {
                    change = true;
                }
            }
            return change;
        }

        public String getMaskPasword() {
            return "****";
        }
    }
}
