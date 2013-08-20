using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Events;
using Mosquito.Core;

namespace Example.Tasks.Handlers
{
    public class NegativeAccountBalanceHandler : IHandles<AccountBalanceBecomesNegative>
    {
        public void Handle(AccountBalanceBecomesNegative args)
        {
            throw new NotImplementedException();
        }
    }
}
