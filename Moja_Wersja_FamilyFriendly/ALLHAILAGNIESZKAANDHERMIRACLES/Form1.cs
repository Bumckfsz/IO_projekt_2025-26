using Activity.Domain.Models;
using Activity.Domain.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// Alias dla Activity, ¿eby nie myli³o siê z System.Diagnostics
using DomainActivity = Activity.Domain.Models.Activity;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class Form1 : Form
    {
        // --- SERWISY ---
        private readonly ProjectService _projectService = new ProjectService();
        private readonly TaskService _taskService = new TaskService();
        // private readonly ActivityService _activityService = new ActivityService();

        // --- STAN APLIKACJI ---
        private Project _currentProject;
        private ProjectTask _currentTask;

        public Form1()
        {
            InitializeComponent();
            SetupNavigation();
            RefreshProjectsList();  // Startujemy z danymi z bazy
        }

        // ---------------- NAWIGACJA ----------------
        private void SetupNavigation()
        {
            panel1.Visible = true;  // Lista Projektów
            panel4.Visible = false; // Lista Zadañ
            panel7.Visible = false; // Lista Aktywnoœci
            panel1.BringToFront();
        }

        // ---------------- PROJEKTY (Panel 1) ----------------
        private void RefreshProjectsList()
        {
            tableLayoutPanel1.Controls.Clear();
            var projects = _projectService.GetProjects(); // Pobiera z bazy

            foreach (var proj in projects)
            {
                // Tworzymy kafelek u¿ywaj¹c NOWEGO konstruktora
                var uiProject = new UIProjectObject(proj);

                // Podpinamy zdarzenie klikniêcia
                uiProject.OnProjectClick += HandleProjectSelected;

                tableLayoutPanel1.Controls.Add(uiProject);
            }
        }

        // Obs³uga klikniêcia w kafelek
        private void HandleProjectSelected(Project project)
        {
            _currentProject = project;

            // Zmieniamy panel
            panel1.Visible = false;
            panel4.Visible = true;
            panel4.BringToFront();

            RefreshTasksList();
        }

        // Przycisk "Dodaj Projekt"
        private void button3_Click(object sender, EventArgs e)
        {
            string newName = $"Projekt {DateTime.Now.ToShortTimeString()}";
            _projectService.AddProject(newName, "Opis...");
            RefreshProjectsList();
        }

        // ---------------- ZADANIA (Panel 4) ----------------
        private void RefreshTasksList()
        {
            if (_currentProject == null) return;

            // Odœwie¿amy dane projektu z bazy
            var freshData = _projectService.GetProjects()
                                .FirstOrDefault(p => p.ProjectId == _currentProject.ProjectId);

            if (freshData != null) _currentProject = freshData;

            tableLayoutPanel2.Controls.Clear();

            foreach (var task in _currentProject.Tasks)
            {
                var uiTask = new UITaskObject(task);
                uiTask.OnTaskClick += HandleTaskSelected;
                tableLayoutPanel2.Controls.Add(uiTask);
            }
        }

        private void HandleTaskSelected(ProjectTask task)
        {
            _currentTask = task;

            // Zmieniamy panel
            panel4.Visible = false;
            panel7.Visible = true;
            panel7.BringToFront();

            RefreshActivitiesList();
        }

        // Przycisk "Dodaj Zadanie"
        private void button4_Click(object sender, EventArgs e)
        {
            if (_currentProject == null) return;

            // Dodajemy zadanie do bazy
            // Upewnij siê, ¿e w TaskService.AddTask jest context.SaveChanges()
            // Jeœli nie ma, zadanie zniknie po restarcie!
            _taskService.AddTask(_currentProject, "Nowe Zadanie", "Opis...");

            RefreshTasksList();
        }

        // Przycisk "Powrót" (do projektów)
        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
            panel1.BringToFront();
            RefreshProjectsList();
        }

        // ---------------- AKTYWNOŒCI (Panel 7) ----------------
        private void RefreshActivitiesList()
        {
            if (_currentTask == null) return;

            tableLayoutPanel3.Controls.Clear();

            foreach (var act in _currentTask.Activities)
            {
                // Wyœwietlanie aktywnoœci jako Label
                Label lbl = new Label();
                lbl.Text = $"[{act.Date.ToShortTimeString()}] {act.Description}";
                lbl.AutoSize = true;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Margin = new Padding(5);
                lbl.Font = new Font("Courier", 10.0f);
                lbl.Width = 300;

                tableLayoutPanel3.Controls.Add(lbl);
            }
        }

        // Przycisk "Dodaj Aktywnoœæ"
        private void button6_Click(object sender, EventArgs e)
        {
            if (_currentTask == null) return;

            // Dodawanie aktywnoœci bezpoœrednio do bazy (obejœcie braku serwisu)
            using (var db = new Activity.Domain.Data.ActivityContext())
            {
                var taskDb = db.ProjectTasks.Find(_currentTask.TaskId);
                if (taskDb != null)
                {
                    var newActivity = new DomainActivity
                    {
                        Description = "Praca...",
                        Date = DateTime.Now
                    };
                    taskDb.Activities.Add(newActivity);
                    db.SaveChanges();
                }
            }

            // Odœwie¿anie drzewa danych
            var projects = _projectService.GetProjects();
            var proj = projects.FirstOrDefault(p => p.ProjectId == _currentProject.ProjectId);
            _currentTask = proj.Tasks.FirstOrDefault(t => t.TaskId == _currentTask.TaskId);

            RefreshActivitiesList();
        }

        // Przycisk "Powrót" (do zadañ)
        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = true;
            panel4.BringToFront();
            RefreshTasksList();
        }
    }
}