namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class ActivityAddNotification
    {
        private System.ComponentModel.IContainer components = null;

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
            confirmButton = new Button();
            textBox1 = new TextBox();
            activityLabel = new Label();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(235, 163);
            confirmButton.Margin = new Padding(3, 4, 3, 4);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(88, 31);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 36);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 117);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // activityLabel
            // 
            activityLabel.AutoSize = true;
            activityLabel.Location = new Point(14, 12);
            activityLabel.Name = "activityLabel";
            activityLabel.Size = new Size(88, 20);
            activityLabel.TabIndex = 2;
            activityLabel.Text = "Description:";
            // 
            // ActivityAddNotification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 201);
            Controls.Add(activityLabel);
            Controls.Add(textBox1);
            Controls.Add(confirmButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ActivityAddNotification";
            Text = "Add activity";
            Load += ActivityAddNotification_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmButton;
        private TextBox textBox1;
        private Label activityLabel;
    }
}