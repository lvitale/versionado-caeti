using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity
{
   public class Tipo
    {
       private int _codigo;
       private String _area;
       private String _descripcion;

       public Tipo() { }

       public Tipo(int id) {
           _codigo = id;
       }
       public int codigo
       {
           get { return this._codigo; }
           set { this._codigo = value; }
       }

       public String area
       {
           get { return this._area; }
           set { this._area = value; }
       }

        public String descripcion
       {
           get { return this._descripcion; }
           set { this._descripcion = value; }
       }

        public override string ToString()
        {
            return area;
        }


    }
}
