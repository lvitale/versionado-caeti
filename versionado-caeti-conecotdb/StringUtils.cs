using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_conecotdb
{
    public class StringUtils
    {
        public static Boolean isNullOrEmpty(String value) {
            Boolean nullOrEmpty = false;
            if (isNull(value)) {
                nullOrEmpty = true;
            }
            if (value == String.Empty) {
                nullOrEmpty = true;
            }
            return nullOrEmpty;
        }
        public static Boolean isNull(Object value) {
            Boolean isnull = false;
            if (value==null)
            {
                isnull = true;
            }
            return isnull;
        }
        public static String convertToString(Object value) {
            String data = null;
            try
            {
                if (!isNull(value))
                {
                    data = value.ToString();
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }

            return data;
        }

       

    }
}
