using Code360_Management.Models.Programs;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Batchs
{
    public class Batch
    {
        public int Id { get; set; }
        public batchName Name { get; set; }
        public int Program_Id { get; set; }
        public string Supervisor { get; set; }
        public string Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate  { get; set; }
        
        //reference of ER between Student and Batch
        public List<StudentInBatch> ListOfstudentInBatch { get; set; }
        public Programme programme { get; set; }
    }
}
