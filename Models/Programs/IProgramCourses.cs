using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Programs
{
    interface IProgramCourses
    {
        ProgramCourse AddProgramCourse(ProgramCourse Program_Course);
        ProgramCourse UpdateProgramCourse(ProgramCourse Program_CourseChanges);
        ProgramCourse GetProgramCourse(int id);
        IEnumerable<ProgramCourse> GetAllProgramCourses();
        ProgramCourse DeleteProgramCourse(int id);
    }
}
