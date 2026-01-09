using Activity.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UIProjectObject : UserControl
    {
        // To są dane tego kafelka
        public Project ProjectData { get; private set; }

        // Zdarzenie (Event) - dzięki temu Form1 dowie się, że kliknięto TEN projekt
        public event Action<Project> OnProjectClick;

        // Pusty konstruktor dla Designera
        public UIProjectObject()
        {
            InitializeComponent();
        }

        // NOWY KONSTRUKTOR - przyjmuje dane z bazy
        public UIProjectObject(Project project) : this()
        {
            ProjectData = project;

            // Ustawiamy wygląd (zachowałem Twoje ustawienia czcionki)
            Font myfont = new Font("Courier", 11.0f);
            projectName.Font = myfont;
            projectName.MaxLength = 50;

            // Wpisujemy nazwę z bazy
            projectName.Text = project.Name;

            // Blokujemy edycję, żeby to był tylko kafelek do klikania
            // (chyba że chcesz pozwalać na edycję nazwy tutaj)
            projectName.ReadOnly = true;
            projectName.BackColor = Color.White;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        // Kliknięcie w przycisk tła
        private void projectButton_Click(object sender, EventArgs e)
        {
            // Wywołujemy zdarzenie, przekazując dane projektu do Form1
            OnProjectClick?.Invoke(ProjectData);
        }

        // Kliknięcie w tekst (też powinno zadziałać jako wybór projektu)
        private void projectName_Click(object sender, EventArgs e)
        {
            // Opcjonalnie: Przekazujemy kliknięcie dalej
            // OnProjectClick?.Invoke(ProjectData);
        }
    }
}