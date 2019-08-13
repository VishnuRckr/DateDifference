using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IFileAndDatabaseOperations
    {
        List<T> Serializer<T>(List<T> item);
        void Deserializer();
        void WriteToDatabase(List<PersonDetails> list);
    }
}
