using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.GuarantorModel
{
    public class GuarantorView
    {
        public Guarantor guarantor { get; set; }
        public int Id { get; set; }
        public int studentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public gender Gender { get; set; }
        public maritalStatus MaritalStatus { get; set; }
        public nationality Nationality { get; set; }
    }
    public class ViewStudentGuarantor
    {
        public List<Guarantor> listGuarantor { get; set; }
    }
}
