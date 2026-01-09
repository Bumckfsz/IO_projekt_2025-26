using Activity.Domain.Models;
using Activity.Domain.Data;
using System;
using System.Linq;

namespace Activity.Domain.Services
{
    public class TaskService
    {
        public ProjectTask AddTask(Project project, string name, string description)
        {
            using (var context = new ActivityContext())
            {
                // Musimy znaleźć ten projekt w aktualnym połączeniu do bazy
                var projectDb = context.Projects.Find(project.ProjectId);

                if (projectDb != null)
                {
                    var task = new ProjectTask
                    {
                        Name = name,
                        Description = description,
                        StartDate = DateTime.Now,
                        Status = Status.Started
                    };

                    // Dzięki Shadow Properties, EF Core sam ogarnie relację
                    projectDb.Tasks.Add(task);

                    context.SaveChanges(); // Zapis do bazy
                    return task;
                }
                return null;
            }
        }

        // Opcjonalnie: Metoda do oznaczania jako zakończone
        public void CompleteTask(ProjectTask task)
        {
            using (var context = new ActivityContext())
            {
                var taskDb = context.ProjectTasks.Find(task.TaskId);
                if (taskDb != null)
                {
                    taskDb.Status = Status.Completed;
                    taskDb.EndDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}