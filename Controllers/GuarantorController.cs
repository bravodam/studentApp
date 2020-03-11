using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Students;
using Code360_Management.ViewModels.GuarantorModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Controllers
{
    [Route("Guarantor")]
    public class GuarantorController : Controller
    {
        private readonly IGuarantor _guarantor;

        public GuarantorController(IGuarantor guarantorRepo)
        {
            _guarantor = guarantorRepo;
        }

        [Route("ViewGuarantor")]
        public ViewResult Read()
        {
            return View(_guarantor.GetAllGuarantor());
        }
        
        [Route("studentGuarantor/{id?}")]
        public ViewResult StudentGuarantor(int id)
        {
            List<Guarantor> guarantors = _guarantor.StudentGuarantor(id).ToList();
            ViewStudentGuarantor studentGuarantor = new ViewStudentGuarantor()
            {
                listGuarantor = guarantors,
            };
            return View(studentGuarantor);
        }

        public ViewResult FullView(int id)
        {
            GuarantorView guarantorView = new GuarantorView()
            {
                guarantor = _guarantor.GetGuarantor(id),
                //pagetitle = "full view"
            };
            return View(guarantorView);
        }

        [Route("create/{id?}")]
        [HttpGet]
        public ViewResult create(int id)
        {
            GuarantorView guarantorView = new GuarantorView()
            {
                studentID = id //_studentRepo.GetStudent(id)
            };
            return View(guarantorView);
        }

        [Route("create/{id?}")]
        [HttpPost]
        public IActionResult create(GuarantorView model)
        {
            if (ModelState.IsValid)
            {
                Guarantor guarantor1 = new Guarantor()
                {
                    //ID = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Email = model.Email,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    _student_id = model.studentID,
                    MaritalStatus = model.MaritalStatus,
                    Nationality = model.Nationality
                };
                _guarantor.AddGuarantor(guarantor1);
                return RedirectToAction("create");
            }
            return View();
        }

        [Route("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
           var gua =  _guarantor.DeleteGuarantor(id);
            return RedirectToAction("ViewStudent", "Home", new { id = gua._student_id});
        }

        [Route("Update/{id?}")]
        [HttpGet]
        public ViewResult Update(int id)
        {
            Guarantor guarantor = _guarantor.GetGuarantor(id);
            UpdateView updateView = new UpdateView()
            {
                Id = guarantor.ID,
                FirstName = guarantor.FirstName,
                LastName = guarantor.LastName,
                Email = guarantor.Email,
                Phone = guarantor.Phone,
                Address = guarantor.Address,
                Nationality = guarantor.Nationality,
                Gender = guarantor.Gender,
                MaritalStatus = guarantor.MaritalStatus
            };
            return View(updateView);
        }

        [Route("Update/{id?}")]
        [HttpPost]
        public IActionResult Update(UpdateView updateView)
        {
            Guarantor guarantor = _guarantor.GetGuarantor(updateView.Id);
            if(ModelState.IsValid)
            {
                guarantor.FirstName = updateView.FirstName;
                guarantor.LastName = updateView.LastName;
                guarantor.Email = updateView.Email;
                guarantor.Phone = updateView.Phone;
                guarantor.Address = updateView.Address;
                guarantor.Nationality = updateView.Nationality;
                guarantor.Gender = updateView.Gender;
                guarantor.MaritalStatus = updateView.MaritalStatus;

                _guarantor.UpdateGuarantor(guarantor);
                return RedirectToAction("Viewstudent", "Home", new { id = guarantor._student_id});
            }
            return View();
        }
    }
}
