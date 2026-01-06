using Activity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Pojedyncze zadanie w ramach projektu*/
namespace Activity.Domain.Models
{
    public class ProjectTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Unstarted;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<Activity> Activities { get; set; } = new();
    }
}
