using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.Employment
{
    public class employmentViewModel
    {
        public int compy_id { get; set; }
        public string compy_name { get; set; }
        [Display(Name = "Contact Person")]
        public string contactPerson { get; set; }
        public string Address { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
         public int StudentId { get; set; }
        public List<Student> studentlist { get; set; }

        [Display(Name = "Selected student")]
        public string selectedStudent { get; set; }
    }
}
