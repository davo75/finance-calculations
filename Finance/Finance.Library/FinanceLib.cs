using System;

namespace Finance.Library
{
    /// <summary>
    /// Finance class to calculate monthly loan repayments and present value of a loan
    /// </summary>
    public class FinanceLib
    {
        //loan amount
        private double _loanAmount;
        //interest rate as a decimal
        private double _interestRateDecimal;
        //loan term in months
        private int _loanTermMonths;
        //monthly repayments
        private double _repayment;       

        /// <summary>
        /// Calculates the monthly loan repayment
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <param name="interestRate"></param>
        /// <param name="loanTerm"></param>
        /// <returns></returns>
        public double GetRepayment(double loanAmount, double interestRate, int loanTerm)
        {
            if (loanAmount < 0 || interestRate < 0 || loanTerm < 0)
            {
                throw new ArgumentOutOfRangeException("Entered value(s) must be greater than zero."); 
            }

            _loanAmount = loanAmount;
            //convert interest rate from percentage to decimal
            _interestRateDecimal = interestRate / 100;
            //convert loan term from years to months
            _loanTermMonths = loanTerm * 12;

            //monthly repayments calculation
            return _loanAmount / ((1.0 - (1.0 / Math.Pow((1 + (_interestRateDecimal / 12)), (_loanTermMonths)))) / (_interestRateDecimal / 12));
        }

        /// <summary>
        /// Calcualtes the present value of the loan
        /// </summary>
        /// <param name="repayment"></param>
        /// <param name="interestRate"></param>
        /// <param name="loanTerm"></param>
        /// <returns></returns>
        public double GetPresentValue(double repayment, double interestRate, int loanTerm)
        {

            if (repayment < 0 || interestRate < 0 || loanTerm < 0)
            {
                throw new ArgumentOutOfRangeException("Error: Entered value(s) must be greater than zero."); 
            }

            _repayment = repayment;
            //convert interest rate from percentage to decimal
            _interestRateDecimal = interestRate / 100;
            //convert loan term from years to months
            _loanTermMonths = loanTerm * 12;              

            //Present Value calculation
            return _repayment * (1 - Math.Pow((1 + (_interestRateDecimal / 12)), (-1 * _loanTermMonths))) / (_interestRateDecimal / 12);
        }

    }
}
