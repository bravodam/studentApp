using Code360_Management.Models.Batchs;
using Code360_Management.Models.Employment;
using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Payments;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Students_In_Batch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public gender Gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public nationality Nationality { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Marital Status")]
        public maritalStatus MaritalStatus { get; set; }

        [Display(Name = "Addmission Type")]
        public addmissionType AddmissionType { get; set; }

        [Display(Name = "Next of Kin Name")]
        public string NextOfKinName { get; set; }

        [Display(Name = "Next of Kin Email")]
        public string NextOfKinEmail { get; set; }

        [Display(Name = "Next of Kin Phone")]
        public long NextOfKinPhone { get; set; }

        [Display(Name = "Next of Kin Document url")]
        public string NextOfKinDocumentUrl { get; set; }
        public long BVN { get; set; }

        public List<StudentInBatch> ListOfstudentInBatches { get; set; }
        public List<Guarantor> guarantors { get; set; }
        public List<Project> listOfProjects { get; set; }
        public List<StudentCourse> ListstudentCourses { get; set; }
        public List<StudentGuarantor> ListStudentGuarantor { get; set; }

        public List<Payment> ListOfPayment { get; set; }
        public List<EmploymentHistory> ListOfEmpHistory { get; set; }
    }
}
