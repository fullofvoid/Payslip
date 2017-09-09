using PayslipApp.Repository.Model;
using System.Collections.Generic;

namespace PayslipApp.Repository
{
    public interface IEmployeeDetailRepo
    {
        IEnumerable<EmployeeDetailModel> ReadAllEmployeeDetails();
    }
}