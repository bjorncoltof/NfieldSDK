using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nfield.Infrastructure
{
    internal class FactoryBase<T, V> where T : V, new()
    {
        private static Func<V> _creator = () => new T();

        public static void Initialize(Func<V> creator)
        {
            _creator = creator;
        }

        public static V Create()
        {
            return _creator();
        }

    }
}
