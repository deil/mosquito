using System;
using Microsoft.Practices.ServiceLocation;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito
{
    sealed public class CommandProcessor : ICommandProcessor
    {
        public void Process<T>(T command) where T : ICommand
        {
            var channel = ServiceLocator.Current.GetInstance<IMosquitoChannel>();
            channel.ProcessCommand(command);
        }

        public TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        public void Process<TCommand, TResult>(TCommand command, Action<TResult> callback) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
    }
}
