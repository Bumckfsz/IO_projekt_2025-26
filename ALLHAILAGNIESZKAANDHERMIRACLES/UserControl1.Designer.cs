namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class UIProjectObject
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            projectButton = new Button();
            SuspendLayout();
            // 
            // projectButton
            // 
            projectButton.AutoSize = true;
            projectButton.Location = new Point(3, 3);
            projectButton.Name = "projectButton";
            projectButton.Size = new Size(200, 200);
            projectButton.TabIndex = 0;
            projectButton.UseVisualStyleBackColor = true;
            projectButton.Click += projectButton_Click;
            // 
            // UIProjectObject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(128, 128, 255);
            Controls.Add(projectButton);
            Name = "UIProjectObject";
            Size = new Size(206, 206);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button projectButton;
    }
}
