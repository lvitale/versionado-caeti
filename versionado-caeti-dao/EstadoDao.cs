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
using versionado_caeti_entity.exception;

namespace versionado_caeti_dao
{
   public class EstadoDao : DBConnection, IDao<Estado>
    {
       private static EstadoDao instance = new EstadoDao();
        private SqlConnection connection;

        public static EstadoDao getInstance()
        {
            return instance;
        }
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
    
    
        #region IDao<Estado> Members

        public List<Estado> consultar(Estado filtro)
        {
            List<Estado> estados = new List<Estado>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filtro.codigo, SqlDbType.Int));
            listado.Add(Parameter.addParameter("@descripcion", filtro.descripcion, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_ESTADO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Estado estado = new Estado();
                    estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_CODIGO]);
                    estado.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    estados.Add(estado);
                }

            }

            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                closeConnection();
            }
            return estados;
        }
        public Estado consultar(Int32 id)
        {
            Estado estado = new Estado();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", id, SqlDbType.Int));
            
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_ESTADO_ID);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_CODIGO]);
                    estado.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                }

            }

            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                closeConnection();
            }
            return estado;
        }
        public List<Estado> consultar(String parteDescripcion)
        {
            List<Estado> estados = new List<Estado>();
            List<SqlParameter> listado = new List<SqlParameter>();
            
            listado.Add(Parameter.addParameter("@descripcion", parteDescripcion, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_ESTADO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Estado estado = new Estado();
                    estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_CODIGO]);
                    estado.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    estados.Add(estado);
                }

            }

            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                closeConnection();
            }
            return estados;
        }
        public Estado consultarUno(Estado filter)
        {
            Estado item = null;
            try
            {
                List<Estado> listado = consultar(filter);
                if (listado != null && listado.Count > 0)
                {
                    foreach (Estado i in listado)
                    {
                        item = i;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            return item;
        }

        public List<Estado> consultarParteNombre(String descripcion) {
            List<Estado> estados = new List<Estado>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@descripcion", descripcion, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_ESTADO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Estado estado = new Estado();
                    estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_CODIGO]);
                    estado.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    estados.Add(estado);
                }

            }

            catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            finally
            {
                closeConnection();
            }
            return estados;
        }
       
        public void insertar(Estado filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@descripcion", filtro.descripcion, SqlDbType.VarChar));
            
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_ESTADO);
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

        public void modificar(Estado filter)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filter.codigo.ToString(), SqlDbType.Int));
            listado.Add(Parameter.addParameter("@descripcion", filter.descripcion, SqlDbType.VarChar));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_MODIFICAR_ESTADO);
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

        public void eliminar(Estado filter)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filter.codigo.ToString(), SqlDbType.Int));
            
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_ELIMINAR_ESTADO);
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

        #endregion
   }
}
