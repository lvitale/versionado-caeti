using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;

namespace versionado_caeti_conecotdb.sqlserver
{
     public abstract class DBConnection
    {
       
        private SqlCommand command ;

        protected abstract SqlConnection getSqlConnection();
        protected abstract void setSqlConnection(SqlConnection connection);

        protected abstract Boolean isClosedConnection();
       
        private void connectDatabase(String database) {
            closeConnection();
            String parameter = VersionadoConstante.PROCEDURE_CONNECTION_STRING;
                setSqlConnection(new SqlConnection(parameter));
        }

       

        public void connectDatabaseAndCreateStoreProceduce(String database, String procedure)
        {
            closeCommand();
            connectDatabase(database);
            command = new Command().addStoreProcedureConnection(getSqlConnection(), procedure);
        }

        public SqlDataReader executeReader(List<SqlParameter> parameters) {
            getParamteres(parameters);
            if (!isDBConnect())
            {
                getSqlConnection().Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public int executeNonQuery(List<SqlParameter> parameters)
        {
            getParamteres(parameters);
            if (!isDBConnect())
            {
                getSqlConnection().Open();
            }
            int result = command.ExecuteNonQuery();
            return result;
        }

        private void getParamteres(List<SqlParameter> parameters) { 
            foreach(SqlParameter parameter in parameters){
                command.Parameters.Add(parameter);
            }
        }
        public void closeConnection()  {

            if (isDBConnect() && isClosedConnection())
            {
                getSqlConnection().Close();
                PoolConnection.getInstance().cleanConnections();

            }
                //No se cierra la conexion y se lo pone en una cola de conexiones 
            else {
                PoolConnection.getInstance().add(getSqlConnection());
            }
           
            SqlConnection.ClearAllPools();
           
        }

        private bool isDBConnect() {
            bool connect = false;
            if (getSqlConnection() != null)
            {
                if (getSqlConnection().State != System.Data.ConnectionState.Closed)
                {
                    connect = true;
                }
            }
            return connect;
        }
         private void closeCommand(){
             if (command != null)
             {
                 command = null;
             }
         }

         protected Boolean getDataBoolean(int value)
         {
             bool isTrue=false;
             if (value != null)
             {
                 if (value == 1)
                 {
                     isTrue = true;
                 }
             }
             return isTrue;
         }

         protected int getDataBooleanToInteger(Boolean value)
         {
             int isTrue=1;
             if (value != null)
             {
                 if (value)
                 {
                     isTrue = 0;
                 }
             }
             return isTrue;
         }
    }
}
