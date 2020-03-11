using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.ProgramCourse
{
    public class ProgramViewModel
    {
        //public int studentId { get; set; }
        public int ID { get; set; }
        [Required]
        public programName ProgramName { get; set; }
        [Required]
        public programDuration duration { get; set; }
        //public batchName batch { get; set; }
        public double cost { get; set; }

        //public int courseID { get; set; }
        //[Display(Name = "Cost Type")]
        //public addmissionType cost_type { get; set; }
    }
}
