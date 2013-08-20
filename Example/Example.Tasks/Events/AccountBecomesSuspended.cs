using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Domain;
using Mosquito.Core;

namespace Example.Tasks.Events
{
    public class AccountBecomesSuspended : IEvent
    {
        public Account Account { get; set; }
    }
}
