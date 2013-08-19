using System;

namespace Mosquito.Core
{
    public interface IHandles<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent args);
    }
}
