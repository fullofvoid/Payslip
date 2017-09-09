using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayslipApp.Service.Test
{
    [TestClass]
    public class TaxCalculaterShould
    {
        [TestMethod]
        public void CalculateIncomeTaxSuccessfully()
        {
            TaxCalculater calculater = new TaxCalculater();

            var result = calculater.CalculateIncomeTax(60050);
            Assert.IsTrue(result == 11063.25M);

            result = calculater.CalculateIncomeTax(120000);
            Assert.IsTrue(result == 32347M);
        }
    }
}
