using Code360_Management.Models.Batchs;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Programs
{
    public class Programme
    {
        public int Id { get; set; }
        public programName Program_Name { get; set; }
        public programDuration Duration { get; set; }
        public double Cost { get; set; }
        public int Course_Id { get; set; }
        public int BatchId { get; set; }
        public batchName BatchName { get; set; }
        public List<Batch> BatchList { get; set; }
        public List<ProgramCourse> ListProgramCourses { get; set; }
        //public int studentID { get; set; }
    }
}
