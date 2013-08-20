using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Tasks.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public Customer Owner { get; set; }
        public bool IsSuspended { get; set; }
    }
}
