using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nfield.Infrastructure
{
    /// <summary>
    /// Utility class that allows converion from objects to json and vice versa.
    /// </summary>
    /// 
    /// <remarks>
    /// By using <see cref="JsonConverter.Create"/>
    /// calls to this class can be mockecd in unit testing
    /// </remarks>
    internal class JsonConverter : FactoryBase<JsonConverter, IJsonConverter>, IJsonConverter
    {
        #region IJsonConverter implementation

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        #endregion
    }
}
