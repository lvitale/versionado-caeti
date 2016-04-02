

using System;
using System.Collections.Generic;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.exception;
namespace versionado_caeti_core.bussines
{
   public class EstadoManager
    {
        private static EstadoManager instance = new EstadoManager();
        
        public static EstadoManager getInstance()
        {
            return instance;
        }
       public List<Estado> consultar(Estado filtro) {

           List<Estado> listado = new List<Estado>();
           try
           {
               listado.AddRange( EstadoDao.getInstance().consultar(filtro)); 
           }
           catch (Exception ex) { 
           
           }
           return listado;
       }
       public Estado consultar(Int32 id)
       {

           Estado item = new Estado();
           try
           {
               item=EstadoDao.getInstance().consultar(id);
           }
           catch (Exception ex)
           {

           }
           return item;
       }
       public List<Estado> consultar(String descripcion)
       {

           List<Estado> listado = new List<Estado>();
           try
           {
               if (descripcion == null || descripcion == String.Empty)
               {
                   listado.AddRange(EstadoDao.getInstance().consultar(new Estado()));

               }
               else
               {
                   listado.AddRange(EstadoDao.getInstance().consultarParteNombre(descripcion));
               }
           }
           catch (Exception ex)
           {

           }
           return listado;
       }

       public void agregar(Estado filtro)
       {
                //Verifica que no exista este estado
                List<Estado> existe = EstadoDao.getInstance().consultar(filtro.descripcion);
                if (existe != null && existe.Count >0) {
                    throw new SecurityException("12","El estado ya existe");
                }
                EstadoDao.getInstance().insertar(filtro);
             
       }
    }
    
}
