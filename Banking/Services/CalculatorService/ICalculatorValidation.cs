using System.Collections.Generic;
using Banking.Entites;
using Banking.Resources;

namespace Banking.Services.CalculatorService
{
    public interface ICalculatorValidation
    {
        ICollection<IErrorResult> Validate(Loan loanDto);
    }
}