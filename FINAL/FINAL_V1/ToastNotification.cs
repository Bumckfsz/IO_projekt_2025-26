using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class ToastNotification : Form
    {
        int toastX, toastY;

        private Form1 _mainForm;

        public ToastNotification()
        {
            InitializeComponent();
        }

        public ToastNotification(Form1 mainForm) : this()
        {
            _mainForm = mainForm;
        }

        private void ToastNotification_Load(object sender, EventArgs e)
        {
            position();
        }

        private void toastAnswer_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
            {
                _mainForm.Show();

                if (_mainForm.WindowState == FormWindowState.Minimized)
                {
                    _mainForm.WindowState = FormWindowState.Normal;
                }

                _mainForm.BringToFront();
                _mainForm.Activate();
                _mainForm.Focus(); 
                _mainForm.SetupNavigation();
            }

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