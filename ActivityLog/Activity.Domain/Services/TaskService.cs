using System;
using System.Collections.Generic;
using System.Linq;
using Activity.Domain.Models;

/*Zarzadzanie zadaniami w ramach projektow 
 * dodawanie zadan do projektu
 * zmiana statusu zadania
 * pobieranie listy zadan 
 * */

namespace Activity.Domain.Services
{
    public class TaskService
    {
        private int _nextTaskId = 1;

        public ProjectTask AddTask(Project project, string name, string description)
        {
            var task = new ProjectTask
            {
                TaskId = _nextTaskId++,
                Name = name,
                Description = description,
                StartDate = DateTime.Now
            };

            project.Tasks.Add(task);
            return task;
        }

        public void CompleteTask(ProjectTask task)
        {
            task.Status = Status.Completed;
            task.EndDate = DateTime.Now;
        }
    }
}