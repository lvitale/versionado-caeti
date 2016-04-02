using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.view
{
    public class DocumentoView : Documento
    {
        private String _descripcionTipo;

        public DocumentoView(Documento doc){
            this.activo= doc.activo;
            this.auditoria = doc.auditoria;
            this.descripcion = doc.descripcion;
            this.descripcionTipo = doc.tipo.area;
            this.id = doc.id;
            this.nombre = doc.nombre;
            this.versiones = doc.versiones;

        }
        public String descripcionTipo
        {
            get { return this._descripcionTipo; }
            set { this._descripcionTipo = value; }
        }

    }
}
