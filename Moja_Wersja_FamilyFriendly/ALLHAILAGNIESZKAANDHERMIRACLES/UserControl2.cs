using Activity.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UITaskObject : UserControl
    {
        // Dane zadania
        public ProjectTask TaskData { get; private set; }
        
        // Zdarzenie kliknięcia
        public event Action<ProjectTask> OnTaskClick;

        public UITaskObject()
        {
            InitializeComponent();
        }

        // NOWY KONSTRUKTOR - przyjmuje dane z bazy
        public UITaskObject(ProjectTask task) : this()
        {
            TaskData = task;

            // Twoje style
            Font myfont = new Font("Courier", 11.0f);
            taskName.Font = myfont;
            taskName.MaxLength = 50;

            // Wpisujemy dane
            taskName.Text = task.Name;
            taskName.ReadOnly = true;
            taskName.BackColor = Color.White;

            // Jeśli zadanie ukończone -> zmień kolor na zielony
            if (task.Status == Status.Completed)
            {
                taskButton.BackColor = Color.LightGreen;
            }
        }

        private void taskButton_Click(object sender, EventArgs e)
        {
            // Powiadamiamy Form1 o kliknięciu
            OnTaskClick?.Invoke(TaskData);
        }
    }
}