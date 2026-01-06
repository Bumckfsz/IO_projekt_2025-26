using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UIProjectObject : UserControl
    {
        private int _projectObjectNumber;
        private Panel _panel1;

        public UIProjectObject(int projectObjectNumber, Panel panel1)
        {
            _projectObjectNumber = projectObjectNumber;
            _panel1 = panel1;
            InitializeComponent();

            projectName.MaxLength = 50;
            Font myfont = new Font("Courier", 11.0f);
            projectName.Font = myfont;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{_projectObjectNumber}");
            _panel1.Visible = false;
        }

        private void projectName_Click(object sender, EventArgs e){

           

        }
    }
}
