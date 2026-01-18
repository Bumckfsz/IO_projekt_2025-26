using Activity.Domain.Models;
using Activity.Domain.Data;
using System;
using System.Linq;

// Alias dla Activity, bo nazwa koliduje z systemową
using DomainActivity = Activity.Domain.Models.Activity;

namespace Activity.Domain.Services
{
    public class ActivityService
    {
        public DomainActivity AddActivity(ProjectTask task, string description)
        {
            using (var context = new ActivityContext())
            {
                // Szukamy zadania w bazie
                var taskDb = context.ProjectTasks.Find(task.TaskId);

                if (taskDb != null)
                {
                    var activity = new DomainActivity
                    {
                        Description = description,
                        Date = DateTime.Now
                    };

                    taskDb.Activities.Add(activity);

                    context.SaveChanges(); // Zapis do bazy
                    return activity;
                }
                return null;
            }
        }
    }
}