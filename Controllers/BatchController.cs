using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Batchs;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using Code360_Management.ViewModels.Batch;
using Code360_Management.ViewModels.studentInBatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Batch")]
    public class BatchController : Controller
    {
        private readonly IBatch _batchRepo;
        private readonly IStudentBatch _studentBatchRepo;
        private readonly IStudents _studentRepo;
        private readonly IProgram _program;

        public BatchController(IBatch batchRepo, IStudentBatch studentBatchRepo, IStudents studentRepo, IProgram program)
        {
            _batchRepo = batchRepo;
            _studentBatchRepo = studentBatchRepo;
            _studentRepo = studentRepo;
            _program = program;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View(_batchRepo.GetAllBatch());
        }

        [Route("AddBatch")]
        [HttpGet]
        public ViewResult create()
        {
            List<Programme> programlist = _program.GetAllProgrammes().ToList();
            batchViewModel batchView = new batchViewModel()
            {
                programName = programlist,
            };
            return View(batchView);
        }

        [Route("AddBatch")]
        [HttpPost]
        public IActionResult create(batchViewModel model)
        {
            if (ModelState.IsValid)
            {
                Batch batch = new Batch()
                {
                    Name = model.BatchName,
                    Supervisor = model.Title.ToString() + ". " + model.FirstName + " " + model.LastName,
                    StartDate = model.startDate.Date,
                    EndDate = model.endDate.Date,
                    Year = model.startDate.Year.ToString(),
                    Program_Id = int.Parse(model.selectedProgram),
                    //programme = model.programName.ToString(),
                };
                _batchRepo.AddBatch(batch);
            }
            return RedirectToAction("Index");
        }

        [Route("Delete/{id?}")]
        public IActionResult delete(int id)
        {
            _batchRepo.DeleteBatch(id);
            //_studentBatchRepo.DeleteStudentInBatch(id);
            return RedirectToAction("index");
        }

        [Route("updateBatch/{id?}")]
        [HttpGet]
        public ViewResult update(int id)
        {
            Batch batch = _batchRepo.GetBatch(id);
            batchViewModel batchView = new batchViewModel()
            {
                Id = batch.Id,
                supervisor = batch.Supervisor,
                startDate = batch.StartDate,
                endDate = batch.EndDate,
                BatchName = batch.Name
            };
            return View(batchView);
        }

        [Route("updateBatch/{id?}")]
        [HttpPost]
        public IActionResult update(batchViewModel model)
        {
            Batch batch = _batchRepo.GetBatch(model.Id);
            if (ModelState.IsValid)
            {
                batch.Supervisor = model.supervisor;
                batch.StartDate = model.startDate;
                batch.EndDate = model.endDate;
                batch.Name = model.BatchName;
                batch.Year = Convert.ToString(model.startDate.Year);

                _batchRepo.UpdateBatch(batch);
                return RedirectToAction("index");
            }
            return View();
        }

        [Route("studentBatchAdd/{id?}")]
        [HttpGet]
        public IActionResult addStudentBatch(int id)
        {
            List<Student> studentlist = _studentRepo.GetAllStudent().ToList();
            //List<Batch> batches = _batchRepo.GetAllBatch().ToList();
          
            studentBatchViewModel studentBatchViewModel = new studentBatchViewModel()
            {
                studentList = studentlist,
                //batchList = batches,
                Id = id
            };
            return View(studentBatchViewModel);
        }

        [Route("studentBatchAdd/{id?}")]
        [HttpPost]
        public IActionResult addStudentBatch(studentBatchViewModel model)
        {
            //get the batchID and the studentID from the model
            //int batchID = int.Parse(model.selectedBatch);
            int studentID = int.Parse(model.selectedStudent);
            //int bid = model.Id;

            if (ModelState.IsValid)
            {
                //check if there are duplicates
                var studentinbatch = _studentBatchRepo.GetAllStudentInBatchs().Where(c => c.Batch_Id == model.Id && c.Student_Id == studentID).FirstOrDefault();
                if (studentinbatch == null)
                {
                    StudentInBatch studentInBatch = new StudentInBatch()
                    {
                        Student_Id = studentID,
                        Batch_Id = model.Id,
                        Student_Status = model.studentStaus,
                        Grade = model.studentGrade
                    };
                    _studentBatchRepo.AddStudentInBatch(studentInBatch);

                    //add a program to this Batch
                    //Programme program = new Programme()
                    //{
                    //    BatchId = batchID,
                    //    Program_Name = model.programType,
                    //    Duration = model.duration
                    //};
                    //_program.AddProgramme(program);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("duplicate keys", "Already asigned");
                List<Student> studentlist = _studentRepo.GetAllStudent().ToList();
                List<Batch> batches = _batchRepo.GetAllBatch().ToList();
                studentBatchViewModel studentBatchViewModel = new studentBatchViewModel()
                {
                    studentList = studentlist,
                    batchList = batches
                };
                return View(studentBatchViewModel);
            }
            return View(model);
        }
    }
}
