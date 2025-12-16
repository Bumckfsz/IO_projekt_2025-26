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
                var projekt = new UIProjectObject(_projectCount, panel1);
                //projekt.Nazwa = $"Project{_projectCounter++}";
                tableLayoutPanel1.Controls.Add(projekt);
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

    }
}
