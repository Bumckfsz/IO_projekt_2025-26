namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class ToastNotification
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToastNotification));
            pictureBox1 = new PictureBox();
            toastLabel = new Label();
            toastAnswer = new Button();
            toastTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(112, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // toastLabel
            // 
            toastLabel.AutoSize = true;
            toastLabel.Font = new Font("Segoe UI", 12F);
            toastLabel.Location = new Point(12, 21);
            toastLabel.Name = "toastLabel";
            toastLabel.Size = new Size(94, 21);
            toastLabel.TabIndex = 1;
            toastLabel.Text = "How u doin'";
            toastLabel.Click += label1_Click;
            // 
            // toastAnswer
            // 
            toastAnswer.Location = new Point(12, 45);
            toastAnswer.Name = "toastAnswer";
            toastAnswer.Size = new Size(94, 33);
            toastAnswer.TabIndex = 2;
            toastAnswer.Text = "answer";
            toastAnswer.UseVisualStyleBackColor = true;
            toastAnswer.Click += toastAnswer_Click;
            // 
            // toastTimer
            // 
            toastTimer.Enabled = true;
            toastTimer.Interval = 10;
            toastTimer.Tick += toastTimer_Tick;
            // 
            // ToastNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(207, 90);
            Controls.Add(toastAnswer);
            Controls.Add(toastLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToastNotification";
            Text = "ToastNotification";
            Load += ToastNotification_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label toastLabel;
        private Button toastAnswer;
        private System.Windows.Forms.Timer toastTimer;
    }
}