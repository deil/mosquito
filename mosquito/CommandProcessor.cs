using System;
using Mosquito.Core;

namespace Mosquito
{
    sealed public class CommandProcessor : ICommandProcessor
    {
        public void Process<T>(T command) where T : ICommand
        {
        }
    }
}
