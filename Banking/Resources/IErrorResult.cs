using System;

namespace Banking.Resources
{
    public interface IErrorResult
    {
        string Message { get; }
        Guid Id { get; }
    }
}