using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class ToastNotification : Form
    {
        int toastX, toastY;

        // Pola na przechowanie referencji do Form1
        private Form1 _mainForm;

        // Konstruktor bez parametrów (dla Designera, żeby nie krzyczał błędami)
        public ToastNotification()
        {
            InitializeComponent();
        }

        // NOWY KONSTRUKTOR: Przyjmuje Form1
        public ToastNotification(Form1 mainForm) : this()
        {
            _mainForm = mainForm;
        }

        private void ToastNotification_Load(object sender, EventArgs e)
        {
            position();
        }

        // ====================================================
        // TO JEST AKCJA DLA PRZYCISKU "ANSWER"
        // ====================================================
        private void toastAnswer_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
            {
                // 1. Jeśli okno było ukryte (np. w trayu), pokaż je
                _mainForm.Show();

                // 2. Jeśli okno jest zminimalizowane (na pasku zadań), przywróć je
                if (_mainForm.WindowState == FormWindowState.Minimized)
                {
                    _mainForm.WindowState = FormWindowState.Normal;
                }

                // 3. Wymuś wyciągnięcie na wierzch
                _mainForm.BringToFront();
                _mainForm.Activate();
                _mainForm.Focus(); // Dodatkowe ubezpieczenie

                // 4. Zresetuj widok na Projekty
                _mainForm.SetupNavigation();
            }

            // 5. Zamknij powiadomienie
            this.Close();
        }



        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);


            if (toastY <= 940)
            {
                toastTimer.Stop();
            }
        }

        private void position()
        {
            int screenW = Screen.PrimaryScreen.WorkingArea.Width;
            int screenH = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenW - this.Width;
            toastY = screenH - this.Height + 70;

            this.Location = new Point(toastX, toastY);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            toastAnswer_Click(sender, e);
        }
    }
}