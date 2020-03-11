using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Employment
{
    public class Company
    {
        public int ID { get; set; }
        public string CompName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public List<EmploymentHistory> listOfEmpHistory { get; set; }
    }

    public class EmploymentHistory
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompID { get; set; }
        public Company company { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
        public List<Salary> ListOfSalaries { get; set; }
    }

    public class Salary
    {
        public int ID { get; set; }
        public Role role { get; set; }
        public double salary { get; set; }
        public DateTime ExpectedPayDay { get; set; }
        public int EmploymentHistory_ID { get; set; }
        public EmploymentHistory employmentHistory { get; set; }
    }

    public enum Role
    {
        Junior_Developer,
        Intermediate,
        Senior_Developer
    }
}
