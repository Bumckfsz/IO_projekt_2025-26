namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class UITaskObject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            taskButton = new Button();
            taskName = new TextBox();
            SuspendLayout();
            // 
            // taskButton
            // 
            taskButton.Location = new Point(0, 0);
            taskButton.Name = "taskButton";
            taskButton.RightToLeft = RightToLeft.Yes;
            taskButton.Size = new Size(457, 95);
            taskButton.TabIndex = 0;
            taskButton.UseVisualStyleBackColor = true;
            taskButton.Click += taskButton_Click;
            // 
            // taskName
            // 
            taskName.Location = new Point(81, 12);
            taskName.Multiline = true;
            taskName.Name = "taskName";
            taskName.Size = new Size(275, 71);
            taskName.TabIndex = 1;
            // 
            // UITaskObject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(taskName);
            Controls.Add(taskButton);
            Name = "UITaskObject";
            Size = new Size(457, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button taskButton;
        private TextBox taskName;
    }
}