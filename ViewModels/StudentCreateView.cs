using Code360_Management.Models.Students;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels
{
    public class StudentCreateView
    {
        //[Required]
        //public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public nationality Nationality { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
        public IFormFile Image { get; set; }
        public maritalStatus MaritalStatus { get; set; }
        public addmissionType AddmissionType { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinEmail { get; set; }
        public long NextOfKinPhone { get; set; }
        public string NextOfKinDocumentUrl { get; set; }
        public long BVN { get; set; }
    }
}
