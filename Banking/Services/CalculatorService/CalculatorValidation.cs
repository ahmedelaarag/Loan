using System;
using System.Collections.Generic;
using Banking.Entites;
using Banking.Resources;

namespace Banking.Services.CalculatorService
{
    public class CalculatorValidation : ICalculatorValidation
    {
        public ICollection<IErrorResult> Validate(Loan loanDto)
        {
            var errors = new List<IErrorResult>();

            if (loanDto.Amount <= decimal.Zero)
            {
                errors.Add(new ErrorResult(Guid.NewGuid(), $"{nameof(loanDto.Amount)} can't be empty."));
            }

            if (loanDto.Duration <= default(double))
            {
                errors.Add(new ErrorResult(Guid.NewGuid(), $"{nameof(loanDto.Duration)} can't be empty."));
            }

            return errors;
        }
    }
}