using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ISerializationAndDeserialization
        
    {
        List<T> Serializer<T>(List<T> item);
        void Deserializer();
    }
}
