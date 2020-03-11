using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Programs
{
    public class SQLProgramCourseRepo : IProgramCourses
    {
        private readonly AppDbContext db;

        public SQLProgramCourseRepo(AppDbContext db)
        {
            this.db = db;
        }

        public ProgramCourse AddProgramCourse(ProgramCourse Program_Course)
        {
            db.programCourses.Add(Program_Course);
            db.SaveChanges();
            return Program_Course;
        }

        public ProgramCourse DeleteProgramCourse(int id)
        {
            ProgramCourse pc = db.programCourses.Find(id);
            if (pc != null)
            {
                db.programCourses.Remove(pc);
                db.SaveChanges();
            }
            return pc;
        }

        public IEnumerable<ProgramCourse> GetAllProgramCourses()
        {
            return db.programCourses;
        }

        public ProgramCourse GetProgramCourse(int id)
        {
            return db.programCourses.Find(id);
        }

        public ProgramCourse UpdateProgramCourse(ProgramCourse Program_CourseChanges)
        {
            var pc = db.programCourses.Attach(Program_CourseChanges);
            pc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Program_CourseChanges;
        }
    }
}
