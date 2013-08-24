using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using log4net;
using Mosquito.Core;
using Mosquito.Core.Bus;
using Mosquito.Core.Processing;
using Operation = Mosquito.Core.Internal.Operation;

namespace Mosquito
{
    sealed public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor(IBus bus)
        {
            _bus = bus;
            _pendingOperations = new List<Operation>();
        }

        public void Process<T>(T command) where T : ICommand
        {
            throw new NotImplementedException();
        }

        public TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand where TResult : class
        {
            var operation = new Operation
                                {
                                    Id = Guid.NewGuid(),
                                    ReturnType = typeof (TResult),
                                    Time = DateTime.Now,
                                    AsyncWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset)
                                };

            lock (_pendingOperations)
            {
                _pendingOperations.Add(operation);
            }

            var message = BuildMessage(operation.Id, command, typeof(TResult));
            _bus.SendAndWait(message, Callback);

            operation.AsyncWaitHandle.WaitOne();

            if (operation.IsCompleted)
            {
                return (TResult) operation.Result;
            }
            else
            {
                throw new ApplicationException("Operation didn't complete");
            }
        }

        public void Process<TCommand, TResult>(TCommand command, Action<TResult> callback) where TCommand : ICommand where TResult : class
        {
            throw new NotImplementedException();
        }

        public void Callback(Message message)
        {
            Operation operation;
            lock (_pendingOperations)
            {
                operation = _pendingOperations.FirstOrDefault(op => op.Id == message.InReplyTo);
                if (operation != null)
                {
                    operation.IsCompleted = true;
                    _pendingOperations.Remove(operation);
                }
            }

            if (operation != null)
            {
                operation.Result = message.Data;
                operation.AsyncWaitHandle.Set();
            }
        }

        private readonly IBus _bus;
        private readonly IList<Operation> _pendingOperations;

        private Message BuildMessage<TCommand>(Guid id, TCommand command, Type resultType)
        {
            return new Message
                       {
                           Id = id,
                           Data = new global::Mosquito.Core.Processing.Operation(OperationType.Command)
                                      {
                                          Input = command,
                                          OutputTypeName = resultType.FullName
                                      }
                       };
        }
    }
}
