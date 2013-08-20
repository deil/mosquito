using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Events;
using Mosquito.Core;

namespace Example.Tasks.Handlers
{
    public class PositiveAccountBalanceHandler : IHandles<AccountBalanceBecomesPositive>
    {
        public void Handle(AccountBalanceBecomesPositive args)
        {
            throw new NotImplementedException();
        }
    }
}
