using Activity.Domain.Models;
using Activity.Domain.Data; 
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;

namespace Activity.Domain.Services
{
    public class ProjectService
    {
        public Project AddProject(string name, string description)
        {
            using (var context = new ActivityContext())
            {
                var project = new Project
                {
                    Name = name,
                    Description = description
                };

                context.Projects.Add(project);
                context.SaveChanges(); 

                return project;
            }
        }

     
        public List<Project> GetProjects()
        {
            using (var context = new ActivityContext())
            {
                return context.Projects
                    .Include(p => p.Tasks)
                    .ThenInclude(t => t.Activities)
                    .ToList();
            }
        }
    }
}