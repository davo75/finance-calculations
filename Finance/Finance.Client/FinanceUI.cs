using Finance.Library;
using System;
using Newtonsoft.Json;
using System.IO;

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
                        Console.WriteLine("Enter the loan amount in dollars (e.g. 10000):");
                    } while (!Double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0);

                    double interestRate;
                    do
                    {
                        Console.WriteLine("Enter interest rate as a percentage (e.g. 5.2):");
                    } while (!Double.TryParse(Console.ReadLine(), out interestRate) || interestRate <= 0);

                    int loanTermInYears;
                    do
                    {
                        Console.WriteLine("Enter the term of the loan in years (e.g. 5):");
                    } while (!Int32.TryParse(Console.ReadLine(), out loanTermInYears) || loanTermInYears <= 0);

                    //create new calculator object to call repayment method
                    //Note: This could also be made into a static class if little domain logic is required
                    FinanceLib calculator = new FinanceLib();

                    try
                    {
                        double monthlyRepayment = calculator.GetRepayment(loanAmount, interestRate, loanTermInYears);
                        Console.WriteLine($"Monthly Repayments: ${Math.Round(monthlyRepayment,2)}");                   
                        Console.WriteLine();

                        //Append details of loan calculation to loans.txt file
                        //This file is in the bin folder so will be removed if a clean of the project is performed. For a real system this data 
                        //would be persisted in a proper data store
                        using (StreamWriter writer = new StreamWriter("loans.txt", true))
                        { 
                            writer.WriteLine(calculator);
                        }

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
                        Console.WriteLine("Enter the monthly repayment amount in dollars (e.g. 250):");
                    } while (!Double.TryParse(Console.ReadLine(), out repayment) || repayment <= 0);

                    double interestRate;
                    do
                    {
                        Console.WriteLine("Enter interest rate as a percentage (e.g. 5.2):");
                    } while (!Double.TryParse(Console.ReadLine(), out interestRate) || interestRate <= 0);

                    int loanTermInYears;
                    do
                    {
                        Console.WriteLine("Enter the term of the loan in years (e.g. 5):");
                    } while (!Int32.TryParse(Console.ReadLine(), out loanTermInYears) || loanTermInYears <= 0);

                    //create new calculator object to call repayment method
                    //Note: This could also be made into a static class if little domain logic is required 
                    FinanceLib calculator = new FinanceLib();

                    try
                    {
                        double presentValue = calculator.GetPresentValue(repayment, interestRate, loanTermInYears);
                        Console.WriteLine($"Present Value of the loan: ${Math.Round(presentValue, 2)}");
                        Console.WriteLine();

                        //Append details of loan calculation to loans.txt file
                        //This file is in the bin folder so will be removed if a clean of the project is performed. For a real system this data 
                        //would be persisted in a proper data store
                        using (StreamWriter writer = new StreamWriter("loans.txt", true))
                        { 
                            writer.WriteLine(calculator);
                        }
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
                    try
                    {   // Open the text file using a stream reader.
                        using (StreamReader sr = new StreamReader("loans.txt"))
                        {
                            // Read the stream to a string, and write the string to the console.
                            String line = sr.ReadToEnd();
                            Console.WriteLine(line);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }
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
            Console.WriteLine("");
            Console.WriteLine("=====================================");
            Console.WriteLine("Choose an option from the menu below:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Calculate Monthly Loan Repayments");
            Console.WriteLine("2. Calculate Present Value of a Loan");
            Console.WriteLine("3. View Saved Loan Calculation Results");
            Console.WriteLine("4. Exit");
        }
    }
    
}
