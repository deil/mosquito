using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosquito.Core.Bus
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid InReplyTo { get; set; }
        public object Data { get; set; }
    }
}
