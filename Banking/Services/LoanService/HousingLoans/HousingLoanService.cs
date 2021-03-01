using System;
using System.Linq;
using Banking.Entites;
using Banking.Services.CalculatorService;
using Banking.Resources;

namespace Banking.Services.LoanService
{
    internal class HousingLoanService : ILoanService
    {
        private readonly ICalculator _calculator;
        public HousingLoanService(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }
        
        public ILoanResult Calculate(Loan loan)
        {
            if (loan == null) throw new ArgumentNullException(nameof(loan));
            
            var calcResult = _calculator.Calculate(loan, AnnualInterest);
            if (calcResult.ErrorResults.CurrentOrEmpty().Any()) return new LoanResult(calcResult.ErrorResults);
            
            var administrationFee = GetAdministrationFee(loan);
            return new LoanResult(calcResult.MonthlyPayment.ToStringFormat(), calcResult.TotalPaymentInInterestRate.ToStringFormat(), calcResult.TotalPaymentOverTheLoanPeriod.ToStringFormat(), administrationFee);
        }

        public double AnnualInterest { get; set; } = 5.0;
        
        private static string GetAdministrationFee(Loan loan)
        {
            var adminFeeOnePercent = (Configuration.AdministrationInterest.ToDecimal() / 100) * loan.Amount;
            var administrationFee = adminFeeOnePercent > Configuration.MaxAdministrationFee
                ? Configuration.MaxAdministrationFee.ToStringFormat()
                : adminFeeOnePercent.ToStringFormat();
            return administrationFee;
        }
    }
}