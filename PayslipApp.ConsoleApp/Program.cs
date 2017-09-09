using PayslipApp.Repository;
using PayslipApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to payslip app. Please enter file name to process");
            var inputFileName = Console.ReadLine();
            if (File.Exists(inputFileName))
            {
                var service = new PayslipService(
                    new EmployeeDetailRepo(inputFileName), new TaxCalculater());
                var payslips = service.GeneratePayslips();
                PrintPayslips(payslips);
            }
            else
            {
                Console.WriteLine("Sorry file does not exist");
            }
            Console.WriteLine();
            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
        }

        private static void PrintPayslips(IEnumerable<ViewModel.PayslipInfoViewModel> payslips)
        {
            Console.WriteLine("Output(name, pay period, gross   income, income  tax, net income, super):");
            foreach (var payslip in payslips)
            {
                Console.WriteLine($"{payslip.Name}, {payslip.Payperiod}, {payslip.GrossIncome}"
                    +$", {payslip.IncomeTax}, {payslip.NetIncome}, {payslip.Super}");
            }
        }
    }
}
