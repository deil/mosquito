using System;

namespace Mosquito.Core
{
    public interface ITaskProcessor
    {
        void Queue<T>(T task) where T : ITask;
    }
}
