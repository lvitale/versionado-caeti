using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.exception
{
    public class UserException : SecurityException
    {
         public UserException() { 
        }
        public UserException(String code,String message): base(code,message)
        {

        }
        public UserException(String code, String message, Exception ex)
            : base(code, message, ex)
        {
           
        }
    }
}
