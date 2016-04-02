using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace versionado_caeti_conecotdb.sqlserver
{
    class Adapter
    {
        public SqlDataAdapter getAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
            
            return sqlAdapter;

        }
    }
}
