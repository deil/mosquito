using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Commands;
using Mosquito.Core;

namespace Example.Tasks.Handlers
{
    public class ProcessPaymentCommandHandler : ICommandHandler<ProcessPaymentCommand, decimal[]>
    {
        public decimal[] Handle(ProcessPaymentCommand command)
        {
            return new[] {command.AccountId, command.Amount};
        }
    }
}
