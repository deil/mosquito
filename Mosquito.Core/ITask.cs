using System;

namespace Mosquito.Core
{
    public interface ITask
    {
        void Execute();
    }

    public interface ITask<TIn>
    {
        void Execute(TIn param);
    }

    public interface ITask<TIn, TOut>
    {
        TOut Execute(TIn param);
    }
}
