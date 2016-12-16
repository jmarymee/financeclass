using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceClass;

namespace FinanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentCalculator calculator = new PaymentCalculator();
            calculator.PurchasePrice = 50000;
            calculator.InterestRate = 6.0;
            calculator.LoanTermYears = 5;
            for (int i = 0; i <= 10000; i += 1000)
            {
                calculator.DownPayment = i;
                DisplayLoanInformation(calculator);
            }

            Console.WriteLine("Press any to end");
            Console.ReadLine();

        }

        static void DisplayLoanInformation(PaymentCalculator calculator)
        {
            Console.WriteLine("Purchase Price: {0:C}", calculator.PurchasePrice);
            Console.WriteLine("Down Payment: {0:C}", calculator.DownPayment);
            Console.WriteLine("Loan Amount: {0:C}", calculator.LoanAmount);
            Console.WriteLine("Annual Interest Rate: {0}%", calculator.InterestRate);
            Console.WriteLine("Term: {0} years ({1} months)", calculator.LoanTermYears, calculator.LoanTermMonths);
            Console.WriteLine("Monthly Payment: {0:C}", calculator.CalculatePayment());
            Console.WriteLine();
        }
    }
}
