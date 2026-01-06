namespace ALLHAILAGNIESZKAANDHERMIRACLES
{

    public partial class Form1 : Form
    {
        private int _projectCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_projectCount < 9)
            {
                _projectCount++;
                var project = new UIProjectObject(_projectCount, panel1);
                //projekt.Nazwa = $"Project{_projectCounter++}";
                tableLayoutPanel1.Controls.Add(project);
            }
            else
            {
                MessageBox.Show("You've reached the maximum project count!", "Warning");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var task = new UITaskObject(panel4);
            tableLayoutPanel2.Controls.Add(task);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }
    }
}
