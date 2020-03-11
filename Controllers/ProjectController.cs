using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Projects;
using Code360_Management.ViewModels.ProjectModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Project")]
    public class ProjectController : Controller
    {
        private readonly IProject _projectRepo;

        public ProjectController(IProject projectRepo)
        {
            _projectRepo = projectRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_projectRepo.GetAllProjects());
        }

        [Route("create/{id?}")]
        [HttpGet]
        public ViewResult addProject(int id)
        {
            return View();
        }

        [Route("create/{id?}")]
        [HttpPost]
        public IActionResult addProject(projectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project()
                {
                    Name = model.projectname,
                    Project_Status = model.status,
                    ProjectUrl = model.url,
                    StudentId = model.Id,
                };
                _projectRepo.AddProject(project);
                return RedirectToAction("ViewStudent", "Home");
            }
            return View();
        }

        [Route("remove/{id?}")]
        public IActionResult Delete(int id)
        {
            var pro = _projectRepo.DeleteProject(id);
            return RedirectToAction("ViewStudent", "Home", new { id = pro.StudentId });
        }
        
        [Route("edit/{id?}")]
        [HttpGet]
        public ViewResult Update(int id)
        {
            Project project = _projectRepo.GetProject(id);
            projectViewModel projectView = new projectViewModel()
            {
                projectname = project.Name,
                url = project.ProjectUrl,
                status = project.Project_Status,
                Id = id
            };
            return View(projectView);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Update(projectViewModel model)
        {
            Project project = _projectRepo.GetProject(model.Id);
            project.Name = model.projectname;
            project.Project_Status = model.status;
            project.ProjectUrl = model.url;
            _projectRepo.UpdateProject(project);

            return RedirectToAction("ViewStudent", "Home",new { id=project.StudentId});
        }
    }
}
