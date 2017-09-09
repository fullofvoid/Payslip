using PayslipApp.Repository;
using PayslipApp.Repository.Model;
using PayslipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.Service
{
    public class PayslipService
    {
        public const int NumberOfMonthInYear = 12;
        private EmployeeDetailRepo _repo;

        public PayslipService(EmployeeDetailRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<PayslipInfoViewModel> GeneratePayslips()
        {
            IEnumerable<EmployeeDetailModel> employeeDetails = _repo.ReadAllEmployeeDetails();
            var payslips = new List<PayslipInfoViewModel>();
            foreach (var employeeDetail in employeeDetails)
            {
                payslips.Add(CalculatePayslip(employeeDetail));
            }
            return payslips;
        }

        private PayslipInfoViewModel CalculatePayslip(EmployeeDetailModel employeeDetail)
        {
            var payslip = new PayslipInfoViewModel();
            payslip.Name = $"{employeeDetail.FirstName} {employeeDetail.LastName}";
            payslip.Payperiod = employeeDetail.Payperiod;
            payslip.GrossIncome = Round(employeeDetail.AnualSalary/NumberOfMonthInYear);
            payslip.IncomeTax = Round(CalculateIncomeTax(employeeDetail.AnualSalary));
            payslip.NetIncome = payslip.GrossIncome - payslip.IncomeTax;
            payslip.Super = Round(payslip.GrossIncome*employeeDetail.SuperRate/100);
            return payslip;
        }

        private decimal CalculateIncomeTax(int anualSalary)
        {
            throw new NotImplementedException();
        }

        private int Round(decimal v)
        {

            int dollars = (int)v;
            decimal cents = (v - dollars) * 100;
            int roundDollar = (cents >= 50 ? 1 : 0);
            return dollars + roundDollar;
        }
    }
}
