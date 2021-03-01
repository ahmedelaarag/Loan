using System;
using Banking.Entites;
using Banking.Services.CalculatorService;
using Banking.Services.LoanService;
using Xunit;

namespace BankingTest.LoanServiceTests
{
    public class HousingLoanServiceTests
    {
        private readonly ILoanService _loanService;
        public HousingLoanServiceTests()
        {
            var calculatorValidation = new CalculatorValidation();
            var calculator = new Calculator(calculatorValidation);
            _loanService = new HousingLoanService(calculator);
        }

        [Fact]
        public void ValidateNullConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new HousingLoanService(null));
        }
        
        [Theory]
        [InlineData(500000, 10,  "5,303.28", "136,393.09", "636,393.09", "5,000")]
        [InlineData(100000, 10,  "1,060.66", "27,278.62", "127,278.62", "1,000")]
        [InlineData(1000, 1,  "85.61", "27.29", "1,027.29", "10")]
        [InlineData(1000000, 14.5f,  "8,091.47", "407,916.32", "1,407,916.32", "10,000")]
        [InlineData(2000000, 10,  "21,213.1", "545,572.37", "2,545,572.37", "10,000")]
        public void CalculateTest(
            decimal amount, 
            double duration, 
            string expectedMonthlyPayment,
            string expectedTotalPaymentInInterestRate,
            string expectedTotalPayment,
            string expectedAdministrationFee)
        {
            var loan = new Loan(amount, duration);
            var result = _loanService.Calculate(loan);
            
            Assert.NotNull(result);
            Assert.Equal(result.MonthlyPayment, expectedMonthlyPayment);
            Assert.Equal(result.TotalPaymentInInterestRate, expectedTotalPaymentInInterestRate);
            Assert.Equal(result.TotalLoanPayment, expectedTotalPayment);
            Assert.Equal(result.AdministrationFee, expectedAdministrationFee);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(100000, 0)]
        [InlineData(0, 0)]
        [InlineData(-10000, -10)]
        public void HousingCalculationShouldReturnErrorResultTests(
            decimal amount,
            double duration)
        {
            var loan = new Loan(amount, duration);
            var result = _loanService.Calculate(loan);

            Assert.NotNull(result);
            Assert.NotEmpty(result.ErrorResults);
            Assert.Null(result.AdministrationFee);
            Assert.Null(result.MonthlyPayment);
            Assert.Null(result.TotalLoanPayment);
            Assert.Null(result.TotalPaymentInInterestRate);
        }
    }
}