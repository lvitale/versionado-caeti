using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_core.security;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.bussines
{
    public class TipoManager
    {
        private static TipoManager instance = new TipoManager();

        public static TipoManager getInstance()
        {
            return instance;
        }
        public List<Tipo> consultarTodos()
        {

            List<Tipo> listado = new List<Tipo>();
            try
            {
                listado.AddRange(TipoDao.getInstance().consultar(new Tipo()));
            }
            catch (Exception ex)
            {
                throw new SecurityException("10", "Por favor intente mas tarde ");
            }
            return listado;
        }
        public List<Tipo> consultar(Tipo filtro)
        {

            List<Tipo> listado = new List<Tipo>();
            try
            {
                listado.AddRange(TipoDao.getInstance().consultar(filtro));
            }
            catch (Exception ex)
            {
                throw new SecurityException("10", "Por favor intente mas tarde ");
            }
            return listado;
        }
        public List<Tipo> consultar(String parteArea)
        {

            List<Tipo> listado = new List<Tipo>();
            try
            {
                if (parteArea == null || parteArea == String.Empty)
                {
                    listado.AddRange(TipoDao.getInstance().consultar(new Tipo()));

                }
                else
                {
                    listado.AddRange(TipoDao.getInstance().consultarParteNombre(parteArea));
                }
            }
            catch (Exception ex)
            {

            }
            return listado;
        }
        public void agregar(Tipo filtro)
        {

            try
            {
                //Verifica que no exista este tipo
                List<Tipo> existe = TipoDao.getInstance().consultar(filtro.area);
                if (existe != null && existe.Count > 0)
                {
                    throw new SecurityException("12", "El tipo ya existe");
                }
                TipoDao.getInstance().insertar(filtro);
            }
            catch (Exception ex)
            {
                if (ex is SecurityException) {
                    throw new SecurityException("10", ex.Message);    
                }
                throw new SecurityException("10", "Por favor intente mas tarde ");
            }

        }

        public void eliminar(Tipo filtro)
        {
            TipoDao.getInstance().eliminar(filtro);

        }
    }
}
