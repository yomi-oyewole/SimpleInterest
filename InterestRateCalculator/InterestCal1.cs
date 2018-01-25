using System;

namespace InterestRateCalculator
{
    class InterestCal1
    {
        double Balance;
        double AnnualInterest;
        double MonthlyRate;


        static void Main(string[] args)
        {
            Console.Write("Please enter credit amount: ");
            string CreditAmount = Console.ReadLine();
            Console.Write("Please enter Annual rate: ");
            string AnnualRate = Console.ReadLine();
            Console.Write("Please enter Monthly rate: ");
            string MonthlyRate = Console.ReadLine();
            try
            {
                InterestCal1 intt = new InterestCal1(Convert.ToDouble(CreditAmount), Convert.ToDouble(AnnualRate), Convert.ToDouble(MonthlyRate));
                intt.InterestCal();
            }
            catch(FormatException e)
            {
                Console.WriteLine("\n\nPlease enter valid input \nOnly Digits are allowed No Special characters or Alphabets.");
                Console.ReadLine();
            }
            
           
        }

        public InterestCal1(double Balance, double AnnualInterest, double MonthlyRate)
        {
            AnnualInterest = (AnnualInterest / 100);
            this.Balance = Balance;
            this.AnnualInterest = (AnnualInterest / 12);

            this.MonthlyRate = (MonthlyRate / 100);
        }

        void InterestCal()
        {
            double MinimumMonthPay;
            double InterestPaid;
            double PrincipalPaid;
            double TotalAmount = 0;
            //double RemaningBalance;
            int month = 1;

            while (month <= 12)
            {
                MinimumMonthPay = Math.Round((MonthlyRate * Balance), 2);
                TotalAmount += MinimumMonthPay;
                InterestPaid = Math.Round((AnnualInterest * Balance), 2);
                PrincipalPaid = Math.Round((MinimumMonthPay - InterestPaid), 2);
                Balance -= PrincipalPaid;

                if (Balance <= 0)
                {
                    break;
                }

                Console.WriteLine("\nMounths: " + month);
                Console.WriteLine("Minimum monthly payment is: " + MinimumMonthPay);
                Console.WriteLine("Principal Paid is: " + PrincipalPaid);
                Console.WriteLine("Remaining balance is: " + Balance);

                month++;
            }
            Console.WriteLine("\n\nRESULT:");
            Console.WriteLine("Total Amount paid is : " + TotalAmount);
            Console.WriteLine("Remaining Balance: " + Balance);
            Console.Read();

        }
    }

}
