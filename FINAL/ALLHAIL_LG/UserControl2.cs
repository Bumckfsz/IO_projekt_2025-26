using Activity.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UITaskObject : UserControl
    {
        public ProjectTask TaskData { get; private set; }
        public event Action<ProjectTask> OnTaskClick;
        public event Action<ProjectTask> OnTaskNameChanged;
        public event Action<ProjectTask> OnTaskDelete;
        public event Action<ProjectTask> OnTaskComplete;

        private bool _isDeleted = false;

        public UITaskObject(ProjectTask task)
        {
            InitializeComponent();
            TaskData = task;

            taskName.MaxLength = 100;
            taskName.Font = new Font("Courier", 11.0f);
            taskName.Text = task.Name;

            if (task.Status == Status.Completed)
            {
                taskButton.BackColor = Color.Gray;
                taskName.BackColor = Color.Gray;
                taskName.ReadOnly = true;
                taskName.ForeColor = Color.White;
            }
            else
            {
                taskButton.BackColor = Color.WhiteSmoke;
                taskName.BackColor = Color.White;
                taskName.ReadOnly = false;
                taskName.ForeColor = Color.Black;

                taskName.KeyDown += TaskName_KeyDown;
                taskName.Leave += TaskName_Leave;
            }

            SetupContextMenu();
        }

        public UITaskObject() { InitializeComponent(); }

        private void SetupContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            if (TaskData.Status != Status.Completed)
            {
                var completeItem = new ToolStripMenuItem("✅ Ukończ Zadanie");
                completeItem.Click += (s, e) => { OnTaskComplete?.Invoke(TaskData); };
                menu.Items.Add(completeItem);
            }

            var deleteItem = new ToolStripMenuItem("🗑 Usuń Zadanie");
            deleteItem.Click += (s, e) =>
            {
                var result = MessageBox.Show($"Usunąć zadanie '{TaskData.Name}'?", "Usuwanie", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _isDeleted = true;
                    this.Focus();
                    OnTaskDelete?.Invoke(TaskData);
                }
            };
            menu.Items.Add(deleteItem);

            this.ContextMenuStrip = menu;
            taskButton.ContextMenuStrip = menu;
            taskName.ContextMenuStrip = menu;
        }

        private void taskButton_Click(object sender, EventArgs e)
        {
            OnTaskClick?.Invoke(TaskData);
        }

        private void TaskName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveName();
                this.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void TaskName_Leave(object sender, EventArgs e)
        {
            SaveName();
        }

        private void SaveName()
        {
            if (_isDeleted) return;

            if (TaskData.Name != taskName.Text)
            {
                TaskData.Name = taskName.Text;
                OnTaskNameChanged?.Invoke(TaskData);
            }
        }
    }
}