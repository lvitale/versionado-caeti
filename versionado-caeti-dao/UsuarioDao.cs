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
  public class UsuarioDao  :  DBConnection,IDao<Usuario>
    {
      private static UsuarioDao instance=new UsuarioDao();
        private SqlConnection connection;
      
        public static UsuarioDao getInstance(){
            return instance;
        }

        public Usuario consultarUno(Usuario filtro)
        {
            Usuario usuario = new Usuario();
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@alias", filtro.nombre, SqlDbType.VarChar));
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_USUARIO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    usuario.clave = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_CLAVE]);
                    usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_NOMBRE]);
                    usuario.intentos = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_INTENTOS]);
                    usuario.activo = getDataBoolean(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_ACTIVO]));

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
            return usuario;
        }

        public List<Usuario> consultar(Usuario filtro)
        {
            List<Usuario> usuarios = new  List<Usuario>();
           
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            
            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_USUARIOS);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.clave = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_CLAVE]);
                    usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_NOMBRE]);
                    usuario.intentos = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_INTENTOS]);
                    usuario.activo = getDataBoolean(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_ACTIVO]));
                    
                    usuarios.Add(usuario);
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
            return usuarios;
        }

        public List<Usuario> consultar(String parteNombre)
        {
            List<Usuario> usuarios = new List<Usuario>();

            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", parteNombre, SqlDbType.VarChar));

            SqlDataReader reader;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_PARTE_NOMBRE_USUARIO);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.clave = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_CLAVE]);
                    usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_NOMBRE]);
                    usuario.intentos = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_INTENTOS]);
                    usuario.activo = getDataBoolean(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_ACTIVO]));
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
            return usuarios;
        }
        public List<Usuario> consultarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<SqlParameter> listado = new List<SqlParameter>();
            SqlDataReader reader=null;

            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_CONSULTAR_TODOS_USUARIOS);
                reader = executeReader(listado);
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.clave = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_CLAVE]);
                    usuario.nombre = Convert.ToString(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_NOMBRE]);
                    usuario.intentos = Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_INTENTOS]);
                    usuario.activo = getDataBoolean(Convert.ToInt16(reader[BaseDatoConstante.PROPERTY_TABLE_USUARIO_ACTIVO]));
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
            return usuarios;
        }

        public void insertar(Usuario filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@clave", filtro.clave, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@activo", filtro.activo.ToString(), SqlDbType.Bit));
            listado.Add(Parameter.addParameter("@intentos", filtro.intentos.ToString(), SqlDbType.Int));
            
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_INSERTAR_USUARIO);
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

        public void modificar(Usuario filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@clave", filtro.clave, SqlDbType.VarChar));
            listado.Add(Parameter.addParameter("@activo", filtro.activo.ToString(), SqlDbType.Bit));
            listado.Add(Parameter.addParameter("@intentos", filtro.intentos.ToString(), SqlDbType.Int));
            
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_MODIFICAR_USUARIO);
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

        public void eliminar(Usuario filtro)
        {
            List<SqlParameter> listado = new List<SqlParameter>();
            listado.Add(Parameter.addParameter("@nombre", filtro.nombre, SqlDbType.VarChar));
            
            try
            {
                connectDatabaseAndCreateStoreProceduce(BaseDatoConstante.NAME_DATABASE_VERSIONADO_CAETI, ProcedureConstante.PROCEDURE_NAME_ELIMINAR_USUARIO);
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
