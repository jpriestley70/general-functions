using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace GeneralFunctions.Library.Extensions
{
    public static class CloneExtension
    {
        /// <summary>
        /// Clone Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="deepClone">If the value is true the object will be cloned a using binary formatter. If the value is false JSON is used to serialize and deserialize the object. Default is set to false.</param>
        /// <returns></returns>
        public static T Clone<T>(this T source, bool deepClone = false)
        {
            // Is object NULL?
            if (source is null)
            {
                return default;
            }

            if (deepClone)
            {
                // Is Object serializable?
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.");
                }

                IFormatter formatter = new BinaryFormatter();
                using (MemoryStream mem = new MemoryStream())
                {
                    formatter.Serialize(mem, source);
                    mem.Seek(0, SeekOrigin.Begin);

                    return (T)formatter.Deserialize(mem);
                }
            }
            else
            {
                JsonSerializerSettings settings = new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), settings);
            }
        }
    }
}
