using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipApp.Repository;
using Moq;
using System.Linq;
using PayslipApp.Repository.Model;
using PayslipApp.ViewModel;

namespace PayslipApp.Service.Test
{
    [TestClass]
    public class PayslipServiceShould
    {
        private static EmployeeDetailModel inputEmployee1 = null;
        private static EmployeeDetailModel inputEmployee2 = null;
        private static PayslipInfoViewModel payslip2 = null;


        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            inputEmployee1 = new EmployeeDetailModel() { FirstName= "David", LastName= "Rudd", AnnualSalary= 60050, SuperRate=9, Payperiod = "01 March – 31 March" };
            inputEmployee2 = new EmployeeDetailModel() { FirstName= "Ryan", LastName= "Chen", AnnualSalary= 120000, SuperRate=10, Payperiod = "01 March – 31 March" };
            payslip2 = new PayslipInfoViewModel()
            {
                Name = "Ryan Chen",
                Payperiod = inputEmployee2.Payperiod,
                GrossIncome = 10000,
                IncomeTax = 2696,
                NetIncome = 7304,
                Super = 1000
            };
        }

        [TestMethod]
        public void GeneratePayslipSuccesfully()
        {
            var repo = new Mock<IEmployeeDetailRepo>();
            repo.Setup(x => x.ReadAllEmployeeDetails()).Returns(new EmployeeDetailModel[] {inputEmployee1,inputEmployee2 });
            var taxCalculater = new Mock<ITaxCalculater>();
            taxCalculater.Setup(x=>x.CalculateIncomeTax(inputEmployee2.AnnualSalary)).Returns(payslip2.IncomeTax * PayslipService.NumberOfMonthInYear);

            var service = new PayslipService(repo.Object, taxCalculater.Object);
            var payslips = service.GeneratePayslips();
            var payslipsArray = payslips.ToArray();
            Assert.IsTrue(payslipsArray.Length == 2
                && payslipsArray[1].Name == payslip2.Name
                && payslipsArray[1].Payperiod == payslip2.Payperiod
                && payslipsArray[1].GrossIncome == payslip2.GrossIncome
                && payslipsArray[1].IncomeTax == payslip2.IncomeTax
                && payslipsArray[1].NetIncome == payslip2.NetIncome
                && payslipsArray[1].Super == payslip2.Super);
        }
    }
}
