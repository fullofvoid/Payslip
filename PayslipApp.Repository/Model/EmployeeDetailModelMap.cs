using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.Repository.Model
{
    public sealed class EmployeeDetailModelMap : CsvClassMap<EmployeeDetailModel>
    {
        public EmployeeDetailModelMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.AnnualSalary).Name("Annual Salary");
            Map(m => m.SuperRate).Name("Super Rate");
            Map(m => m.Payperiod).Name("Pay Period");
        }
    }

}
