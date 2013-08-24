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
        static KnownTypesProvider()
        {
            _registeredTypes.Add(typeof(Processing.Operation));
            _registeredCallbackTypes.Add(typeof(Processing.Operation));
        }

        public static void RegisterType<T>()
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("Adding {0} to known types.", typeof(T).FullName);

            _registeredTypes.Add(typeof(T));
        }

        public static void RegisterCallbackType<T>()
        {
            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("Adding {0} to known callback types.", typeof(T).FullName);

            _registeredCallbackTypes.Add(typeof(T));
        }

        public static IEnumerable<Type> GetRegisteredTypes(ICustomAttributeProvider provider)
        {
            return _registeredTypes;
        }

        public static IEnumerable<Type> GetRegisteredCallbackTypes(ICustomAttributeProvider provider)
        {
            return _registeredCallbackTypes;
        }

        private static ILog Logger
        {
            get { return LogManager.GetLogger(typeof(KnownTypesProvider)); }
        }

        private static readonly IList<Type> _registeredTypes = new List<Type>();
        private static readonly IList<Type> _registeredCallbackTypes = new List<Type>();
    }
}
