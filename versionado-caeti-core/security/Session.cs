using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_entity;

namespace versionado_caeti_core.security
{
   public  class Session
    {
        private Usuario usuario;
       
        private static Session instance = new Session();

        private Session()
        {


        }

        public static Session getInstance()
        {
            return instance;
        }
        public void abrir(Usuario usuario)
        {
            this.usuario = usuario;
            
        }
        public void cerrar()
        {
            if (usuario == null)
            {
            }
            usuario = null;
        }
        public Boolean tieneSession()
        {
            return (usuario != null);
        }
        public Usuario obtenerSesionActual()
        {
            return usuario;
        }

        public String getAlias()
        {
            String alias = null;
            if (this.tieneSession())
            {
                alias = usuario.nombre;
            }
            return alias;
        }

       
    }

}
