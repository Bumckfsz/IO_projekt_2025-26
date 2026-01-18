using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Rezprezentuje pojedyncza aktywnosc uzytkownika*/
namespace Activity.Domain.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}