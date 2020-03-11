using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public class MockStudents : IStudents
    {
        private List<Student> _studentsList;

        public MockStudents()
        {
            _studentsList = new List<Student>();            
        }
        public Student AddStudent(Student student)
        {
            student.ID = _studentsList.Max(e => e.ID) + 1;
            _studentsList.Add(student);
            return student;
        }

        public Student DeleteStudent(int id)
        {
            Student students = _studentsList.FirstOrDefault(e => e.ID == id);
            if (students != null)
            {
                _studentsList.Remove(students);
            }
            return students;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _studentsList;
        }

        public Student GetStudent(int id)
        {
            return _studentsList.FirstOrDefault(e => e.ID == id);
        }

        public Student UpdateStudent(Student studentChanges)
        {
            Student students = _studentsList.FirstOrDefault(e => e.ID == studentChanges.ID);
            if (students != null)
            {
                students.FirstName = studentChanges.FirstName;
                students.LastName = studentChanges.LastName;
                students.Nationality = studentChanges.Nationality;
                students.MaritalStatus = studentChanges.MaritalStatus;
                students.Phone = studentChanges.Phone;
            }
            return students;
        }
    }
}
