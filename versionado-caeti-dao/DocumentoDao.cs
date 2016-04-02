

using reserva_california_conectordb.reserva.california.conectordb.sqlserver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using versionado_caeti_conecotdb.sqlserver;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;
namespace versionado_caeti_dao
{
    public class DocumentoDao : DBConnection, IDao<Documento>
    {

        private static DocumentoDao instance = new DocumentoDao();
        private SqlConnection connection;

        public static DocumentoDao getInstance()
        {
            return instance;
        }

        private DocumentoDao(){

        }
        #region IDao<Documento> Members

        public List<Documento> consultar(Documento filtro)
        {
            List<Documento> documentos = new List<Documento>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filtro.id, SqlDbType.Int));
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@tipo", filtro.tipo.codigo, SqlDbType.Int));
            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@activo", filtro.activo, SqlDbType.Bit));
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_DOCUMENTO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE ]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    doc.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_DESCRIPCION]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    try
                    {
                        doc.tipo = TipoDao.getInstance().consultarUno(new Tipo(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_TIPO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documentos.Add(doc);
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
            return documentos;
        }
        public Documento consultar(int id)
        {
            Documento documento = null;
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id",id, SqlDbType.Int));
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_DOCUMENTO_ID);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    doc.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_DESCRIPCION]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    try
                    {
                        doc.tipo = TipoDao.getInstance().consultarUno(new Tipo(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_TIPO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documento=doc;
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
            return documento;
        }
        public List<Documento> consultar(String parteNombre)
        {
            List<Documento> documentos = new List<Documento>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", parteNombre, SqlDbType.VarChar));
            

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_DOCUMENTO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    doc.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_DESCRIPCION]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documentos.Add(doc);
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
            return documentos;
        }
        public List<Documento> consultar(String nombre,bool estaActivo)
        {
            List<Documento> documentos = new List<Documento>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@activo", estaActivo, SqlDbType.Bit));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_DOCUMENTO_ACTIVO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    doc.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_DESCRIPCION]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documentos.Add(doc);
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
            return documentos;
        }
        public List<Documento> consultar(Int16 id)
        {
            List<Documento> documentos = new List<Documento>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@ids", id.ToString(), SqlDbType.VarChar));


            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_CLAVE_DOCUMENTO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    doc.descripcion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_DESCRIPCION]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documentos.Add(doc);
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
            return documentos;
        }
        public List<Documento> consultarNombre(Documento filtro)
        {
            List<Documento> documentos = new List<Documento>();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_DOCUMENTO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    doc.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_NOMBRE]);
                    doc.activo = Convert.ToBoolean(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ACTIVO]);
                    doc.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    doc.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);

                    try
                    {
                        doc.versiones = VersionDao.getInstance().consultar(new Versionado(Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID])));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    documentos.Add(doc);
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
            return documentos;
        }
        public Documento consultarUno(Documento filter)
        {
            Documento item = null;
            try { 
                List<Documento> listado=consultar(filter);
                if (listado != null && listado.Count > 0) {
                    foreach (Documento i in listado) {
                        item = i;
                    }
                }
                }     catch (Exception ex)
            {
                throw new DaoException(ErrorConstante.ERROR_DB_201.ToString(), ErrorConstante.ERROR_DB_201, ex);
            }
            return item;
        }

        public void insertar(Documento filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@descripcion", filtro.descripcion , SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@tipo", filtro.tipo.codigo.ToString() , SqlDbType.Int ));
            listado.Add(Parameter.addParameter("@activo", filtro.activo, SqlDbType.Bit));
            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre  , SqlDbType.VarChar ));
            listado.Add(Parameter.addParameter("@fechaRegistro", filtro.auditoria.fechaRegistro  , SqlDbType.DateTime ));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_DOCUMENTO);
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

        public void modificar(Documento filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@id", filtro.id, SqlDbType.Int));
           
            listado.Add(Parameter.addParameter("@descripcion", filtro.descripcion, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@tipo", filtro.tipo.codigo, SqlDbType.Int));
           
            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@fechaRegistro", filtro.auditoria.fechaRegistro, SqlDbType.DateTime));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_MODIFICAR_DOCUMENTO);
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

        public void eliminar(Documento filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@id", filtro.id, SqlDbType.Int));

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_ELIMINAR_DOCUMENTO);
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
