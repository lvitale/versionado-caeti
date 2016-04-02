using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versionado_caeti_core.utils;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.exception;

namespace versionado_caeti_core.bussines
{
    public class VersionManager
    {
         private static VersionManager instance = new VersionManager();
        
        public static VersionManager getInstance()
        {
            return instance;
        }
       public List<Versionado> consultar(Versionado filtro) {

           List<Versionado> listado = new List<Versionado>();
           try
           {
               listado.AddRange( VersionDao.getInstance().consultar(filtro)); 
           }
           catch (Exception ex) { 
           
           }
           return listado;
       }
       public List<Versionado> consultar(Int16 docId,String nombre)
       {

           if (nombre == null || nombre == String.Empty)
           {
               throw new SecurityException("10", "Ingrese el criterio de busqueda ");
           }
           List<Versionado> listado = new List<Versionado>();
           try
           {
               listado.AddRange(VersionDao.getInstance().consultar(docId,nombre));
           }
           catch (Exception ex)
           {

           }
           return listado;
       }
       public List<Versionado> consultarPorDoc(int docId)
       {

           List<Versionado> listado = new List<Versionado>();
           try
           {
               listado.AddRange(VersionDao.getInstance().consultar(docId));
           }
           catch (Exception ex)
           {

           }
           return listado;
       }
       public Versionado consultar(int id)
       {

           Versionado item = VersionDao.getInstance().consultarPorId(id);
           return item;
       }
       public void agregar(Versionado filtro)
       {
                //Verifica que no exista este documento
                Versionado existe = VersionDao.getInstance().consultarUno(filtro);
                if (existe != null) {
                    throw new SecurityException("12","La version ya existe");
                }
               
                VersionDao.getInstance().insertarArchivo(filtro);
             
       }
       public void eliminar(Versionado filtro)
       {
           VersionDao.getInstance().eliminar(filtro);

       }

       public void modificar(Versionado filtro)
       {
           try
           {
               if (filtro == null || StringUtils.isEmptyOrNull(filtro.observacion) || filtro.estado.codigo==null || filtro.archivo==null)
               {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_903.ToString(), ErrorConstante.WARNING_DOCUMENTO_903.ToString());

               }
               Versionado old = VersionDao.getInstance().consultarUno(filtro);

               //Existe documento
               if (old == null)
               {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_904.ToString(), ErrorConstante.WARNING_DOCUMENTO_904.ToString());
               }

               if (filtro.Equals(old) && StringUtils.isEqualByte(old.archivo, filtro.archivo))
               {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_906.ToString(), ErrorConstante.WARNING_DOCUMENTO_906.ToString());
               }


               VersionDao.getInstance().modificar(filtro, !(StringUtils.isEqualByte(old.archivo, filtro.archivo)));
           }
           catch (DaoException ex)
           {

               throw new SecurityException(ex.code, ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
           }
           catch (SecurityException ex)
           {

               throw new SecurityException(ex.code, ex.Message);
           }
           catch (Exception ex)
           {

               throw new SecurityException(ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE.ToString(), ErrorConstante.ERROR_EXCEPTION_INSERT_DELETE_UPDATE);
           }
       }
        public void armarNombreVersion(Versionado filtro) {
                String nombre = String.Empty;
                String[] value = filtro.nombreOriginal.Split('.');
              
                filtro.extension = value[1];
                filtro.nombre = filtro.nombre + "-v." + filtro.version.ToString() + "." + filtro.subversion.ToString();
       }
        public String armarNombre(Versionado item) {
            StringBuilder nombre = new StringBuilder();
            nombre.Append(item.nombre);
            nombre.Append(".");
            nombre.Append(item.extension);
            return nombre.ToString();
        }
    }
    
    
}
