using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students_In_Batch
{
    public class SQLStudentBatchRepo : IStudentBatch
    {
        private readonly AppDbContext db;

        public SQLStudentBatchRepo(AppDbContext db)
        {
            this.db = db;
        }

        public StudentInBatch AddStudentInBatch(StudentInBatch studentBatch)
        {
            db.student_in_batch.Add(studentBatch);
            db.SaveChanges();
            return studentBatch;
        }

        public StudentInBatch DeleteStudentInBatch(int id)
        {
            StudentInBatch inBatch = db.student_in_batch.Find(id);
            if (inBatch != null)
            {
                db.student_in_batch.Remove(inBatch);
                db.SaveChanges();
            }
            return inBatch;
        }

        public IEnumerable<StudentInBatch> GetAllStudentInBatchs()
        {
            return db.student_in_batch;
        }

        public StudentInBatch GetStudentInBatch(int id)
        {
            return db.student_in_batch.Find(id);
        }

        public StudentInBatch UpdateStudentInBatch(StudentInBatch studentBatchChanges)
        {
            var studBatch = db.student_in_batch.Attach(studentBatchChanges);
            studBatch.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return studentBatchChanges;
        }
    }
}
