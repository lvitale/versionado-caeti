using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.exception
{
   public class Message
    {
        private String _code;
        private String _description;

        public String code
        {
            get { return _code; }
            set { this._code = value; }
        }

        public String description
        {
            get { return _description; }
            set { this._description = value; }
        } 
    }
}
