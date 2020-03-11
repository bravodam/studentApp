using Code360_Management.Models.Courses;

namespace Code360_Management.Models.Programs
{
    public class ProgramCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public int ProgramID { get; set; }
        public Programme programme { get; set; }
    }
}