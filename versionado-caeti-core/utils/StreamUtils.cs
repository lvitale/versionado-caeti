using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_core.utils
{
   public class StreamUtils
    {
       private static StreamUtils instance = new StreamUtils();
 
       private StreamUtils() { 
       }

       public static StreamUtils getInstance() {
           return instance;
       }

       public MemoryStream cast(Stream file)
       {
           MemoryStream memory = new MemoryStream();
           copyStream(file, memory);
           return memory;
       }

       private void copyStream(Stream input, Stream output)
       {
           byte[] buffer = new byte[16 * 1024];
           int read;
           while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
           {
               output.Write(buffer, 0, read);
           }
       }
    }
}
