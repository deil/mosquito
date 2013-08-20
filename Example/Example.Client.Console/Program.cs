using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Commands;
using Microsoft.Practices.ServiceLocation;
using Mosquito.Core;

namespace Example.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var mosq = new Mosquito.Mosquito();
            mosq.RegisterCommand<ProcessPaymentCommand>();
            mosq.Start();

            mosq.CommandProcessor.Process(new ProcessPaymentCommand {AccountId = 1, Amount = 1200});

            System.Console.ReadKey();
            mosq.Stop();
        }
    }
}
