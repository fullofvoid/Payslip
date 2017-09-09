using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipApp.Repository;
using Moq;
using System.Linq;
using PayslipApp.Repository.Model;

namespace PayslipApp.Service.Test
{
    [TestClass]
    public class PayslipServiceShould
    {
        private static EmployeeDetailModel inputEmployee1 = null;
        private static EmployeeDetailModel inputEmployee2 = null;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            inputEmployee1 = new EmployeeDetailModel() { FirstName= "David", LastName= "Rudd", AnualSalary= 60050, SuperRate=9, Payperiod = "01 March – 31 March" };
            inputEmployee2 = new EmployeeDetailModel() { FirstName= "Ryan", LastName= "Chen", AnualSalary= 120000, SuperRate=10, Payperiod = "01 March – 31 March" };
            
        }
        [TestMethod]
        public void GeneratePayslipSuccesfully()
        {
            var repo = new Mock<EmployeeDetailRepo>();

            var service = new PayslipService(repo.Object);
            var payslips = service.GeneratePayslips();
            var payslipsArray = payslips.ToArray();
            Assert.IsTrue(payslipsArray.Length == 2
                && payslipsArray[1].Name == "Ryan Chen"
                && payslipsArray[1].Payperiod == inputEmployee2 .Payperiod
                && payslipsArray[1].GrossIncome == 10000
                && payslipsArray[1].IncomeTax == 2696
                && payslipsArray[1].NetIncome == 7304
                && payslipsArray[1].Super == 1000);
        }
    }
}
