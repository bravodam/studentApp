using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Employment
{
    public interface ICompany
    {
        Company AddCompany(Company company);
        Company DeleteCompany(int id);
        Company GetCompany(int id);
        IEnumerable<Company> GetAllCompany();
        Company UpdateCompany(Company companyChanges);

        EmploymentHistory AddEmploymentHistory(EmploymentHistory empHistory);
        EmploymentHistory DeleteEmploymentHistory(int id);
        EmploymentHistory GetEmploymentHistory(int id);
        IEnumerable<EmploymentHistory> GetAllEmploymentHistory();
        EmploymentHistory UpdateEmploymentHistory(EmploymentHistory empHistory);

        Salary AddSalary(Salary salary);
        Salary UpdateSalary(Salary salaryChangesa);
        Salary GetSalary(int id);
        IEnumerable<Salary> GetAllSalarys();
        Salary DeleteSalary(int id);
    }
}
