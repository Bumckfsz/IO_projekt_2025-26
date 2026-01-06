using Activity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Umozliwia zarzadzanie projektami:
 * tworzenie nowych projektow
 * edycja podstawowych informacji
 * zmiana stanu projektu
 * 
 */
namespace Activity.Domain.Services
{
    public class ProjectService
    {
        private readonly List<Project> _projects = new();
        private int _nextProjectId = 1;

        public Project AddProject(string name, string description)
        {
            var project = new Project
            {
                ProjectId = _nextProjectId++,
                Name = name,
                Description = description
            };

            _projects.Add(project);
            return project;
        }

        public List<Project> GetProjects() => _projects;
    }
}