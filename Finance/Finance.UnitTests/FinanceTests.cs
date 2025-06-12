using Finance.Library;
using System;
using System.Text;
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
            double expectedResult = 298.81;
            FinanceLib sut = new FinanceLib();

            //Act            
            double actualResult = sut.GetRepayment(loanAmount, interestRate, loanTerm);
            
            //Assert
            Assert.Equal(expectedResult, Math.Round(actualResult,2));
        }

        [Fact]
        public void Should_Return_Present_Value_Of_Loan()
        {
            //Arrange
            double repayment = 250;
            double interestRate = 4.8;
            int loanTerm = 3;
            double expectedResult = 8366.47;
            FinanceLib sut = new FinanceLib();

            //Act            
            double actualResult = sut.GetPresentValue(repayment, interestRate, loanTerm);

            //Assert
            Assert.Equal(expectedResult, Math.Round(actualResult,2));
        }

        [Fact]
        public void GetRepayment_Should_Throw_ArgumentOutOfRangeException_When_Loan_Amount_Less_Than_Zero()
        {            
            //Arrange
            double loanAmount = -1000;
            double interestRate = 4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();
                     
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetRepayment(loanAmount, interestRate, loanTerm); });
        }

        [Fact]
        public void GetRepayment_Should_Throw_ArgumentOutOfRangeException_When_Interest_Rate_Less_Than_Zero()
        {            
            //Arrange
            double loanAmount = 10000;
            double interestRate = -4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();
                     
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetRepayment(loanAmount, interestRate, loanTerm); });
        }

        [Fact]
        public void GetRepayment_Should_Throw_ArgumentOutOfRangeException_When_Loan_Term_Less_Than_Zero()
        {            
            //Arrange
            double loanAmount = 10000;
            double interestRate = 4.8;
            int loanTerm = -3;
            FinanceLib sut = new FinanceLib();
                     
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetRepayment(loanAmount, interestRate, loanTerm); });
        }

        [Fact]
        public void GetPresentValue_Should_Throw_ArgumentOutOfRangeException_When_Repayment_Less_Than_Zero()
        {            
            //Arrange
            double repayment = -10000;
            double interestRate = 4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();
                     
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetPresentValue(repayment, interestRate, loanTerm); });
        }

        [Fact]
        public void GetPresentValue_Should_Throw_ArgumentOutOfRangeException_When_Interest_Rate_Less_Than_Zero()
        {            
            //Arrange
            double repayment = 10000;
            double interestRate = -4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();
                     
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetPresentValue(repayment, interestRate, loanTerm); });
        }

        [Fact]
        public void GetPresentValue_Should_Throw_ArgumentOutOfRangeException_When_Loan_Term_Less_Than_Zero()
        {
            //Arrange
            double repayment = 10000;
            double interestRate = 4.8;
            int loanTerm = -3;
            FinanceLib sut = new FinanceLib();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {sut.GetPresentValue(repayment, interestRate, loanTerm); });
        }

        [Fact]
        public void ToString_Should_Return_Details_After_GetRepayment()
        {
            //Arrange
            double loanAmount = 10000;
            double interestRate = 4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();

            double repayment = sut.GetRepayment(loanAmount, interestRate, loanTerm);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Loan Amount: ${loanAmount}");
            expected.AppendLine($"Interest Rate: {interestRate}%");
            expected.AppendLine($"Loan Term: {loanTerm} years");
            expected.AppendLine($"Monthly Repayment: ${Math.Round(repayment, 2)}");
            expected.AppendLine($"Present Value: $0");

            //Assert
            Assert.Equal(expected.ToString(), sut.ToString());
        }

        [Fact]
        public void ToString_Should_Return_Details_After_GetPresentValue()
        {
            //Arrange
            double repayment = 250;
            double interestRate = 4.8;
            int loanTerm = 3;
            FinanceLib sut = new FinanceLib();

            double presentValue = sut.GetPresentValue(repayment, interestRate, loanTerm);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Loan Amount: $0");
            expected.AppendLine($"Interest Rate: {interestRate}%");
            expected.AppendLine($"Loan Term: {loanTerm} years");
            expected.AppendLine($"Monthly Repayment: ${Math.Round(repayment, 2)}");
            expected.AppendLine($"Present Value: ${Math.Round(presentValue, 2)}");

            //Assert
            Assert.Equal(expected.ToString(), sut.ToString());
        }
    }
}
