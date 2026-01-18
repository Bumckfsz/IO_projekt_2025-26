using Activity.Domain.Models;
using Activity.Domain.Services;
using Activity.Domain.Data;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DomainActivity = Activity.Domain.Models.Activity;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class Form1 : Form
    {
        private readonly ProjectService _projectService = new ProjectService();
        private readonly TaskService _taskService = new TaskService();

        private Project _currentProject;
        private ProjectTask _currentTask;
        private System.Windows.Forms.Timer _notificationTimer;

        public Form1()
        {
            InitializeComponent();
            SetupNavigation();
            RefreshProjectsList();
            UpdateDailyPoints(); // Przelicz punkty na starcie

            // ---  Konfiguracja Timera ---
            _notificationTimer = new System.Windows.Forms.Timer();

            // Czas w milisekundach. 
            // 1000 ms = 1 sekunda
            // 60 * 1000 = 1 minuta
            // 60 * 60 * 1000 = 1 godzina (3 600 000 ms)
            _notificationTimer.Interval = 1000 * 60 * 60;

            // Co ma siê staæ jak minie czas:
            _notificationTimer.Tick += NotificationTimer_Tick;

            // Uruchom odliczanie
            _notificationTimer.Start();
        }

        // ---  Ta metoda odpala siê co godzinê ---
        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            // Przekazujemy 'this' (Form1), ¿eby przycisk "Answer" dzia³a³ (jak ustaliliœmy wczeœniej)
            ToastNotification toast = new ToastNotification(this);
            toast.Show();
        }

        // ==========================================
        //  LOGIKA PUNKTÓW (ZA UKOÑCZONE ZADANIA)
        // ==========================================
        private void UpdateDailyPoints()
        {
            int points = 0;
            using (var db = new ActivityContext())
            {
                DateTime today = DateTime.Today;

                // Liczymy zadania, które s¹ UKOÑCZONE i maj¹ datê zakoñczenia DZISIAJ
                // Uwaga: EndDate musi byæ ustawiane przy koñczeniu zadania (robimy to ni¿ej)
                int completedTasksToday = db.ProjectTasks
                    .Where(t => t.Status == Status.Completed && t.EndDate >= today)
                    .Count();

                // Przyjmijmy: 1 Ukoñczone Zadanie = 10 punktów 
                points = completedTasksToday * 10;
            }

            // ---  Aktualizujemy Label z punktami na KA¯DYM panelu ---
            // label3 - panel projektów
            // label5 - panel zadañ
            // label8 - panel aktywnoœci
            if (label3 != null) label3.Text = points.ToString();
            if (label5 != null) label5.Text = points.ToString();
            if (label8 != null) label8.Text = points.ToString();

            UpdateMascot(points);
        }

        private void UpdateMascot(int points)
        {
            string imageName = "0pkt.jpg";
            if (points >= 100) imageName = "100pkt.jpg";
            else if (points >= 75) imageName = "75pkt.jpg";
            else if (points >= 50) imageName = "50pkt.jpg";
            else if (points >= 30) imageName = "30pkt.jpg";
            else if (points >= 10) imageName = "10pkt.jpg";

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullPath = Path.Combine(folderPath, imageName);

            UpdateSingleBox(pictureBox1, fullPath);
            UpdateSingleBox(pictureBox2, fullPath);
            UpdateSingleBox(pictureBox3, fullPath);
        }       

        // Pomocnicza metoda, ¿eby nie kopiowaæ kodu 3 razy
        // Czyœci stary obrazek (zwalnia pamiêæ) i ³aduje nowy
        private void UpdateSingleBox(PictureBox box, string path)
        {
            if (box == null) return;

            if (box.Image != null)
            {
                box.Image.Dispose(); // Wa¿ne: Zwolnij stary obrazek z pamiêci
            }
            box.Image = Image.FromFile(path);
        }

        // ==========================================
        // PROJEKTY (Z obs³ug¹ usuwania)
        // ==========================================
        private void RefreshProjectsList()
        {
            tableLayoutPanel1.Controls.Clear();
            var projects = _projectService.GetProjects();

            foreach (var proj in projects)
            {
                var uiProject = new UIProjectObject(proj);
                uiProject.OnProjectClick += HandleProjectSelected;
                uiProject.OnProjectNameChanged += HandleProjectRename;

                //  Obs³uga usuwania
                uiProject.OnProjectDelete += HandleProjectDelete;

                tableLayoutPanel1.Controls.Add(uiProject);
            }
        }

        private void HandleProjectDelete(Project project)
        {
            using (var db = new ActivityContext())
            {
                db.Projects.Remove(project); // Usuwa projekt i kaskadowo jego zadania
                db.SaveChanges();
            }
            RefreshProjectsList();
            UpdateDailyPoints(); // Punkty mog¹ spaœæ jeœli usuniemy wykonane zadania
        }

        private void HandleProjectSelected(Project project)
        {
            _currentProject = project;
            panel1.Visible = false;
            panel4.Visible = true;
            RefreshTasksList();
        }

        private void HandleProjectRename(Project project)
        {
            using (var db = new ActivityContext())
            {
                db.Projects.Update(project);
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _projectService.AddProject("Nowy Projekt", "Opis");
            RefreshProjectsList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
            RefreshProjectsList();
        }

        // ==========================================
        // ZADANIA (Z obs³ug¹ usuwania i koñczenia)
        // ==========================================
        private void RefreshTasksList()
        {
            if (_currentProject == null) return;

            var freshData = _projectService.GetProjects()
                .FirstOrDefault(p => p.ProjectId == _currentProject.ProjectId);

            if (freshData != null) _currentProject = freshData;

            tableLayoutPanel2.Controls.Clear();

            // Sortujemy: Najpierw aktywne, potem ukoñczone (na dole)
            var sortedTasks = _currentProject.Tasks
                .OrderBy(t => t.Status == Status.Completed) // False (0) jest przed True (1)
                .ThenBy(t => t.TaskId);

            foreach (var task in sortedTasks)
            {
                var uiTask = new UITaskObject(task);
                uiTask.OnTaskClick += HandleTaskSelected;
                uiTask.OnTaskNameChanged += HandleTaskRename;

                //  ZDARZENIA
                uiTask.OnTaskDelete += HandleTaskDelete;
                uiTask.OnTaskComplete += HandleTaskComplete;

                tableLayoutPanel2.Controls.Add(uiTask);
            }
        }

        private void HandleTaskDelete(ProjectTask task)
        {
            using (var db = new ActivityContext())
            {
                db.ProjectTasks.Remove(task);
                db.SaveChanges();
            }
            RefreshTasksList();
            UpdateDailyPoints();
        }

        private void HandleTaskComplete(ProjectTask task)
        {
            using (var db = new ActivityContext())
            {
                // Musimy pobraæ zadanie z kontekstu, ¿eby je edytowaæ
                var taskDb = db.ProjectTasks.Find(task.TaskId);
                if (taskDb != null)
                {
                    taskDb.Status = Status.Completed;
                    taskDb.EndDate = DateTime.Now; //  Zapisujemy datê ukoñczenia!
                    db.SaveChanges();
                }
            }

            // Odœwie¿amy listê (zadanie spadnie na dó³ i zrobi siê szare)
            RefreshTasksList();

            // Naliczamy punkty i zmieniamy maskotkê!
            UpdateDailyPoints();

            // Opcjonalnie: Gratulacje
            MessageBox.Show("Gratulacje! Zadanie ukoñczone (+10 pkt)");
        }

        private void HandleTaskSelected(ProjectTask task)
        {
            _currentTask = task;
            panel4.Visible = false;
            panel7.Visible = true;
            RefreshActivitiesList();
        }

        private void HandleTaskRename(ProjectTask task)
        {
            using (var db = new ActivityContext())
            {
                db.ProjectTasks.Update(task);
                db.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_currentProject == null) return;
            _taskService.AddTask(_currentProject, "Nowe Zadanie", "Opis");
            RefreshTasksList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = true;
            RefreshTasksList();
        }

        // ==========================================
        // AKTYWNOŒCI
        // ==========================================
        private void RefreshActivitiesList()
        {
            if (_currentTask == null) return;
            tableLayoutPanel3.Controls.Clear();
            foreach (var act in _currentTask.Activities)
            {
                var uiActivity = new UIActivityObject(act);
                tableLayoutPanel3.Controls.Add(uiActivity);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_currentTask == null) return;

            // Jeœli zadanie jest ukoñczone, blokujemy dodawanie aktywnoœci
            if (_currentTask.Status == Status.Completed)
            {
                MessageBox.Show("Nie mo¿na dodawaæ aktywnoœci do ukoñczonego zadania.");
                return;
            }

            var activityWindow = new ActivityAddNotification(_currentTask);
            activityWindow.ShowDialog();

            // Odœwie¿enie
            var projects = _projectService.GetProjects();
            var proj = projects.FirstOrDefault(p => p.ProjectId == _currentProject.ProjectId);
            if (proj != null)
            {
                _currentTask = proj.Tasks.FirstOrDefault(t => t.TaskId == _currentTask.TaskId);
            }
            RefreshActivitiesList();
        }

        public void SetupNavigation()
        {
            panel1.Visible = true;
            panel4.Visible = false;
            panel7.Visible = false;
            panel1.BringToFront();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }

        // Powiadomienia
        private void button1_Click(object sender, EventArgs e)
        {
            ToastNotification toast = new ToastNotification();
            toast.Show();
            weeklySummary weeklySummary = new weeklySummary();
            weeklySummary.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthlySummary monthlySummary = new monthlySummary();
            monthlySummary.Show();
        }
    }
}