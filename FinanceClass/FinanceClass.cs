using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceClass
{
    /// <summary>
    /// Class to calculate loan payments
    /// </summary>
    public class PaymentCalculator
    {
        private const int MonthsPerYear = 12;

        /// <summary>
        /// The total purchase price of the item being paid for.
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// The total down payment towards the item being purchased.
        /// </summary>
        public decimal DownPayment { get; set; }

        /// <summary>
        /// Gets the total loan amount. This is the purchase price less
        /// any down payment.
        /// </summary>
        public decimal LoanAmount
        {
            get { return (PurchasePrice - DownPayment); }
        }

        /// <summary>
        /// The annual interest rate to be charged on the loan
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// The term of the loan in months. This is the number of months
        /// that payments will be made.
        /// </summary>
        public double LoanTermMonths { get; set; }

        /// <summary>
        /// The term of the loan in years. This is the number of years
        /// that payments will be made.
        /// </summary>
        public double LoanTermYears
        {
            get { return LoanTermMonths / MonthsPerYear; }
            set { LoanTermMonths = (value * MonthsPerYear); }
        }

        /// <summary>
        /// Calculates the monthy payment amount based on current
        /// settings.
        /// </summary>
        /// <returns>Returns the monthly payment amount</returns>
        public decimal CalculatePayment()
        {
            decimal payment = 0;

            if (LoanTermMonths > 0)
            {
                if (InterestRate != 0)
                {
                    double rate = ((InterestRate / MonthsPerYear) / 100);
                    double factor = (rate + (rate / (Math.Pow(rate + 1, LoanTermMonths) - 1)));
                    payment = (LoanAmount * (decimal)factor);
                }
                else payment = (LoanAmount / (decimal)LoanTermMonths);
            }
            return Math.Round(payment, 2);
        }
    }

}
