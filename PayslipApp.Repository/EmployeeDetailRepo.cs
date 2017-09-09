using CsvHelper;
using PayslipApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PayslipApp.Repository
{
    public class EmployeeDetailRepo: IEmployeeDetailRepo
    {
        private string _inputFileName;

        public EmployeeDetailRepo(string inputFileName)
        {
            _inputFileName = inputFileName;
        }

        public IEnumerable<EmployeeDetailModel> ReadAllEmployeeDetails()
        {
            var csv = new CsvReader(File.OpenText(_inputFileName));
            csv.Configuration.RegisterClassMap(new EmployeeDetailModelMap());
            var records = csv.GetRecords<EmployeeDetailModel>();
            return records;
        }
    }
}
