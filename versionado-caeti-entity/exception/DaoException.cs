using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.exception
{
    public class DaoException : VersionException
    {
        public DaoException() { }
        public DaoException(String code, String message, Exception ex):base(code,message,ex) 
        {
            
        }
    }
}
