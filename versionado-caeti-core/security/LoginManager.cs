using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_core.security;
using versionado_caeti_core.validator;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core
{
   public  class LoginManager
    {
       private static LoginManager instance = new LoginManager();
       private LoginManager() { }

         public static LoginManager getinstance()
         {
            return instance;
        }
        public void ingresar(String nombre,String clave)
        {
            Usuario usuario=null;
            try
            {
                 // usuario o clave vacias
                UserValidator.getInstance().validate(nombre, clave);
               
                usuario = (Usuario) UserManager.getinstance().consultarUno(new Usuario(nombre));
                // usuario invalido
                if (usuario == null || usuario.nombre == null)
                {
                    throw new UserException(ErrorConstante.WARNING_USUARIO_501.ToString(), ErrorConstante.WARNING_USUARIO_501 + "["+ nombre+"]");
                }
                // clave invalida
                if (!usuario.clave.Equals(Encryptor.getInstance().encriptar(clave)))
                {
                    //Incremento en uno el intento fallido
                    UserManager.getinstance().incrementarIntentos(usuario);
                    throw new UserException(ErrorConstante.WARNING_USUARIO_501.ToString(), ErrorConstante.WARNING_USUARIO_501 + "[" + nombre + "]");
                }
                // usuario bloqueado
                if (usuario.estaBloqueado())
                {
                    throw new UserException(ErrorConstante.WARNING_USUARIO_502.ToString(), ErrorConstante.WARNING_USUARIO_502 + "[" + nombre + "]");
                }
                // El usuario se autentico correctamente
                Session.getInstance().abrir(usuario);
                LogManager.getinstance().registrar("El usuario ingreso correctamente", "login", Session.getInstance().getAlias(), null);
                
            }
            catch (UserException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message, ex);
            }
            catch (SecurityException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message, ex);
            }
             catch (DaoException ex) {
                ErrorManager.getInstance().gestionarError(ex);
                 throw new SecurityException(ex.code,ex.Message,ex);
            }catch (Exception ex) {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_FORMULARIO, ErrorConstante.ERROR_EXCEPTION_FORMULARIO,ex);
            }
        }

        public void salir() {
            try
            {
                String usuarioActual =  Session.getInstance().getAlias();
                Session.getInstance().cerrar();
                LogManager.getinstance().registrar("El usuario " + usuarioActual + "se acaba de desploguear","Salir",usuarioActual,null);
                

            }
            catch (SecurityException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message, ex);
            }
            
            catch (DaoException ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ex.code, ex.Message, ex);
            }
            catch (Exception ex)
            {
                ErrorManager.getInstance().gestionarError(ex);
                throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_FORMULARIO, ErrorConstante.ERROR_EXCEPTION_FORMULARIO, ex);
            }
        }
    }
}
