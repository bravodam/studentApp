using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Courses
{
    public class SQLCourseRepo : ICourse
    {
        private readonly AppDbContext dbContext;

        public SQLCourseRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Course AddCourse(Course Course)
        {
            dbContext.Courses.Add(Course);
            dbContext.SaveChanges();
            return Course;
        }

        public Course DeleteCourse(int id)
        {
            Course cur = dbContext.Courses.Find(id);
            if (cur != null)
            {
                dbContext.Courses.Remove(cur);
                dbContext.SaveChanges();
            }
            return cur;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return dbContext.Courses;
        }

        public Course GetCourse(int id)
        {
            return dbContext.Courses.Find(id);
        }

        public Course UpdateCourse(Course CourseChanges)
        {
            var cur = dbContext.Courses.Attach(CourseChanges);
            cur.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return CourseChanges;
        }
    }
}
