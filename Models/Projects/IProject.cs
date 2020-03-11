using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Projects
{
    public interface IProject
    {
        Project AddProject (Project project);
        Project UpdateProject (Project projectChanges);
        Project GetProject(int id);
        IEnumerable<Project> GetAllProjects();
        Project DeleteProject(int id);
    }
}
