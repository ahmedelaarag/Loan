using Banking.Entites;

namespace Banking.Services.LoanService
{
    public interface ILoanService
    {
        double AnnualInterest { get; set; }
        ILoanResult Calculate(Loan loan);
    }
}