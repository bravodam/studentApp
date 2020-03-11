using Code360_Management.Models.Batchs;
using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using Code360_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IStudents _student;
        private readonly IBatch _batchRepo;
        private readonly IProgram _programRepo;
        private readonly IProject _projectRepo;
        private readonly IGuarantor _guarantorRepo;
        private readonly IStudentBatch _studentBatchRepo;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IGuarantor guarantorRepo;

        public HomeController(IStudents studentRepo, IWebHostEnvironment webHostEnvironment, IGuarantor guarantorRepo, IProgram programRepo, IProject projectRepo, IBatch batchRepo, IStudentBatch studentBatchRepo)
        {
            _student = studentRepo;
            _batchRepo = batchRepo;
            _programRepo = programRepo;
            _projectRepo = projectRepo;
            _guarantorRepo = guarantorRepo;
            _studentBatchRepo = studentBatchRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.guarantorRepo = guarantorRepo;
        }
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        [AllowAnonymous]

        public ViewResult Index()
        {
            //view login page
            return View();
        }
        //[Route("~/Home")]
        [Route("Dashboard")]
        public ViewResult Dashboard()
        {
            var model = _student.GetAllStudent();
            return View(model);
        }

        [Route("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            _student.DeleteStudent(id);
            return RedirectToAction("dashboard");
        }

        [Route("createStudent")]
        [HttpGet]
        public ViewResult createStudent()
        {
            return View();
        }

        [Route("createStudent")]
        [HttpPost]
        public IActionResult createStudent(StudentCreateView model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Student newStudent = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Gender = model.Gender,
                    Address = model.Address,
                    BVN = model.BVN,
                    AddmissionType = model.AddmissionType,
                    NextOfKinDocumentUrl = model.NextOfKinDocumentUrl,
                    NextOfKinEmail = model.NextOfKinEmail,
                    NextOfKinName = model.NextOfKinName,
                    NextOfKinPhone = model.NextOfKinPhone,
                    MaritalStatus = model.MaritalStatus,
                    Nationality = model.Nationality,
                    ImagePath = uniqueFileName,
                    Phone = model.Phone,
                    DateOfBirth = model.DateOfBirth,
                };
                Student stu = _student.AddStudent(newStudent);
                return RedirectToAction("create", "Guarantor", new { id = stu.ID});
                //return RedirectToAction("dashboard");
            }
            return View();
        }

        [Route("ViewStudent/{id?}")]
        public ViewResult ViewStudent(int id)
        {
            Student stu = _student.GetStudent(id); //fetch the student object

            List<Guarantor> guarantor = _guarantorRepo.GetAllGuarantor().Where(g => g._student_id == stu.ID).ToList();

            List<Project> project = _projectRepo.GetAllProjects().Where(p => p.StudentId == stu.ID).ToList();

            StudentInBatch studentInBatch = _studentBatchRepo.GetAllStudentInBatchs().Where(s => s.Student_Id == stu.ID).FirstOrDefault();
            if (studentInBatch != null)
            {
                Batch batch = _batchRepo.GetAllBatch().Where(b => b.Id == studentInBatch.Batch_Id).FirstOrDefault(); // pass the batch id to the GetBatch method to fetch an object of the batch

                Programme program = _programRepo.GetAllProgrammes().Where(p => p.Id == batch.Program_Id).FirstOrDefault();

                if (studentInBatch != null || batch != null || program != null || guarantor != null || project != null)
                {
                    DashboardView dashboardView1 = new DashboardView()
                    {
                        student = stu,
                        batch = batch,
                        project = project,
                        program = program,
                        guarantor = guarantor,
                        pageTitle = "Student View"
                    };
                    return View(dashboardView1);
                }
                else
                {
                    DashboardView dashboardView = new DashboardView()
                    {
                        student = stu,
                        error = "This Information is not Avialable at the Moment",
                        pageTitle = "Student View"
                    };
                    return View(dashboardView);
                }
            }
            else
            {
                DashboardView dashboardView = new DashboardView()
                {
                    student = stu,
                    error = "This Information is not Avialable at the Moment",
                    pageTitle = "Student View"
                };
                return View(dashboardView);
            }

            
        }
        
        [Route("EditStudent/{id?}")]
        [HttpGet]
        public ViewResult EditStudent(int id)
        {
            Student student = _student.GetStudent(id);
            EditView editView = new EditView()
            {
                //studentEdit = _student.GetStudent(id),
                //pagetitle = "Student Edit"
                Id = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                AddmissionType = student.AddmissionType,
                Address = student.Address,
                Gender = student.Gender,
                Phone = student.Phone,
                NextOfKinName = student.NextOfKinName,
                NextOfKinEmail = student.NextOfKinEmail,
                NextOfKinPhone = student.NextOfKinPhone,
                Nationality = student.Nationality,
                MaritalStatus = student.MaritalStatus

            };
            return View(editView);
        }

        [Route("EditStudent/{id?}")]
        [HttpPost]
        public IActionResult EditStudent(EditView student)
        {
            Student stu = _student.GetStudent(student.Id);

            if (ModelState.IsValid)
            {
                //stu.Name = student.Name;
                stu.FirstName = student.FirstName;
                stu.LastName = student.LastName;
                stu.Email = student.Email;
                stu.AddmissionType = student.AddmissionType;
                stu.Address = student.Address;
                stu.Gender = student.Gender;
                stu.Phone = student.Phone;
                stu.NextOfKinName = student.NextOfKinName;
                stu.NextOfKinEmail = student.NextOfKinEmail;
                stu.NextOfKinPhone = student.NextOfKinPhone;
                stu.Nationality = student.Nationality;
                stu.MaritalStatus = student.MaritalStatus;
            
                _student.UpdateStudent(stu);
                return RedirectToAction("viewstudent", "Home", new { id = stu.ID});
            }
            return View();
        }
    }
}
