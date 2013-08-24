using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mosquito.Core.Internal
{
    sealed public class Operation
    {
        public Guid Id { get; set; }
        public Type ReturnType { get; set; }
        public Delegate Callback { get; set; }
        public DateTime Time { get; set; }
        public EventWaitHandle AsyncWaitHandle { get; set; }
        public bool IsCompleted { get; set; }
        public object Result { get; set; }
    }
}
