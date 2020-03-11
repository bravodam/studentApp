using Code360_Management.Models.Batchs;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students_In_Batch
{
    public class StudentInBatch
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public Student student { get; set; }
        public studentStatus Student_Status { get; set; }
        public grade Grade { get; set; }
        public int Batch_Id { get; set; }
        public Batch Batch { get; set; }
    }
}
