using Banking.Entites;
using Banking.Services.CalculatorService;
using Xunit;

namespace BankingTest.CalculatorServiceTests
{
    public class ValidationTests
    {
        private readonly ICalculatorValidation _validation;

        public ValidationTests()
        {
            _validation = new CalculatorValidation();
        }
        
        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(1000, 0, false)]
        [InlineData(0, 5, false)]
        [InlineData(-1000, -1, false)]
        [InlineData(100000, 5, true)]
        public void ValidateLoanTests(decimal amount, double duration, bool isValid)
        {
            var allLoanDataNotValid = amount <= 0 && duration <= 0;
            var loan = new Loan(amount, duration);
            var validationResult = _validation.Validate(loan);
            Assert.NotNull(validationResult);

            if (isValid)
            {
                Assert.Empty(validationResult);
            }
            else
            {
                if (allLoanDataNotValid) Assert.Equal(2, validationResult.Count);
                else Assert.Single(validationResult);
            }
        }
    }
}