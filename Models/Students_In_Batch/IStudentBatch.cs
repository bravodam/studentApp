using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students_In_Batch
{
    public interface IStudentBatch
    {
        StudentInBatch AddStudentInBatch(StudentInBatch studentBatch);
        StudentInBatch UpdateStudentInBatch(StudentInBatch studentBatchChanges);
        StudentInBatch GetStudentInBatch(int id);
        IEnumerable<StudentInBatch> GetAllStudentInBatchs();
        StudentInBatch DeleteStudentInBatch(int id);
    }
}
