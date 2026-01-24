using Activity.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UIProjectObject : UserControl
    {
        public Project ProjectData { get; private set; }
        public event Action<Project> OnProjectClick;
        public event Action<Project> OnProjectNameChanged;
        public event Action<Project> OnProjectDelete;

        private bool _isDeleted = false;

        public UIProjectObject(Project project)
        {
            InitializeComponent();
            ProjectData = project;

           
            projectName.MaxLength = 100; 
            projectName.Font = new Font("Courier", 11.0f);
            projectName.Text = project.Name;
            projectName.ReadOnly = false;
            projectName.BackColor = Color.White;

            projectName.KeyDown += ProjectName_KeyDown;
            projectName.Leave += ProjectName_Leave;

            SetupContextMenu();
        }

        public UIProjectObject() { InitializeComponent(); }

        private void SetupContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Usuń Projekt");
            deleteItem.Click += (s, e) =>
            {
                var result = MessageBox.Show($"Czy na pewno usunąć projekt '{ProjectData.Name}'?",
                                             "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _isDeleted = true;

                    this.Focus();

                    OnProjectDelete?.Invoke(ProjectData);
                }
            };
            menu.Items.Add(deleteItem);

            this.ContextMenuStrip = menu;
            projectButton.ContextMenuStrip = menu;
            projectName.ContextMenuStrip = menu;
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            OnProjectClick?.Invoke(ProjectData);
        }

        private void ProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveName();
                this.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void ProjectName_Leave(object sender, EventArgs e)
        {
            SaveName();
        }

        private void SaveName()
        {
            if (_isDeleted) return;

            if (ProjectData.Name != projectName.Text)
            {
                ProjectData.Name = projectName.Text;
                OnProjectNameChanged?.Invoke(ProjectData);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e) { }
        private void projectName_Click(object sender, EventArgs e) { }
        private void projectName_TextChanged(object sender, EventArgs e) { }
    }
}