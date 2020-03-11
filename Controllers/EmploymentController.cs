using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Batchs;
using Code360_Management.Models.Employment;
using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using Code360_Management.ViewModels.Employment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Employment")]
    public class EmploymentController : Controller
    {
        
        private readonly IStudents _student;
        private readonly IBatch _batchRepo;
        private readonly IProgram _programRepo;
        private readonly IProject _projectRepo;
        private readonly IGuarantor _guarantorRepo;
        private readonly IStudentBatch _studentBatchRepo;
        private readonly ICompany _employRepo;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IGuarantor guarantorRepo;

        public EmploymentController(IStudents studentRepo, IWebHostEnvironment webHostEnvironment, IGuarantor guarantorRepo, IProgram programRepo, IProject projectRepo, IBatch batchRepo, IStudentBatch studentBatchRepo, ICompany employRepo)
        {
            _student = studentRepo;
            _batchRepo = batchRepo;
            _programRepo = programRepo;
            _projectRepo = projectRepo;
            _guarantorRepo = guarantorRepo;
            _studentBatchRepo = studentBatchRepo;
            _employRepo = employRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.guarantorRepo = guarantorRepo;
        }

        [Route("View")]
        public IActionResult Index()
        {
            return View(_employRepo.GetAllCompany());
        }

        [Route("create")]
        [HttpGet]
        public ViewResult addCompany()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult addCompany(employmentViewModel employmentViewModel)
        {
            Company company = new Company()
            {
                CompName = employmentViewModel.compy_name,
                Address = employmentViewModel.Address,
                ContactPerson = employmentViewModel.contactPerson
            };
            _employRepo.AddCompany(company);
            return RedirectToAction("Index");
        }

        [Route("Remove/{id?}")]
        public IActionResult Delete(int id)
        {
            _employRepo.DeleteCompany(id);
            return RedirectToAction("index");
        }

        [Route("edit/{id?}")]
        [HttpGet]
        public ViewResult Update(int id)
        {
            Company company = _employRepo.GetCompany(id);
            employmentViewModel employmentView = new employmentViewModel()
            {
                compy_name = company.CompName,
                Address = company.Address,
                contactPerson = company.ContactPerson,
                compy_id = company.ID
            };
            return View(employmentView);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Update(employmentViewModel model)
        {
            Company company = _employRepo.GetCompany(model.compy_id);
            if (ModelState.IsValid)
            {
                company.CompName = model.compy_name;
                company.Address = model.Address;
                company.ContactPerson = model.contactPerson;
                _employRepo.UpdateCompany(company);
                return RedirectToAction("index");
            }
            return View();
        }

        [Route("companyStudent/{id?}")]
        [HttpGet]
        public ViewResult assignStudentCompany(int id)
        {
            List<Student> studentlist = _student.GetAllStudent().ToList();
            employmentViewModel employmentView = new employmentViewModel()
            {
                studentlist = studentlist,
                compy_id = id
            };
            return View(employmentView);
        }

        [Route("companyStudent/{id?}")]
        [HttpPost]
        public IActionResult assignStudentCompany(employmentViewModel model)
        {
            int studentId = int.Parse(model.selectedStudent);
            var studentcomp = _employRepo.GetAllEmploymentHistory().Where(sc => sc.CompID == model.compy_id && sc.ID == studentId).FirstOrDefault();

            if (studentcomp == null)
            {
                EmploymentHistory employment = new EmploymentHistory()
                {
                    CompID = model.compy_id,
                    StudentId = studentId,
                    StartDate = model.StartDate,
                    //EndDate = model.EndDate
                };
                _employRepo.AddEmploymentHistory(employment);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("duplicate", "Error in key vale");
                List<Student> studentlist = _student.GetAllStudent().ToList();
                employmentViewModel employmentView = new employmentViewModel()
                {
                    studentlist = studentlist
                };
                return View(employmentView);
            }
        }
    }
}
