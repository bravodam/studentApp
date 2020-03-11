using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Programs;
using Code360_Management.ViewModels.ProgramCourse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Program")]
    public class ProgramController : Controller
    {
        private readonly IProgram _programRepo;

        public ProgramController(IProgram programRepo)
        {
            _programRepo = programRepo;
        }

        [Route("index")]
        public ViewResult Index()
        {
            return View(_programRepo.GetAllProgrammes());
        }

        [Route("create")]
        [HttpGet]
        public ViewResult AddProgram()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult AddProgram(ProgramViewModel model)
        {
            /*double cost;
            string type = model.cost_type.ToString();*/

            if (ModelState.IsValid)
            {
                //check the cost_type to verify the cost of the program
                //paid option = 300K

                //Income_Sharing = 1M
                //switch (model.cost_type)
                //{
                //    case Models.Students.addmissionType.Paid:
                //        cost = 300000;
                //        break;
                //    case Models.Students.addmissionType.Income_Sharing:
                //        cost = 1000000;
                //        break;
                //    default:
                //        break;
                //}

                Programme programme = new Programme()
                {
                    Program_Name = model.ProgramName,
                    Cost = model.cost,
                    Duration = model.duration
                };
                _programRepo.AddProgramme(programme);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Remove/{id?}")]
        public IActionResult Delete(int id)
        {
            _programRepo.DeleteProgramme(id);
            return RedirectToAction("Index");
        }

        [Route("edit/{id?}")]
        [HttpGet]
        public ViewResult Update(int id)
        {
            Programme program = _programRepo.GetProgramme(id);
            ProgramViewModel model = new ProgramViewModel()
            {
                ProgramName = program.Program_Name,
                duration = program.Duration,
                cost = program.Cost
            };
            return View(model);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Update(ProgramViewModel model)
        {
            if (ModelState.IsValid)
            {
                Programme program = _programRepo.GetProgramme(model.ID);
                program.Program_Name = model.ProgramName;
                program.Duration = model.duration;
                program.Cost = model.cost;

                _programRepo.UpdateProgramme(program);
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
