using System;
using Mosquito.Core;

namespace Mosquito
{
    public static class Event
    {
        public static void Raise<T>(T @event) where T : IEvent
        {
        }

        public static void Register<T>(Action<T> callback) where T : IEvent
        {
        }

        public static void ClearCallbacks()
        {
        }
    }
}

