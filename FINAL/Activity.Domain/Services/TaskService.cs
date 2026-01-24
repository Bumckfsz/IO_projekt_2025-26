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

                    projectDb.Tasks.Add(task);

                    context.SaveChanges(); 
                    return task;
                }
                return null;
            }
        }

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