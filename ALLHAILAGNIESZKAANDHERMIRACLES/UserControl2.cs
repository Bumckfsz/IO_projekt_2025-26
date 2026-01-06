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
    public partial class UITaskObject : UserControl
    {
        private Panel _panel4;
        public UITaskObject(Panel panel4)
        {
            _panel4 = panel4;
            InitializeComponent();

            taskName.MaxLength = 50;
            Font myfont = new Font("Courier", 11.0f);
            taskName.Font = myfont;
        }

        private void taskButton_Click(object sender, EventArgs e)
        {
            _panel4.Visible = false;
        }
    }
}
