using Code360_Management.Models.Students;
using Code360_Management.Models.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Guarantors;

namespace Code360_Management.ViewModels
{
    public class DashboardView
    {
        public Student student { get; set; }
        public Code360_Management.Models.Batchs.Batch batch { get; set; }
        public Programme program { get; set; }
        public List<Project> project { get; set; }
        public string pageTitle { get; set; }
        public List<Guarantor> guarantor { get; set; }
        public string error { get; internal set; }
    }
}
