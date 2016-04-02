using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace versionado_caeti_conecotdb.sqlserver
{
    public class Command
    {

        public SqlCommand addStoreProcedureConnection(SqlConnection connection, String storeProcedureName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = storeProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            return command;
        }
    }
}
