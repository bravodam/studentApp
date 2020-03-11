using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Projects
{
    public class SQLProjectRepo : IProject
    {
        private readonly AppDbContext appDbContext;

        public SQLProjectRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Project AddProject(Project project)
        {
            appDbContext.Projects.Add(project);
            appDbContext.SaveChanges();
            return project;
        }

        public Project DeleteProject(int id)
        {
            Project project = appDbContext.Projects.Find(id);
            if (project != null)
            {
                appDbContext.Projects.Remove(project);
                appDbContext.SaveChanges();
            }
            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return appDbContext.Projects;
        }

        public Project GetProject(int id)
        {
            return appDbContext.Projects.Find(id);
        }

        public Project UpdateProject(Project projectChanges)
        {
            var pro = appDbContext.Projects.Attach(projectChanges);
            pro.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return projectChanges;
        }
    }
}
