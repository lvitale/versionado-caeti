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
    public class TipoDao : DBConnection, IDao<Tipo>
    {
        private static TipoDao instance = new TipoDao();
        private SqlConnection connection;

        public static TipoDao getInstance()
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

        #region IDao<Tipo> Members

        public List<Tipo> consultar(Tipo filter)
        {
           List<Tipo> tipos = new List<Tipo>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filter.codigo, SqlDbType.Int));
            
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_TIPO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_ID]);
                    tipo.area = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_AREA]);
                    tipo.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    tipos.Add(tipo);
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
            return tipos;
        }

        public List<Tipo> consultar(String area)
        {
            List<Tipo> tipos = new List<Tipo>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@parte", area, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_AREA_TIPO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_ID]);
                    tipo.area = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_AREA]);
                    tipo.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    tipos.Add(tipo);
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
            return tipos;
        }
        public List<Tipo> consultarParteNombre(String area)
        {
            List<Tipo> tipos = new List<Tipo>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@parte", area, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_TIPO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_ID]);
                    tipo.area = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_TIPO_AREA]);
                    tipo.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_ESTADO_DESCRIPCION]);

                    tipos.Add(tipo);
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
            return tipos;
        }
        public Tipo consultarUno(Tipo filter)
        {
            Tipo item = null;
            try
            {
                List<Tipo> listado = consultar(filter);
                if (listado != null && listado.Count > 0)
                {
                    foreach (Tipo i in listado)
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

        public void insertar(Tipo filter)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@area", filter.area, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@descripcion", filter.descripcion, SqlDbType.VarChar));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_TIPO);
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

        public void modificar(Tipo filter)
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

        public void eliminar(Tipo filter)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filter.codigo.ToString(), SqlDbType.Int));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_ELIMINAR_TIPO);
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
