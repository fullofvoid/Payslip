using PayslipApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.Repository
{
    public class EmployeeDetailRepo
    {
        private string _inputFileName;

        public EmployeeDetailRepo(string inputFileName)
        {
            _inputFileName = inputFileName;
        }

        public IEnumerable<EmployeeDetailModel> ReadAllEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }
}
