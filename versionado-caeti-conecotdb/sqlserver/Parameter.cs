using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using versionado_caeti_conecotdb;
using System.IO;

namespace reserva_california_conectordb.reserva.california.conectordb.sqlserver
{
    public class Parameter
    {
       
        public static SqlParameter addParameter(String parameterName, String parameterValue, SqlDbType parameterType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = parameterType;
            parameter.IsNullable = true;
            if (!StringUtils.isNullOrEmpty(parameterValue))
            {
                parameter.Value = parameterValue;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            return parameter;
        }

        public static SqlParameter addParameter(String parameterName, int parameterValue, SqlDbType parameterType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = parameterType;
            parameter.IsNullable = true;
            if (parameterValue!=0)
            {
                parameter.Value = parameterValue;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            return parameter;
        }

        public static SqlParameter addParameter(String parameterName, DateTime parameterValue, SqlDbType parameterType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = parameterType;
            parameter.IsNullable = true;
            if(!(parameterValue==DateTime.MinValue))
            {
                parameter.Value = parameterValue;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            return parameter;
        }
        public static SqlParameter addParameter(String parameterName, Boolean parameterValue, SqlDbType parameterType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = parameterType;
            parameter.IsNullable = true;
            if (!(parameterValue == null))
            {
                parameter.Value = parameterValue;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            return parameter;
        }
        public static SqlParameter addParameter(String parameterName, byte[] parameterValue, SqlDbType parameterType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = parameterType;
            parameter.IsNullable = true;
            parameter.Value = parameterValue;
            return parameter;
        }

      
    }
}
