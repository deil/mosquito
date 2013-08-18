using System;

namespace Mosquito.Core
{
    public interface ICommandProcessor
    {
        void Process<T>(T command) where T : ICommand;
    }
}

