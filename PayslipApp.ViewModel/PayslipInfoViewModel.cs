using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.ViewModel
{
    public class PayslipInfoViewModel
    {
        public string Name { get; set; }
        public string Payperiod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
    }
}
