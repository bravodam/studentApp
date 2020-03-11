using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public projectStatus Project_Status { get; set; }
        public string ProjectUrl { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
