using Activity.Domain.Models;
using Activity.Domain.Data; // Dostep do Contextu
using Microsoft.EntityFrameworkCore; // Ważne dla .Include()
using System.Collections.Generic;
using System.Linq;

namespace Activity.Domain.Services
{
    public class ProjectService
    {
        // Metoda dodająca projekt do BAZY DANYCH
        public Project AddProject(string name, string description)
        {
            using (var context = new ActivityContext())
            {
                var project = new Project
                {
                    // ID nada się samo w bazie (AutoIncrement)
                    Name = name,
                    Description = description
                };

                context.Projects.Add(project);
                context.SaveChanges(); // Tu następuje zapis do pliku .db

                return project;
            }
        }

        // Metoda pobierająca listę z BAZY DANYCH
        public List<Project> GetProjects()
        {
            using (var context = new ActivityContext())
            {
                // Używamy .Include, żeby pobrać całe drzewo:
                // Projekt -> ma Zadania -> mają Aktywności
                return context.Projects
                    .Include(p => p.Tasks)
                    .ThenInclude(t => t.Activities)
                    .ToList();
            }
        }
    }
}