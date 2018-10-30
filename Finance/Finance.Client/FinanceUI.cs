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

                    FinanceLib calculator = new FinanceLib();
                    double monthlyRepayment = calculator.GetRepayment(loanAmount, interestRate, loanTermInYears);

                    Console.WriteLine($"Monthly Repayments: ${Math.Round(monthlyRepayment,2)}");                   
                    Console.WriteLine();

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

                    FinanceLib calculator = new FinanceLib();
                    double presentValue = calculator.GetPresentValue(repayment, interestRate, loanTermInYears);

                    Console.WriteLine($"Present Value of the loan: ${Math.Round(presentValue, 2)}");
                    Console.WriteLine();

                }
            }
            while (choice != "3");

            Console.WriteLine("Exiting program...");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Choose an option from the menu below:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Calculate Monthly Loan Repayments");
            Console.WriteLine("2. Calculate Present Value of a Loan");
            Console.WriteLine("3. Exit");
        }
    }
    
}
