using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity.Domain.Models;

namespace Activity.Domain.Services
{
    public class ActivityService
    {
        private int _nextActivityId = 1;
        public Models.Activity AddActivity(ProjectTask task, string description)
        {
            var activity = new Models.Activity
            {
                ActivityId = _nextActivityId++,
                Description = description,
                Date = DateTime.Now
            };

            task.Activities.Add(activity);
            return activity;
        }
    }
}