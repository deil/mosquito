using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Tasks.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
