using System.Collections.Generic;
using Banking.Resources;

namespace Banking.Services.LoanService
{
    public interface ILoanResult
    { 
        string MonthlyPayment { get; }
        string TotalLoanPayment { get; }
        string TotalPaymentInInterestRate { get; }
        string AdministrationFee { get; }
        ICollection<IErrorResult> ErrorResults { get; }
    }
}