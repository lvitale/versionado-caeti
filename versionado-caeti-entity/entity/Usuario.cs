using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_entity.constante;

namespace versionado_caeti_entity
{
   public class Usuario
    {
        private String _nombre;
        private String _clave;
        private int _intentos = 0;
        private Boolean _activo;
        private String _correoElectronico;

        public Usuario() { }
        public Usuario(String nombre)
        {
            this.nombre = nombre;
        }
        public Usuario(String nombre, String clave) {
            this.nombre = nombre;
            this.clave = clave;
        }
        public Usuario(String nombre, String clave,String correo)
        {
            this.nombre = nombre;
            this.clave = clave;
            this._correoElectronico = correo;
        }
        public Usuario(String nombre, String clave,int intentos,Boolean activo, String correo)
        {
            this._nombre = nombre;
            this._clave = clave;
            this._intentos = intentos;

            this._activo = activo;
            this._correoElectronico = correo;
        }
      
        public String nombre{
            get{return this._nombre;}
            set { this._nombre = value; }
        }

        public String clave {
            get { return this._clave; }
            set { this._clave = value; }
        }

        public int intentos
        {
            get { return this._intentos; }
            set { this._intentos = value; }
        }

        public bool activo
        {
            get { return this._activo; }
            set { this._activo = value; }
        }
        public String correoElectronico
        {
            get { return this._correoElectronico; }
            set { this._correoElectronico = value; }
        }

        public override string ToString()
        {
            return this.nombre;
        }
        public override bool Equals(object value)
        {
            Boolean isEqual = false;
            Usuario user = null;
            if (!(value == null))
            {
                try
                {
                     user = (Usuario)value;

                    if (user.nombre.Equals(this.nombre) && user.clave.Equals(this.clave))
                    {
                        isEqual = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            return isEqual;
        }

        public void incrementarIntentos()
        {
            _intentos++;
            if (_intentos > VersionadoConstante.USER_INTENT)
            {
                _activo = false;
            }
        }

        public Boolean estaBloqueado() {
            return !_activo;
        }

        public Boolean isEmpty() {
            Boolean empty = false;
            if (_nombre == null) {
                empty = true;
            }
            return empty;
        }
 
    }
    
}
