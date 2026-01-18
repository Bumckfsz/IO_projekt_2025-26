//ActivityAddNotification.cs
using Activity.Domain.Models; 
using Activity.Domain.Data;   
using System;
using System.Windows.Forms;
using DomainActivity = Activity.Domain.Models.Activity; // Alias

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class ActivityAddNotification : Form
    {
        //  Nie potrzebujemy Panelu ani Layoutu, potrzebujemy ID Zadania
        private ProjectTask _targetTask;

        public ActivityAddNotification(ProjectTask task)
        {
            InitializeComponent();
            _targetTask = task;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string description = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(description) && _targetTask != null)
            {
                // Zamiast rysować kafelek ręcznie, ZAPISUJEMY DO BAZY
                using (var db = new ActivityContext())
                {
                    //  Znajdź zadanie w bazie
                    var taskDb = db.ProjectTasks.Find(_targetTask.TaskId);

                    if (taskDb != null)
                    {
                        //  Dodaj nową aktywność
                        taskDb.Activities.Add(new DomainActivity
                        {
                            Description = description,
                            Date = DateTime.Now
                        });

                        //  Zapisz
                        db.SaveChanges();
                    }
                }
            }

            // Zamykamy okno. Form1 sam sobie odświeży listę.
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}