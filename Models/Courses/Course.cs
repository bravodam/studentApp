using Code360_Management.Models.Programs;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Courses
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display()]
        public courseName Course_Name { get; set; }
        public courseLevel Level { get; set; }
        public double Cost { get; set; }
        public int Program_Id { get; set; }
        public List<StudentCourse> ListstudentCourses { get; set; }

        public List<ProgramCourse> ListProgramCourses { get; set; }
    }
}
