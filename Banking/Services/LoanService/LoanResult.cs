using System.Collections.Generic;
using Banking.Resources;

namespace Banking.Services.LoanService
{
    public class LoanResult : ILoanResult
    {
        public LoanResult(ICollection<IErrorResult> errorResults)
        {
            ErrorResults = errorResults.CurrentOrEmpty();
        }
        
        public LoanResult(
            string monthlyPayment,
            string totalPaymentInInterestRate,
            string totalLoanPayment,
            string administrationFee)
        {
            AdministrationFee = administrationFee;
            MonthlyPayment = monthlyPayment;
            TotalLoanPayment = totalLoanPayment;
            TotalPaymentInInterestRate = totalPaymentInInterestRate;
        }

        public string MonthlyPayment { get; }
        public string TotalLoanPayment { get; }
        public string TotalPaymentInInterestRate { get; }
        public string AdministrationFee { get; }
        public ICollection<IErrorResult> ErrorResults { get; }
    }
}