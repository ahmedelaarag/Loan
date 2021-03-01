using System;
using System.Linq;
using Banking.Entites;
using Banking.Resources;
namespace Banking.Services.CalculatorService
{
    internal class Calculator : ICalculator
    {
        private const int Months = 12;
        private readonly ICalculatorValidation _validation;
        public Calculator(ICalculatorValidation validation)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }
        
        public ICalculationResult Calculate(Loan loan, double rate)
        {
            if (loan == null) throw new ArgumentNullException(nameof(loan));
            if (rate.Equals(default(double))) throw new ArgumentException($"{nameof(rate)} can not be zero");

            var validationErrors = _validation.Validate(loan);
            if (validationErrors.Any()) return new CalculationResult(validationErrors);
            
            var loanDuration = loan.Duration.ToDecimal();
            var monthlyInterestRate = rate / (Months * 100);
            var monthlyPayment = (loan.Amount.ToDouble() * monthlyInterestRate
                                  / (1 - 1 / Math.Pow(1 + monthlyInterestRate, loan.Duration * Months))).ToDecimal();

            
            var totalPayment = (monthlyPayment * loanDuration * Months).Round();
            var totalInterestPayment = (totalPayment - loan.Amount).Round();
            
            return new CalculationResult(monthlyPayment.Round(), totalPayment, totalInterestPayment);
        }
    }
}