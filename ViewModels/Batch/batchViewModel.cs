using Code360_Management.Models.Programs;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.Batch
{
    public class batchViewModel
    {
        public int Id { get; set; }
        public batchName BatchName { get; set; }
        public string selectedProgram { get; set; }

        [Display(Name = "Program Name")]
        public List<Programme> programName { get; set; }
        public string supervisor { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        public title Title { get; set; }

    }

    public enum title
    {
        Mr,
        Mrs,
        Miss,
        Barr,
        Dr,
        Prof,
        Engr,
        Master,
    }
}
