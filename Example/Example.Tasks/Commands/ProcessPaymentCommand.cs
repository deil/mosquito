using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mosquito.Core;

namespace Example.Tasks.Commands
{
    public class ProcessPaymentCommand : ICommand
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
