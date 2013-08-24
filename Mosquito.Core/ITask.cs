using System;

namespace Mosquito.Core
{
    public interface ITask
    {
        void Execute();
    }

    public interface ITask<in TIn>
    {
        void Execute(TIn param);
    }

    public interface ITask<in TIn, out TOut>
    {
        TOut Execute(TIn param);
    }
}
