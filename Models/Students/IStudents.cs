using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public interface IStudents
    {
        Student AddStudent(Student student);
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudent();
        Student DeleteStudent(int id);
        Student UpdateStudent(Student studentChanges);
    }
}
