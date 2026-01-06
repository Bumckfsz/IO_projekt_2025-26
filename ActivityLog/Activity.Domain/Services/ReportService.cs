using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity.Domain.Models;

/* Odpowiada za tworzenie raportów tygodniowych i miesiecznych 
 */

namespace Activity.Domain.Services
{
    public class ReportService
    {
        public int CountActivities(Project project)
        {
            return project.Tasks.Sum(t => t.Activities.Count);
        }

        public int CountTasks(Project project)
        {
            return project.Tasks.Count;
        }
    }
}