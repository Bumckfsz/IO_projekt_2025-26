using Activity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*System punktowy aplikacji
 * naliczanie punktów odbywa się przez dodanie aktywności i ukończenie zadania
 * Serwis przechowuje historie punktow i umozliwia pobranie stanu aktualnego
 */

namespace Activity.Domain.Services
{
    public class PointsService
    {
        private readonly List<Points> _points = new();

        public void AddActivityPoints()
        {
            _points.Add(new Points
            {
                Date = DateTime.Now,
                Value = 5
            });
        }

        public void AddTaskCompletionPoints()
        {
            _points.Add(new Points
            {
                Date = DateTime.Now,
                Value = 20
            });
        }

        public int GetTotalPoints()
        {
            return _points.Sum(p => p.Value);
        }
    }
}