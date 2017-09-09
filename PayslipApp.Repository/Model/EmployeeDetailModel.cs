using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.Repository.Model
{
    public class EmployeeDetailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnualSalary { get; set; }
        public decimal SuperRate { get; set; }
        public string Payperiod { get; set; }
    }
}
