using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Tasks.Commands;
using log4net;
using Microsoft.Practices.ServiceLocation;
using Mosquito.Core;

namespace Example.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var mosq = new Mosquito.Mosquito();
            mosq.RegisterCommand<ProcessPaymentCommand, decimal[]>();
            mosq.Start();

            var startDate = DateTime.Now;

            var result = mosq.CommandProcessor.Process<ProcessPaymentCommand, decimal[]>(new ProcessPaymentCommand {AccountId = 1, Amount = 1200});
            System.Console.WriteLine(string.Join(", ", result.ToArray()));

            System.Console.WriteLine(DateTime.Now - startDate);

            mosq.Stop();
        }
    }
}
