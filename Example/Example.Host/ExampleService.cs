using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Example.Host
{
    public partial class ExampleService : ServiceBase
    {
        public ExampleService()
        {
            InitializeComponent();

            _core = new ExampleCore();
        }

        protected override void OnStart(string[] args)
        {
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }

        private readonly ExampleCore _core;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                _core.PerformRecurringOperations();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                timer1.Start();
            }
        }
    }
}
