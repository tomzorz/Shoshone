using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Shoshone.Data
{
    public class Serializer<T>
    {
        private readonly List<Type> _additionalKnownTypes;

        public Serializer()
        {
            _additionalKnownTypes = new List<Type>();
        }

        public Serializer(IEnumerable<Type> additionalKnownTypes)
        {
            _additionalKnownTypes = new List<Type>();
            _additionalKnownTypes.AddRange(additionalKnownTypes);

        }

        public byte[] Serialize(T data)
        {
#if UNITY_WSA_10_0
            var dcs = new DataContractSerializer(typeof(T), _additionalKnownTypes);
            var ms = new MemoryStream();
            dcs.WriteObject(ms, data);
            return ms.ToArray();
#else
            var ms = new MemoryStream();
            var bf = new BinaryFormatter();
            bf.Serialize(ms, data);
            var retVal = ms.ToArray();
            ms.Close();
            return retVal;
#endif
        }

        public T Deserialize(byte[] data)
        {
#if UNITY_WSA_10_0
            var dcs = new DataContractSerializer(typeof(T), _additionalKnownTypes);
            var ms = new MemoryStream(data);
            return (T) dcs.ReadObject(ms);
#else
            var bf = new BinaryFormatter();
            var ms = new MemoryStream(data);
            var retVal = (T) bf.Deserialize(ms);
            ms.Close();
            return retVal;
#endif
        }

    }
}