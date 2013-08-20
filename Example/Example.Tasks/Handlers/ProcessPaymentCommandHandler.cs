using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Commands;
using Mosquito.Core;

namespace Example.Tasks.Handlers
{
    public class ProcessPaymentCommandHandler : ICommandHandler<ProcessPaymentCommand>
    {
        public void Handle(ProcessPaymentCommand command)
        {
            return;
        }
    }
}
