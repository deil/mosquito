using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Example.Tasks.Commands;
using Example.Tasks.Handlers;

namespace Example.Host
{
    public class Console
    {
        public static void Main(string[] args)
        {
            var configurator = new Mosquito.Service.Configurator();
            configurator.RegisterCommandHandler<ProcessPaymentCommand, ProcessPaymentCommandHandler>();
            var service = configurator.Build();
            service.Start();
            Thread.Sleep(new TimeSpan(1, 0, 0));
            service.Stop();
        }
    }
}
