using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Punkty zdobyte przez uzytkownika w danym dniu*/
namespace Activity.Domain.Models
{
    public class Points
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
