using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity
{
   public class Versionado
    {
       private int _id;
       private Int16 _version;
       private Int16 _subversion;
       private Estado _estado;
       private byte[] _archivo;
       private String _nombre;
       private String _extension;
       private String _nombreOriginal;
       private String _tipoContenido;
       private String _observacion;
       private Boolean _activo;
       private Auditoria _auditoria;
       private Documento _documento;

       public Versionado() { 
        _documento = new Documento();
        _auditoria = new Auditoria();
        _auditoria.usuario = new Usuario();
        _estado = new Estado();
       }

       public Versionado(String _documentoIn)
       {
           _documento = new Documento();
           _documento.nombre =_documentoIn;
           _auditoria = new Auditoria();
           _auditoria.usuario = new Usuario();
           _estado = new Estado();
       }
       public Versionado(Int16 _documentoId)
       {
           _documento = new Documento();
           _documento.id = _documentoId;
           _auditoria = new Auditoria();
           _auditoria.usuario = new Usuario();
           _estado = new Estado();
       }
       public int id
       {
           get { return this._id; }
           set { this._id = value; }
       }
       public Int16 version
       {
           get { return this._version; }
           set { this._version = value; }
       }

       public Int16 subversion
       {
           get { return this._subversion; }
           set { this._subversion = value; }
       }

       public Estado estado
       {
           get { return this._estado; }
           set { this._estado = value; }
       }

       public byte[] archivo
       {
           get { return this._archivo; }
           set { this._archivo = value; }
       }

       public String nombre
       {
           get { return this._nombre; }
           set { this._nombre = value; }
       }
       public String extension
       {
           get { return this._extension; }
           set { this._extension = value; }
       }
       public String nombreOriginal
       {
           get { return this._nombreOriginal; }
           set { this._nombreOriginal = value; }
       }
       public String tipoContenido
       {
           get { return this._tipoContenido; }
           set { this._tipoContenido = value; }
       }
       public String observacion
       {
           get { return this._observacion; }
           set { this._observacion = value; }
       }
       public Boolean activo
       {
           get { return this._activo; }
           set { this._activo = value; }
       }
       public Auditoria auditoria
       {
           get { return this._auditoria; }
           set { this._auditoria = value; }
       }

       public Documento documento
       {
           get { return this._documento ; }
           set { this._documento  = value; }
       }

       public override bool Equals(object value)
       {
           Boolean isEqual = false;
           Versionado vers = null;
           if (!(value == null))
           {
               try
               {
                   vers = (Versionado)value;

                   if (vers.estado.codigo == this.estado.codigo && vers.observacion.Equals(this.observacion))
                   {
                       isEqual = true;
                   }
               }
               catch (Exception ex)
               {
                   Console.Write(ex.Message);
               }
           }
           return isEqual;
       }

      

       
    }
}
