using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity
{
  public  class Auditoria
    {
        private DateTime _fechaRegistro;
        private Usuario _usuario;

        public DateTime fechaRegistro
        {
            get { return this._fechaRegistro; }
            set { this._fechaRegistro = value; }
        }

        public Usuario usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }
    }
}
