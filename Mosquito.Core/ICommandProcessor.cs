using System;

namespace Mosquito.Core
{
    public interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand;
        void Process<TCommand, TResult>(TCommand command, Action<TResult> callback) where TCommand : ICommand;
    }
}

