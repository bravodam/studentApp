using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Guarantors
{
    public class Guarantor
    {
        public int ID { get; set; }
        public int _student_id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public gender Gender { get; set; }
        public maritalStatus MaritalStatus { get; set; }
        public nationality Nationality { get; set; }
        public List<StudentGuarantor> ListStudentGuarantor { get; set; }
    }
}
