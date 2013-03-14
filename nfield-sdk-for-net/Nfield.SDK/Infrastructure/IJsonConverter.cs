using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nfield.Infrastructure
{
    public interface IJsonConverter
    {
        string Serialize(object value);
        T Deserialize<T>(string value);
    }
}
