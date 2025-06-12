# Finance Calculator

Demo program to calculate the monthly repayment of a loan and present value of a loan.

The UI is a .net core console app written in c#. This calls a class library that contains the calculations. A set of unit tests have also been written using xunit to the test the library's functionality.

## Building and running

This project targets **.NET 8.0**. To build all projects and run the unit tests use:

```bash
dotnet test Finance -v minimal
```

To run the console UI directly:

```bash
dotnet run --project Finance/Finance.Client
```
