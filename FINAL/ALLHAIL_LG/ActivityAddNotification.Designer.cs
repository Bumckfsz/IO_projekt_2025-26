namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class ActivityAddNotification
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
            confirmButton = new Button();
            textBox1 = new TextBox();
            activityLabel = new Label();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(206, 122);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(77, 23);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(271, 89);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += this.textBox1_TextChanged;
            // 
            // activityLabel
            // 
            activityLabel.AutoSize = true;
            activityLabel.Location = new Point(12, 9);
            activityLabel.Name = "activityLabel";
            activityLabel.Size = new Size(70, 15);
            activityLabel.TabIndex = 2;
            activityLabel.Text = "Description:";
            // 
            // ActivityAddNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 151);
            Controls.Add(activityLabel);
            Controls.Add(textBox1);
            Controls.Add(confirmButton);
            Name = "ActivityAddNotification";
            Text = "Add activity";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmButton;
        private TextBox textBox1;
        private Label activityLabel;
    }
}