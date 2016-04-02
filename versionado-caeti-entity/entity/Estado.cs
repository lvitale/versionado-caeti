using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity
{
    public  class Estado
    {
        private int _codigo;
        private String _descripcion;

        public Estado()
        {
            
        }
        public Estado(int _id) {
            _codigo = _id;
        }
        public int codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }

        public String descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }

    }
}
