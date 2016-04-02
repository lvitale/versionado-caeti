using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.entity
{
   public  class Log
    {
       private String _accion;
        private String _descripcion;
        private DateTime _fecha;
        private Usuario _usuario;
        private String _pila;

        private DateTime _fechaDesde;
        private DateTime _fechaHasta;

        public Log()
        {
            this.fecha = DateTime.MinValue;
        }
        public String accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        public String descripcion 
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DateTime fecha 
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public String getNombreUsuario() {
            String alias = null;
            if (usuario != null) {
                alias = _usuario.nombre;
            }
            return alias;
        }

        public String pila
        {
            get { return _pila; }
            set { _pila = value; }
        }

        public DateTime fechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }
        public DateTime fechaHasta
        {
            get { return _fechaHasta; }
            set { _fechaHasta = value; }
        }
    }
}
