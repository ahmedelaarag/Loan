using System;

namespace Banking.Resources
{
    internal class ErrorResult : IErrorResult
    {
        public ErrorResult(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
        
        public string Message { get; }
        public Guid Id { get; }
    }
}