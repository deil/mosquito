using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;

namespace Mosquito.Core.Internal
{
    public sealed class KnownTypesProvider
    {
        public static void RegisterType<T>()
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("Adding {0} to known types.", typeof(T).FullName);

            _registeredTypes.Add(typeof(T));
        }

        public static IEnumerable<Type> GetRegisteredTypes(ICustomAttributeProvider provider)
        {
            return _registeredTypes;
        }

        private static ILog Logger
        {
            get { return LogManager.GetLogger(typeof(KnownTypesProvider)); }
        }

        private static IList<Type> _registeredTypes = new List<Type>();
    }
}
