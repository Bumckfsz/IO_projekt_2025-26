using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{_projectObjectNumber}");
            _panel1.Visible = false;
        }
    }
}
