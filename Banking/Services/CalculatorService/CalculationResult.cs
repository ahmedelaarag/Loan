using System;
using System.Collections.Generic;
using Banking.Resources;

namespace Banking.Services.CalculatorService
{
    internal class CalculationResult : ICalculationResult
    {
        public CalculationResult(ICollection<IErrorResult> errorResults)
            : this(decimal.Zero, decimal.Zero, decimal.Zero)
        {
            ErrorResults = errorResults.CurrentOrEmpty();
        }

        public CalculationResult(
            decimal monthlyPayment,
            decimal totalPaymentOverTheLoanPeriod,
            decimal totalPaymentInInterestRate)
        {
            MonthlyPayment = monthlyPayment;
            TotalPaymentOverTheLoanPeriod = totalPaymentOverTheLoanPeriod;
            TotalPaymentInInterestRate = totalPaymentInInterestRate;
        }

        public decimal MonthlyPayment { get; }
        public decimal TotalPaymentInInterestRate { get; }
        public decimal TotalPaymentOverTheLoanPeriod { get; }
        
        public ICollection<IErrorResult> ErrorResults { get; }
    }
}