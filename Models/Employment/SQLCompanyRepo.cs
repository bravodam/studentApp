using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Employment
{
    public class SQLCompanyRepo : ICompany
    {
        private readonly AppDbContext appDbContext;

        public SQLCompanyRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Company AddCompany(Company company)
        {
            appDbContext.compnay.Add(company);
            appDbContext.SaveChanges();
            return company;
        }

        public Company GetCompany(int id)
        {
            return appDbContext.compnay.Find(id);
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return appDbContext.compnay;
        }

        public Company DeleteCompany(int id)
        {
            Company company = appDbContext.compnay.Find(id);
            if (company != null)
            {
                appDbContext.compnay.Remove(company);
                appDbContext.SaveChanges();
            }
            return company;
        }
        public Company UpdateCompany(Company companyChanges)
        {
            var comp = appDbContext.compnay.Attach(companyChanges);
            comp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return companyChanges;
        }


        /*******************************************************************
         * IMPLEMENTING EMPLOYEEHISTORY INTERFACE
         * ********************************************************************/
        public EmploymentHistory AddEmploymentHistory(EmploymentHistory empHistory)
        {
            appDbContext.employmentHistories.Add(empHistory);
            appDbContext.SaveChanges();
            return empHistory;
        }
        public EmploymentHistory DeleteEmploymentHistory(int id)
        {
            EmploymentHistory employment = appDbContext.employmentHistories.Find(id);
            if (employment != null)
            {
                appDbContext.employmentHistories.Remove(employment);
                appDbContext.SaveChanges();
            }
            return employment;
        }        

        public IEnumerable<EmploymentHistory> GetAllEmploymentHistory()
        {
            return appDbContext.employmentHistories;
        }        

        public EmploymentHistory GetEmploymentHistory(int id)
        {
            return appDbContext.employmentHistories.Find(id);
        }

        public EmploymentHistory UpdateEmploymentHistory(EmploymentHistory empHistory)
        {
            var emp = appDbContext.employmentHistories.Attach(empHistory);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return empHistory;
        }


        /*****************************************************
         * IMPLEMENTING THE SALARY INTERFACE
         * ***********************************************/
        public Salary AddSalary(Salary salary)
        {
            appDbContext.salaries.Add(salary);
            appDbContext.SaveChanges();
            return salary;
        }

        public Salary UpdateSalary(Salary salaryChangesa)
        {
            var salary = appDbContext.salaries.Attach(salaryChangesa);
            salary.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return salaryChangesa;
        }

        public Salary GetSalary(int id)
        {
            return appDbContext.salaries.Find(id);
        }

        public IEnumerable<Salary> GetAllSalarys()
        {
            return appDbContext.salaries;
        }

        public Salary DeleteSalary(int id)
        {
            Salary salary = appDbContext.salaries.Find(id);
            if (salary != null)
            {
                appDbContext.SaveChanges();
                appDbContext.SaveChanges();
            }
            return salary;
        }
    }
}
