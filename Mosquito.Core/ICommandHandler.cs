using System;

namespace Mosquito.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand where TResult : class
    {
        TResult Handle(TCommand command);
    }
}
