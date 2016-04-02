using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_conecotdb.sqlserver
{
    class PoolConnection
    {
        private List<SqlConnection> connections = new List<SqlConnection>();
        private static PoolConnection instance = new PoolConnection();

        private PoolConnection() { 
        }

        public static PoolConnection getInstance(){
            return instance;
        }

        public void add(SqlConnection connection) {
            if(isDBConnect(connection)){
                connections.Add(connection);
            }
        }

        public void cleanConnections() {
            for (int i = 0; i < connections.Count;i++)
            {
                SqlConnection cn = connections.ElementAt(i);
                connections.Remove(cn);
                if (isDBConnect(cn))
                {
                    cn.Close();
                }

            }
            
            
        }

        private bool isDBConnect(SqlConnection cn)
        {
            bool connect = false;
            if (cn != null)
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    connect = true;
                }
            }
            return connect;
        }


    }
}
