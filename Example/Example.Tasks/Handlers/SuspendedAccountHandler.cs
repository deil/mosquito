﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Events;
using Mosquito.Core;

namespace Example.Tasks.Handlers
{
    public class SuspendedAccountHandler : IHandles<AccountBecomesSuspended>
    {
        public void Handle(AccountBecomesSuspended args)
        {
            throw new NotImplementedException();
        }
    }
}
