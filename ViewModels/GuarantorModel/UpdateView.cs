using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.GuarantorModel
{
    public class UpdateView
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public nationality Nationality { get; set; }
        public gender Gender { get; set; }
        public maritalStatus MaritalStatus { get; set; }
        public int Id { get; set; }
        public string LastName { get;  set; }
        public string FirstName { get;  set; }
    }
}
