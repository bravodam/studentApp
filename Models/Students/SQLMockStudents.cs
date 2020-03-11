using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public class SQLMockStudents : IStudents
    {
        private readonly AppDbContext context;

        public SQLMockStudents(AppDbContext context)
        {
            this.context = context;
        }
        public Students.Student AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Students.Student DeleteStudent(int id)
        {
            Student stu = context.Students.Find(id);
            if (stu != null)
            {
                context.Students.Remove(stu);
                context.SaveChanges();
            }
            return stu;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return context.Students;
        }

        public Students.Student GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public Students.Student UpdateStudent(Students.Student studentChanges)
        {
            var stu = context.Students.Attach(studentChanges);
            stu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}