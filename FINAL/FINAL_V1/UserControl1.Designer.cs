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
            projectName = new TextBox();
            SuspendLayout();
            // 
            // projectButton
            // 
            projectButton.AutoSize = true;
            projectButton.Location = new Point(3, 2);
            projectButton.Margin = new Padding(3, 2, 3, 2);
            projectButton.Name = "projectButton";
            projectButton.Size = new Size(162, 148);
            projectButton.TabIndex = 0;
            projectButton.UseVisualStyleBackColor = true;
            projectButton.Click += projectButton_Click;
            // 
            // projectName
            // 
            projectName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            projectName.Location = new Point(33, 28);
            projectName.Multiline = true;
            projectName.Name = "projectName";
            projectName.Size = new Size(103, 95);
            projectName.TabIndex = 1;
            projectName.TextChanged += projectName_TextChanged;
            // 
            // UIProjectObject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Gainsboro;
            Controls.Add(projectName);
            Controls.Add(projectButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UIProjectObject";
            Size = new Size(168, 152);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button projectButton;
        private TextBox projectName;
    }
}
