using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.ProjectModel
{
    public class projectViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Project name")]
        public string  projectname { get; set; }
        public projectStatus status { get; set; }
        public string url { get; set; }
    }
}
