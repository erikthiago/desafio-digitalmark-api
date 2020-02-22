using SistEnferHos.Domain.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistEnferHos.Domain.Helpers
{
    class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
