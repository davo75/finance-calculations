using Finance.Library;
using System;
using Xunit;

namespace Finance.UnitTests
{
    /// <summary>
    /// Set of unit tests to verify the functionality of the FinanceLib library
    /// </summary>
    public class FinanceTests   
    {
        [Fact]
        public void Should_Return_Monthly_Repayment()
        {
            //Arrange
            double loanAmount = 10000;
            double interestRate = 4.8;
            int loanTerm = 3;

            //Act
            FinanceLib sut = new FinanceLib();
            var repayment = sut.GetRepayment(loanAmount, interestRate, loanTerm);
            
            //Assert
            Assert.Equal(298.81, Math.Round(repayment,2));
        }

        [Fact]
        public void Should_Return_Presnt_Value_Of_Loan()
        {
            //Arrange
            double repayment = 250;
            double interestRate = 4.8;
            int loanTerm = 3;

            //Act
            FinanceLib sut = new FinanceLib();
            var presentValue = sut.GetPresentValue(repayment, interestRate, loanTerm);

            //Assert
            Assert.Equal(8366.47, Math.Round(presentValue,2));
        }
    }
}
