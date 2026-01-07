using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Reprezentuje projekt użytkownika*/
namespace Activity.Domain.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<ProjectTask> Tasks { get; set; } = new();
    }

}