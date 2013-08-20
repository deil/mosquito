using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Tasks.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
    }
}
