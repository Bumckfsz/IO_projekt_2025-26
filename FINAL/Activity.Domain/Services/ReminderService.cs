using Activity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Domain.Services
{
    public class ReminderService
    {
        private DateTime? _lastReminder;

        public bool ShouldRemind()
        {
            if (_lastReminder == null || DateTime.Now - _lastReminder > TimeSpan.FromMinutes(30))
            {
                _lastReminder = DateTime.Now;
                return true;
            }

            return false;
        }
    }
}

