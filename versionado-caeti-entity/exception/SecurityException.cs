using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.exception
{
   public class SecurityException : Exception
    {
        public SecurityException() { }
        public SecurityException(Exception ex) :base(ex.Message,ex){
            
        }
        public SecurityException(String code, String message): base(message)
        {
            _code = code;
        }
        public SecurityException(String code, String message, Exception ex)
            : base(message, ex)
        {
            _code = code;
        }
         private String _code;

         public String code
         {
             get { return _code; }
             set { this._code = value; }
         } 
    }
}
