using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Mosquito.Core.Processing
{
    public class Operation
    {
        public Operation() {}

        public Operation(OperationType type)
        {
            Type = type;
        }

        public OperationType Type;
        public object Input;
        public string OutputTypeName;
    }
}
