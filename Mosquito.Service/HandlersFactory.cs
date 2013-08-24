using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Mosquito.Core;

namespace Mosquito.Service
{
    sealed internal class HandlersFactory
    {
        public HandlersFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public object HandleCommand(ICommand arg, Type resultType)
        {
            return Handle(typeof (ICommandHandler<,>).MakeGenericType(arg.GetType(), resultType), arg);
        }

        public void HandleEvent(IEvent arg)
        {
            Handle(typeof(IHandles<>).MakeGenericType(arg.GetType()), arg);
        }

        #region private
        private readonly IWindsorContainer _container;

        private object Handle(Type handlerType, object arg)
        {
            var handlers = _container.ResolveAll(handlerType);
            foreach (var handler in handlers)
            {
                var handleMethod = handler.GetType().GetMethod("Handle");
                return handleMethod.Invoke(handler, new[] {arg});
            }

            return null;
        }
        #endregion
    }
}
