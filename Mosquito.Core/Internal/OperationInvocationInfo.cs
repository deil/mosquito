using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Mosquito.Core.Internal
{
    public class OperationInvocationInfo
    {
        public Guid Id { get; set; }
        public object Parameter { get; set; }
    }
}
