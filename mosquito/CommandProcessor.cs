using System;
using Mosquito.Core;

namespace Mosquito
{
    sealed public class CommandProcessor : ICommandProcessor
    {
        public void Process<T>(T command) where T : ICommand
        {
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
