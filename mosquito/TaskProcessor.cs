using System;
using Mosquito.Core;

namespace Mosquito
{
    sealed public class TaskProcessor : ITaskProcessor
    {
        public void Queue<T>(T task) where T : ITask
        {
        }
    }
}

