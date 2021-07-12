using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GAMS.Classes
{
    class General
    {
   
            public static T Clone<T>(T obj)
        {
            T cloned = default(T);
            var serializer = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                cloned = (T)serializer.ReadObject(ms);
            }
            return cloned;
        }
   
    
    }
}
