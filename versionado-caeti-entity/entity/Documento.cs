using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity
{
    public class Documento
    {
        private int _id;
        private String _nombre;
        private String _descripcion;

        private Tipo _tipo;
        private Boolean _activo;
        private Auditoria _auditoria;
        private List<Versionado>  _versiones;

        public Documento() {
            _auditoria = new Auditoria();
            _auditoria.usuario = new Usuario();
            _tipo = new Tipo();
            _versiones = new List<Versionado>();
            _activo = true;
        }
        public Documento(int id)
        {
            _auditoria = new Auditoria();
            _auditoria.usuario = new Usuario();
            _tipo = new Tipo();
            _versiones = new List<Versionado>();
            _activo = true;
            _id = id;
        }

        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public String nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public String descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }

        public Tipo tipo
        {
            get { return this._tipo; }
            set { this._tipo = value; }
        }

        public Boolean activo
        {
            get { return this._activo; }
            set { this._activo = value; }
        }

        public Auditoria auditoria
        {
            get { return this._auditoria; }
            set { this._auditoria = value; }
        }

        public List<Versionado> versiones
        {
            get { return this._versiones; }
            set { this._versiones = value; }
        }

        public override bool Equals(object value)
        {
            Boolean isEqual = false;
            Documento doc = null;
            if (!(value == null))
            {
                try
                {
                    doc = (Documento)value;

                    if (doc.nombre.Equals(this.nombre) && doc.descripcion.Equals(this.descripcion) && doc.tipo.codigo==this.tipo.codigo)
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
           
    }
}
