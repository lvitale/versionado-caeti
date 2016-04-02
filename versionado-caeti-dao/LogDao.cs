using reserva_california_conectordb.reserva.california.conectordb.sqlserver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_conecotdb.sqlserver;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.entity;
using versionado_caeti_entity.exception;

namespace versionado_caeti_dao
{
   public class LogDao : DBConnection
    {
       private static LogDao instance = new LogDao();
        private LogDao() { }

        public static LogDao getinstance()
        {
            return instance;
        }
       
 
        public List<Log> consultar(Log filtro)
        {
            List<Log> bitacoras = new List<Log>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@accion", filtro.accion, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@usuario", filtro.getNombreUsuario(), SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@fechaDesde",filtro.fechaDesde.ToString(), SqlDbType.DateTime));
            listado.Add(Parameter.addParameter("@fechaHasta", filtro.fechaHasta.ToString(), SqlDbType.DateTime));
            SqlDataReader reader=null;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_BITACORA);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Log bitacora = new Log();
                    bitacora.accion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_ACCION]);
                    bitacora.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_DESCRIPCION]);

                    bitacora.fecha = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_FECHA]);
                    bitacora.usuario =new Usuario (Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_USUARIO]));
                    bitacora.pila = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_PILA]);
                    bitacoras.Add(bitacora);

                }
            }
            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                reader.Close();
                closeConnection();
            }
            return bitacoras;
        }

        public List<String> consultarTodasAcciones()
        {
            List<String> acciones = new List<String>();
            List<SqlParameter> listado = new List<SqlParameter>();
            SqlDataReader reader = null;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_BITACORA_TODAS_ACCIONES);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    String accion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_BITACORA_ACCION]);
                    acciones.Add(accion);
                }
            }
            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                reader.Close();
                closeConnection();
            }
            return acciones;
        }

        public void insertar(Log bitacora)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@accion", bitacora.accion, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@descripcion", bitacora.descripcion, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@usuario", (bitacora.usuario!=null?bitacora.usuario.nombre:"sistema"), SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@pila", bitacora.pila, SqlDbType.VarChar));
           
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_BITACORA);
                int result = executeNonQuery(listado);
            }
            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                closeConnection();
            }
            
        }
        private SqlConnection connection;
        protected override SqlConnection getSqlConnection()
        {
            return connection;
        }
        protected override void setSqlConnection(SqlConnection connection)
        {
            this.connection = connection;
        }

        protected override Boolean isClosedConnection()
        {
            return true;
        }

       
    }
    }

