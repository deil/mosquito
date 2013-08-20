using System;
using Mosquito.Core;
using Mosquito.Core.Internal;

namespace Mosquito
{
    sealed public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor(IMosquitoChannel channel)
        {
            _channel = channel;
        }

        public void Process<T>(T command) where T : ICommand
        {
            _channel.ProcessCommand(command);
        }

        public TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        public void Process<TCommand, TResult>(TCommand command, Action<TResult> callback) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        private readonly IMosquitoChannel _channel;
    }
}
