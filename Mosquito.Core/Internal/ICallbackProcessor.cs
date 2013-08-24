using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mosquito.Core.Internal
{
    public interface ICallbackProcessor
    {
        void ProcessCallback(OperationResult result);
    }
}
