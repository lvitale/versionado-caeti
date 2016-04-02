



using reserva_california_conectordb.reserva.california.conectordb.sqlserver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using versionado_caeti_conecotdb.sqlserver;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;
namespace versionado_caeti_dao
{
   public class VersionDao : DBConnection, IDao<Versionado>
    {
       private static VersionDao instance = new VersionDao();
        private SqlConnection connection;

        public static VersionDao getInstance()
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

        #region IDao<Versionado> Members

        public List<Versionado> consultar(Versionado filtro)
        {
            List<Versionado> versiones = new List<Versionado>();
            List<SqlParameter> listado = new List<SqlParameter>();

            //listado.Add(Parameter.addParameter("@version", filtro.version.ToString(), SqlDbType.BigInt));
            //listado.Add(Parameter.addParameter("@subversion", filtro.subversion.ToString(), SqlDbType.BigInt));
            listado.Add(Parameter.addParameter("@documento", filtro.documento.nombre  , SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@estado", filtro.estado.codigo.ToString(), SqlDbType.Int));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_VERSION);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Versionado vers = new Versionado();
                    vers.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    vers.version = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_VERSION_]);
                    vers.subversion = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSON_SUBVERSION]);

                    vers.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE]);
                    vers.observacion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_OBSERVACION]);

                    vers.estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO]);
                   // vers.archivo = Convert.ToStream(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ARCHIVO]);
                    vers.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    vers.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    vers.documento.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);

                    try
                    {
                        vers.estado = EstadoDao.getInstance().consultar(Convert.ToInt32(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO_ID]));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }

                    versiones.Add(vers);
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
            return versiones;
        }
        public List<Versionado> consultar(int docId,String nombre)
        {
            List<Versionado> versiones = new List<Versionado>();
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@documento", docId.ToString(), SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@usuario", nombre, SqlDbType.VarChar));
           

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_VERSION);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Versionado vers = new Versionado();
                    vers.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    vers.version = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_VERSION_]);
                    vers.subversion = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSON_SUBVERSION]);

                    vers.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE]);
                    vers.observacion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_OBSERVACION]);

                    vers.estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO]);
                    // vers.archivo = Convert.ToStream(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ARCHIVO]);
                    vers.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    vers.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    vers.documento.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);

                    try
                    {
                        vers.estado = EstadoDao.getInstance().consultar(Convert.ToInt32(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO_ID]));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    versiones.Add(vers);
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
            return versiones;
        }
        public List<Versionado> consultar(int docId)
        {
            List<Versionado> versiones = new List<Versionado>();
            List<SqlParameter> listado = new List<SqlParameter>();


            listado.Add(Parameter.addParameter("@docId", docId.ToString(), SqlDbType.Int));
            

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR__VERSION_DOC_ID);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Versionado vers = new Versionado();
                    vers.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    vers.version = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_VERSION_]);
                    vers.subversion = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSON_SUBVERSION]);

                    vers.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE]);
                    vers.observacion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_OBSERVACION]);

                    vers.estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO]);
                    // vers.archivo = Convert.ToStream(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ARCHIVO]);
                    vers.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    vers.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    vers.documento.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);

                    try
                    {
                        vers.estado = EstadoDao.getInstance().consultar(Convert.ToInt32(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO_ID]));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    versiones.Add(vers);
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
            return versiones;
        }
        public Versionado consultarUno(Versionado filtro)
        {
            Versionado version = null;
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@version", filtro.version.ToString(), SqlDbType.BigInt));
            listado.Add(Parameter.addParameter("@subversion", filtro.subversion.ToString(), SqlDbType.BigInt));
            listado.Add(Parameter.addParameter("@documento", filtro.documento.id.ToString(), SqlDbType.BigInt));
            

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_UNA_VERSION);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Versionado vers = new Versionado();
                    vers.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    vers.version = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_VERSION_]);
                    vers.subversion = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSON_SUBVERSION]);

                    vers.estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO]);
                    vers.archivo = (Byte[])reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ARCHIVO];

                    vers.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE]);
                    vers.observacion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_OBSERVACION]);
                    
                    vers.tipoContenido = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_TIPO_CONTENIDO]);
                    vers.nombreOriginal = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE_ORIGINAL]);
                    
                    vers.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    
                    vers.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    vers.documento.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);

                    try
                    {
                        vers.estado = EstadoDao.getInstance().consultar(Convert.ToInt32(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO_ID]));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    version = vers;
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
            return version;
        }

        public Versionado consultarPorId(int id)
        {
            Versionado version = null;
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@id", id.ToString(), SqlDbType.Int));
            
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR__VERSION_ID);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Versionado vers = new Versionado();
                    vers.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ID]);
                    vers.version = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_VERSION_]);
                    vers.subversion = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSON_SUBVERSION]);

                    vers.estado.codigo = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO]);
                    vers.archivo = (Byte[])reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ARCHIVO];

                    vers.auditoria.usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_USUARIO]);
                    vers.auditoria.fechaRegistro = Convert.ToDateTime(reader[BaseDatoConstante.PROPERTY_TABLE_AUDITORIA_FECHA_REGISTRO]);
                    vers.documento.id = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_DOCUMENTO_ID]);

                    vers.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE]);
                    vers.observacion = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_OBSERVACION]);
                    
                    vers.extension = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_EXTENSION]);
                    vers.tipoContenido = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_TIPO_CONTENIDO]);
                    vers.nombreOriginal = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_NOMBRE_ORIGINAL]);

                    try
                    {
                        vers.estado = EstadoDao.getInstance().consultar(Convert.ToInt32(reader[BaseDatoConstante.PROPERTY_TABLE_VERSION_ESTADO_ID]));
                    }
                    catch (Exception ex)
                    {
                        // trato la exception
                    }
                    version = vers;
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
            return version;
        }
        public void insertar(Versionado filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            
            listado.Add(Parameter.addParameter("@version", filtro.subversion.ToString() , SqlDbType.Int ));
            listado.Add(Parameter.addParameter("@subversion", filtro.subversion.ToString(), SqlDbType.Int));
            listado.Add(Parameter.addParameter("@estado", filtro.estado.codigo.ToString(), SqlDbType.Int));

            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@nombreOriginal", filtro.nombreOriginal, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@tipoContenido", filtro.tipoContenido, SqlDbType.VarChar));

            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@fechaRegistro", filtro.auditoria.fechaRegistro, SqlDbType.DateTime));
            
            listado.Add(Parameter.addParameter("@documento", filtro.documento.id.ToString(), SqlDbType.Int));
            listado.Add(Parameter.addParameter("@extension", filtro.extension, SqlDbType.VarChar));

            SqlParameter fileSP = new SqlParameter("@archivo", SqlDbType.VarBinary);
            fileSP.Value = filtro.archivo;
            listado.Add(fileSP);

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_VERSION);
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
        public void insertarArchivo(Versionado version)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("INSERT INTO VERSION(");
                query.Append("VERSION,SUBVERSION,ESTADO_ID,");
                query.Append("NOMBRE,NOMBRE_ORIGINAL,TIPO_CONTENIDO,");
                query.Append("ARCHIVO,USUARIO_ID,FECHA_REGISTRO,");
                query.Append("DOCUMENTO_ID,EXTENSION,ACTIVO,OBSERVACION");
                
                query.Append(" ) VALUES ( ");
                query.Append("@version,@subversion,@estado,");
                query.Append("@nombre,@nombreOriginal,@tipoContenido,");
                query.Append("@archivo,@usuario,@fechaRegistro,");
                query.Append("@documento,@extension,@activo,@observacion");
                query.Append(" )");


                using (SqlCommand cmd = new SqlCommand(query.ToString()))
                {
                    cmd.Connection = getSqlConnection();
                    cmd.Parameters.AddWithValue("@version", version.version);
                    cmd.Parameters.AddWithValue("@subversion", version.subversion);
                    cmd.Parameters.AddWithValue("@estado",version.estado.codigo);

                    cmd.Parameters.AddWithValue("@nombre", version.nombre);
                    cmd.Parameters.AddWithValue("@nombreOriginal", version.nombreOriginal);
                    cmd.Parameters.AddWithValue("@tipoContenido", version.tipoContenido);

                    cmd.Parameters.AddWithValue("@archivo", version.archivo);

                    cmd.Parameters.AddWithValue("@usuario", version.auditoria.usuario.nombre);
                    cmd.Parameters.AddWithValue("@fechaRegistro", version.auditoria.fechaRegistro);

                    cmd.Parameters.AddWithValue("@documento", version.documento.id.ToString());
                    cmd.Parameters.AddWithValue("@extension", version.extension);
                    cmd.Parameters.AddWithValue("@activo", version.activo);

                    cmd.Parameters.AddWithValue("@observacion", version.observacion);

                    getSqlConnection().Open();
                    cmd.ExecuteNonQuery();
                    getSqlConnection().Close();

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
        }

        public void modificar(Versionado version, bool updateFile)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" UPDATE VERSION ");
                query.Append(" SET OBSERVACION =@observacion, ");
                query.Append("  ESTADO_ID = @estado, ");
                if (updateFile)
                {
                    query.Append(" ARCHIVO =@archivo, ");
                    query.Append(" EXTENSION = @extension, ");
                    query.Append(" TIPO_CONTENIDO = @tipoContenido, ");
                    query.Append(" NOMBRE_ORIGINAL=@nombreOriginal, ");

                }
                query.Append(" FECHA_REGISTRO = @fechaRegistro, ");
                query.Append(" USUARIO_ID = @usuario ");
                query.Append(" WHERE ID= @id ");

                using (SqlCommand cmd = new SqlCommand(query.ToString()))
                {
                    cmd.Connection = getSqlConnection();

                    cmd.Parameters.AddWithValue("@estado", version.estado.codigo);
                    cmd.Parameters.AddWithValue("@observacion", version.observacion);
                    if (updateFile)
                    {
                        cmd.Parameters.AddWithValue("@archivo", version.archivo);
                        cmd.Parameters.AddWithValue("@extension", version.extension);
                        cmd.Parameters.AddWithValue("@tipoContenido", version.tipoContenido);
                        cmd.Parameters.AddWithValue("@nombreOriginal", version.nombreOriginal);
                    }
                    cmd.Parameters.AddWithValue("@usuario", version.auditoria.usuario.nombre);
                    cmd.Parameters.AddWithValue("@fechaRegistro", version.auditoria.fechaRegistro);

                    cmd.Parameters.AddWithValue("@id", version.id);

                    getSqlConnection().Open();
                    cmd.ExecuteNonQuery();
                    getSqlConnection().Close();

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
        }
        public void modificar(Versionado filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@id", filtro.id, SqlDbType.Int));
            listado.Add(Parameter.addParameter("@estado", filtro.estado.codigo.ToString(), SqlDbType.Int));
            listado.Add(Parameter.addParameter("@observacion", filtro.extension, SqlDbType.VarChar));

            listado.Add(Parameter.addParameter("@nombreOriginal", filtro.nombreOriginal, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@tipoContenido", filtro.tipoContenido, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@extension", filtro.extension, SqlDbType.VarChar));

            listado.Add(Parameter.addParameter("@usuario", filtro.auditoria.usuario.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@fechaRegistro", filtro.auditoria.fechaRegistro, SqlDbType.DateTime));

            
            SqlParameter fileSP = new SqlParameter("@archivo", SqlDbType.VarBinary);


            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_MODIFICAR_VERSION);
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

        public void eliminar(Versionado filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();

            listado.Add(Parameter.addParameter("@version", filtro.version.ToString(), SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@subversion", filtro.subversion.ToString(), SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@documento", filtro.documento.id, SqlDbType.Int));


            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_ELIMINAR_VERSION);
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
