using System;
using Banking.Entites;
using Banking.Services.CalculatorService;
using Banking.Resources;
using Xunit;

namespace BankingTest.CalculatorServiceTests
{
    public class CalculatorTests
    {
        private readonly ICalculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator(new CalculatorValidation());
        }

        [Fact]
        public void ValidateNullConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Calculator(null));
        }
        
        [Theory]
        [InlineData(500000, 10, 5,  "5,303.28", "636,393.09")]
        [InlineData(100000, 10, 6,  "1,110.21", "133,224.6")]
        [InlineData(1000, 1, 8,  "86.99", "1,043.86")]
        [InlineData(1000000, 14.5f, 11.5d,  "11,834.53", "2,059,207.75")]
        public void CalculateSuccessfulTests(
            decimal amount, 
            double duration, 
            double rate,
            string expectedMonthlyPayment,
            string expectedTotalPayment)
        {
            var loan = new Loan(amount, duration);
            var result = _calculator.Calculate(loan, rate);
            
            Assert.NotNull(result);
            Assert.Equal(result.MonthlyPayment.ToStringFormat(), expectedMonthlyPayment);
            Assert.Equal(result.TotalPaymentOverTheLoanPeriod.ToStringFormat(), expectedTotalPayment);
        }

        [Theory]
        [InlineData(true, 5)]
        [InlineData(false, 0)]
        public void CalculateShouldThrowExceptionTests(bool nullableLoan, double rate)
        {
            var loan = nullableLoan ? null : new Loan(0, 0);

            if (nullableLoan)
            {
                Assert.Throws<ArgumentNullException>(() => _calculator.Calculate(loan, rate));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => _calculator.Calculate(loan, rate));
            }
        }
        
        [Theory]
        [InlineData(0, 10, 5, true)]
        [InlineData(100000, 0, 6, true)]
        [InlineData(100000, 10, 6, false)]
        public void CalculateShouldReturnErrorResultTests(
            decimal amount, 
            double duration, 
            double rate,
            bool expectedErrorToReturn)
        {
            var loan = new Loan(amount, duration);
            var result = _calculator.Calculate(loan, rate);
            
            Assert.NotNull(result);
            if (expectedErrorToReturn) Assert.NotEmpty(result.ErrorResults);
            else Assert.Empty(result.ErrorResults.CurrentOrEmpty());
        }
    }

}