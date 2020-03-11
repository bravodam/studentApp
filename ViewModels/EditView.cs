using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels
{
    public class EditView
    {
        //public Student studentEdit { get; set; }
        //public string pagetitle { get; set; }
        public int Id { get; set; }
        //public string Name { get; set; }
        public string Email { get; set; }
        public addmissionType AddmissionType { get; set; }
        public string Address { get; set; }
        public maritalStatus MaritalStatus { get;  set; }
        public nationality Nationality { get;  set; }
        public long NextOfKinPhone { get;  set; }
        public string NextOfKinEmail { get;  set; }
        public string NextOfKinName { get;  set; }
        public long Phone { get;  set; }
        public gender Gender { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}
