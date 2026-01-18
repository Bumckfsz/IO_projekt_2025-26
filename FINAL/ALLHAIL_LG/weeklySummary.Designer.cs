namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class weeklySummary
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            weeklySummaryPanel = new Panel();
            labelPanel = new Panel();
            weeklySummaryLabel = new Label();
            dataPanel = new Panel();
            weeklyPointsAmt = new Label();
            weeklyPointsAmtLabel = new Label();
            weeklyDataPanel = new Panel();
            chartPanel = new Panel();
            weeklyDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            weeklySummaryPanel.SuspendLayout();
            labelPanel.SuspendLayout();
            dataPanel.SuspendLayout();
            weeklyDataPanel.SuspendLayout();
            chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weeklyDataChart).BeginInit();
            SuspendLayout();
            // 
            // weeklySummaryPanel
            // 
            weeklySummaryPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            weeklySummaryPanel.Controls.Add(dataPanel);
            weeklySummaryPanel.Controls.Add(labelPanel);
            weeklySummaryPanel.Dock = DockStyle.Top;
            weeklySummaryPanel.Location = new Point(0, 0);
            weeklySummaryPanel.Name = "weeklySummaryPanel";
            weeklySummaryPanel.Size = new Size(800, 62);
            weeklySummaryPanel.TabIndex = 0;
            // 
            // labelPanel
            // 
            labelPanel.Controls.Add(weeklySummaryLabel);
            labelPanel.Dock = DockStyle.Left;
            labelPanel.Location = new Point(0, 0);
            labelPanel.Name = "labelPanel";
            labelPanel.Size = new Size(380, 62);
            labelPanel.TabIndex = 1;
            // 
            // weeklySummaryLabel
            // 
            weeklySummaryLabel.Anchor = AnchorStyles.None;
            weeklySummaryLabel.AutoSize = true;
            weeklySummaryLabel.Font = new Font("Consolas", 15F);
            weeklySummaryLabel.Location = new Point(75, 20);
            weeklySummaryLabel.Name = "weeklySummaryLabel";
            weeklySummaryLabel.Size = new Size(230, 23);
            weeklySummaryLabel.TabIndex = 1;
            weeklySummaryLabel.Text = "Current week summary";
            // 
            // dataPanel
            // 
            dataPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dataPanel.BackColor = Color.LightSkyBlue;
            dataPanel.Controls.Add(weeklyPointsAmt);
            dataPanel.Controls.Add(weeklyPointsAmtLabel);
            dataPanel.Dock = DockStyle.Right;
            dataPanel.Location = new Point(383, 0);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(417, 62);
            dataPanel.TabIndex = 0;
            // 
            // weeklyPointsAmt
            // 
            weeklyPointsAmt.AutoSize = true;
            weeklyPointsAmt.Font = new Font("Consolas", 15F);
            weeklyPointsAmt.Location = new Point(316, 19);
            weeklyPointsAmt.Name = "weeklyPointsAmt";
            weeklyPointsAmt.Size = new Size(43, 23);
            weeklyPointsAmt.TabIndex = 2;
            weeklyPointsAmt.Text = "INT";
            // 
            // weeklyPointsAmtLabel
            // 
            weeklyPointsAmtLabel.Anchor = AnchorStyles.None;
            weeklyPointsAmtLabel.AutoSize = true;
            weeklyPointsAmtLabel.Font = new Font("Consolas", 15F);
            weeklyPointsAmtLabel.Location = new Point(3, 19);
            weeklyPointsAmtLabel.Name = "weeklyPointsAmtLabel";
            weeklyPointsAmtLabel.Size = new Size(307, 23);
            weeklyPointsAmtLabel.TabIndex = 0;
            weeklyPointsAmtLabel.Text = "Points collected this week:";
            weeklyPointsAmtLabel.Click += label1_Click;
            // 
            // weeklyDataPanel
            // 
            weeklyDataPanel.Controls.Add(chartPanel);
            weeklyDataPanel.Dock = DockStyle.Fill;
            weeklyDataPanel.Location = new Point(0, 62);
            weeklyDataPanel.Name = "weeklyDataPanel";
            weeklyDataPanel.Size = new Size(800, 388);
            weeklyDataPanel.TabIndex = 1;
            // 
            // chartPanel
            // 
            chartPanel.Controls.Add(weeklyDataChart);
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(0, 0);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(800, 388);
            chartPanel.TabIndex = 1;
            // 
            // weeklyDataChart
            // 
            chartArea1.Name = "ChartArea1";
            weeklyDataChart.ChartAreas.Add(chartArea1);
            weeklyDataChart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            weeklyDataChart.Legends.Add(legend1);
            weeklyDataChart.Location = new Point(0, 0);
            weeklyDataChart.Name = "weeklyDataChart";
            weeklyDataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            weeklyDataChart.Series.Add(series1);
            weeklyDataChart.Size = new Size(800, 388);
            weeklyDataChart.TabIndex = 0;
            weeklyDataChart.Text = "chart1";
            // 
            // weeklySummary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(weeklyDataPanel);
            Controls.Add(weeklySummaryPanel);
            Name = "weeklySummary";
            Text = "weeklySummary";
            weeklySummaryPanel.ResumeLayout(false);
            labelPanel.ResumeLayout(false);
            labelPanel.PerformLayout();
            dataPanel.ResumeLayout(false);
            dataPanel.PerformLayout();
            weeklyDataPanel.ResumeLayout(false);
            chartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)weeklyDataChart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel weeklySummaryPanel;
        private Panel weeklyDataPanel;
        private Panel chartPanel;
        private Panel dataPanel;
        private Label weeklyPointsAmtLabel;
        private Label weeklyPointsAmt;
        private System.Windows.Forms.DataVisualization.Charting.Chart weeklyDataChart;
        private Panel labelPanel;
        private Label weeklySummaryLabel;
    }
}