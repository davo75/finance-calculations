using Finance.Library;
using System;

namespace Finance.Client
{
    /// <summary>
    /// Main UI for Finance App that calculates the monthly repayments for a loan and a loans present value
    /// </summary>
    class FinanceUI
    {
        static void Main(string[] args)
        {
            string choice = "";

            do
            {
                //Get menu choice
                ShowMenu();
                choice = Console.ReadLine();

                //calculate monthly repayment
                if (choice == "1")
                {
                    double loanAmount;
                    do
                    {
                        Console.WriteLine("Enter the loan amount:");
                    } while (!Double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0);

                    double interestRate;
                    do
                    {
                        Console.WriteLine("Enter interest rate (%):");
                    } while (!Double.TryParse(Console.ReadLine(), out interestRate) || interestRate <= 0);

                    int loanTermInYears;
                    do
                    {
                        Console.WriteLine("Enter the term of the loan in years:");
                    } while (!Int32.TryParse(Console.ReadLine(), out loanTermInYears) || loanTermInYears <= 0);

                    //create new calculator object to call repayment method
                    //Note: This could also be made into a static class if little domain logic is required
                    FinanceLib calculator = new FinanceLib();

                    try
                    {
                        double monthlyRepayment = calculator.GetRepayment(loanAmount, interestRate, loanTermInYears);
                        Console.WriteLine($"Monthly Repayments: ${Math.Round(monthlyRepayment,2)}");                   
                        Console.WriteLine();
                    }
                    //probably never hit as UI does some valdiation
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                }
                //Present Value calculation
                else if (choice == "2")
                {
                    double repayment;

                    //get input and validate
                    do
                    {
                        Console.WriteLine("Enter the monthly repayment amount:");
                    } while (!Double.TryParse(Console.ReadLine(), out repayment) || repayment <= 0);

                    double interestRate;
                    do
                    {
                        Console.WriteLine("Enter interest rate (%):");
                    } while (!Double.TryParse(Console.ReadLine(), out interestRate) || interestRate <= 0);

                    int loanTermInYears;
                    do
                    {
                        Console.WriteLine("Enter the term of the loan in years:");
                    } while (!Int32.TryParse(Console.ReadLine(), out loanTermInYears) || loanTermInYears <= 0);

                    //create new calculator object to call repayment method
                    //Note: This could also be made into a static class if little domain logic is required 
                    FinanceLib calculator = new FinanceLib();

                    try
                    {
                        double presentValue = calculator.GetPresentValue(repayment, interestRate, loanTermInYears);
                        Console.WriteLine($"Present Value of the loan: ${Math.Round(presentValue, 2)}");
                        Console.WriteLine();
                    }
                    //probably never hit as UI does some valdiation
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                }
                //display calculations saved to file
                else if (choice == "3")
                {

                }
            }
            while (choice != "4");

            Console.WriteLine("Exiting program...");
        }

        /// <summary>
        /// Displays menu options for calculations
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("Choose an option from the menu below:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Calculate Monthly Loan Repayments");
            Console.WriteLine("2. Calculate Present Value of a Loan");
            Console.WriteLine("3. View Saved Loan Calculation Results");
            Console.WriteLine("4. Exit");
        }
    }
    
}
