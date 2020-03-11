using Code360_Management.Models.Students;
using Code360_Management.Models.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Code360_Management.ViewModels.studentInBatch
{
    public class studentBatchViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Selected Batch")]
        public string selectedBatch { get; set; }
        public List<Code360_Management.Models.Batchs.Batch> batchList { get; set; }

        [Display(Name = "Selected Student")]
        public string selectedStudent { get; set; }
        public List<Student> studentList { get; set; }

        [Display(Name = "Student Status")]
        public studentStatus studentStaus { get; set; }

        [Display(Name = "Student Grade")]
        public grade studentGrade { get; set; }

        [Display(Name = "Program Type")]
        public programName programType { get; set; }
        public programDuration duration { get; set; }
    }
}
