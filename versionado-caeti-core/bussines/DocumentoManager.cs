

using System;
using System.Collections.Generic;
using versionado_caeti_dao;
using versionado_caeti_entity;
using versionado_caeti_entity.exception;
using System.Linq;
using versionado_caeti_entity.constante;
using versionado_caeti_entity.view;

namespace versionado_caeti_core
{
   public class DocumentoManager
    {

       private static DocumentoManager instance = new DocumentoManager();
        
        public static DocumentoManager getInstance()
        {
            return instance;
        }

       public List<Documento> consultar(Documento filtro) {

           List<Documento> listado = new List<Documento>();
           try
           {
               List<Documento> encontrados= DocumentoDao.getInstance().consultar(filtro);
               listado.AddRange(encontrados.FindAll(x => x.activo == filtro.activo).ToList());
               
           }
           catch (Exception ex) { 
           
           }
           return listado;
       }
       public List<DocumentoView> consultarDocumento(Documento filtro)
       {

           List<DocumentoView> listado = new List<DocumentoView>();
           try
           {
               foreach(Documento item in consultar(filtro)){
                   listado.Add(new DocumentoView(item));
               }
           }
           catch (Exception ex)
           {

           }
           return listado;
       }
       public Documento consultarId(int id)
       {

           Documento encontrado = null;
           try
           {
               encontrado = DocumentoDao.getInstance().consultar(id);
               if (encontrado == null || !(encontrado.activo)) {
                   encontrado = null;
               }
             
           }
           catch (Exception ex)
           {

           }

           return encontrado;
       }
       public List<Documento> consultar(String parteNombre)
       {

           List<Documento> listado = new List<Documento>();

           if (parteNombre == null || parteNombre == String.Empty)
           {
               // throw new  SecurityException("10","Ingrese el criterio de busqueda ");
               List<Documento> encontrados = DocumentoDao.getInstance().consultar(new Documento());
               listado.AddRange(encontrados.FindAll(x => x.activo == true).ToList());
           }
               
           try
           {
               List<Documento> encontrados = DocumentoDao.getInstance().consultar(parteNombre);
               listado.AddRange(encontrados.FindAll(x => x.activo == true).ToList());
               
           }
           catch (Exception ex)
           {
               throw new SecurityException("10", "Por favor intente mas tarde ");
           }
           return listado;
       }
       public List<Documento> consultar(Int16 ids)
       {

           if (ids == null || ids == 0)
           {
               throw new SecurityException("10", "Ingrese el criterio de busqueda ");
           }

           List<Documento> listado = new List<Documento>();
           try
           {
               listado.AddRange(DocumentoDao.getInstance().consultar(ids));
           }
           catch (Exception ex)
           {
               throw new SecurityException("10", "Por favor intente mas tarde ");
           }
           return listado;
       }
       public void agregar(Documento filtro)
       {
           
               //Verifica que no exista este tipo
               List<Documento> existe = DocumentoDao.getInstance().consultar(filtro.nombre,true);
               if (existe != null && existe.Count > 0)
               {
                 
                       throw new SecurityException("12", "El Documento ya existe");
                   
               }
               DocumentoDao.getInstance().insertar(filtro);
           
       } 
     
       public void eliminar(Documento filtro)
       {
           DocumentoDao.getInstance().eliminar(filtro);

       }

       public void modificar(Documento filtro)
       {
           try
           {
               if (filtro == null || filtro.descripcion == null ) {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_903.ToString(), ErrorConstante.WARNING_DOCUMENTO_903.ToString());
              
               }
               Documento old = DocumentoDao.getInstance().consultar(filtro.id);
              
                //Existe documento
               if (old == null)
               {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_904.ToString(), ErrorConstante.WARNING_DOCUMENTO_904.ToString());
               }

               if (filtro.Equals(old))
               {
                   throw new SecurityException(ErrorConstante.WARNING_DOCUMENTO_906.ToString(), ErrorConstante.WARNING_DOCUMENTO_906.ToString());
               }

               DocumentoDao.getInstance().modificar(filtro);
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

      
    }
}
