using System;

namespace Mosquito.Core
{
    public interface IHandles<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent args);
    }
}
