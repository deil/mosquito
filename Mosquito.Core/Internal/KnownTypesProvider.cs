using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mosquito.Core.Internal
{
    public sealed class KnownTypesProvider
    {
        public static void RegisterType<T>()
        {
            _registeredTypes.Add(typeof(T));
        }

        public static IEnumerable<Type> GetRegisteredTypes(ICustomAttributeProvider provider)
        {
            return _registeredTypes;
        }

        private static IList<Type> _registeredTypes = new List<Type>();
    }
}
