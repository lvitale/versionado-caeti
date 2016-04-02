using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_conecotdb;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.validator
{
    public class UserValidator
    {
        private static UserValidator instance = new UserValidator();

        public static UserValidator getInstance()
        {
            return instance;
        }

        public void validate(String nombre, String clave)
        {

            if (StringUtils.isNullOrEmpty(nombre) || StringUtils.isNullOrEmpty(clave))
            {
                throw new UserException(ErrorConstante.WARNING_USUARIO_503.ToString(), ErrorConstante.WARNING_USUARIO_503);
            }
        }

        public void validate(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UserException(ErrorConstante.WARNING_GENERAL_601.ToString(), ErrorConstante.WARNING_GENERAL_601);
            }
            if (StringUtils.isNullOrEmpty(usuario.nombre) || StringUtils.isNullOrEmpty(usuario.clave) || StringUtils.isNullOrEmpty(usuario.intentos.ToString()))
            {
                throw new UserException(ErrorConstante.WARNING_GENERAL_601.ToString(), ErrorConstante.WARNING_GENERAL_601);
            }
         
        }

        public Boolean existe(String usuario)
        {
            Boolean existe = false;
            try
            {
                Usuario usu = UsuarioDao.getInstance().consultarUno(new Usuario(usuario));
                if (usu != null && !StringUtils.isNullOrEmpty(usu.nombre))
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return existe;
        }

        public Boolean compare(Usuario old, Usuario current)
        {
            Boolean equal = false;
            if (old.Equals(current))
            {
                if (old.activo == current.activo )
                {
                    if (old.intentos.Equals(current.intentos) )
                    {
                        equal = true;
                    }
                }
            }
            return equal;
        }

    }
}
