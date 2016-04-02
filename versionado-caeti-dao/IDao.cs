using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_dao
{
    public interface IDao<T>
    {
           List<T> consultar(T filter);
           T consultarUno(T filter);

           void insertar(T filter);
           void modificar(T filter);
           void eliminar(T filter);

    }   
}
