using System.Collections.Generic;
using Banking.Resources;

namespace Banking.Services.CalculatorService
{
    public interface ICalculationResult
    {
        decimal MonthlyPayment { get; }
        decimal TotalPaymentInInterestRate { get; }
        decimal TotalPaymentOverTheLoanPeriod { get; }
        ICollection<IErrorResult> ErrorResults { get; }
    }
}