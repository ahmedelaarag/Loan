using Banking.Entites;

namespace Banking.Services.CalculatorService
{
    public interface ICalculator
    {
        ICalculationResult Calculate(Loan loan, double interestRate);
    }
}