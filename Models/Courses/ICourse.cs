using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Courses
{
    interface ICourse
    {
        Course AddCourse(Course Course);
        Course UpdateCourse(Course CourseChanges);
        Course GetCourse(int id);
        IEnumerable<Course> GetAllCourses();
        Course DeleteCourse(int id);
    }
}
