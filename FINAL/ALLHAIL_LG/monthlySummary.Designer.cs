namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class monthlySummary
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
            dataPanel = new Panel();
            dataPanel2 = new Panel();
            monthlyPointsAmt = new Label();
            monthlyPointsAmtLabel = new Label();
            monthlySummaryPanel = new Panel();
            monthlySummaryLabel = new Label();
            chartPanel = new Panel();
            monthlyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataPanel.SuspendLayout();
            dataPanel2.SuspendLayout();
            monthlySummaryPanel.SuspendLayout();
            chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)monthlyChart).BeginInit();
            SuspendLayout();
            // 
            // dataPanel
            // 
            dataPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dataPanel.Controls.Add(dataPanel2);
            dataPanel.Controls.Add(monthlySummaryPanel);
            dataPanel.Dock = DockStyle.Top;
            dataPanel.Location = new Point(0, 0);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(763, 68);
            dataPanel.TabIndex = 0;
            // 
            // dataPanel2
            // 
            dataPanel2.BackColor = Color.LightSkyBlue;
            dataPanel2.Controls.Add(monthlyPointsAmt);
            dataPanel2.Controls.Add(monthlyPointsAmtLabel);
            dataPanel2.Dock = DockStyle.Right;
            dataPanel2.Location = new Point(369, 0);
            dataPanel2.Name = "dataPanel2";
            dataPanel2.Size = new Size(394, 68);
            dataPanel2.TabIndex = 1;
            // 
            // monthlyPointsAmt
            // 
            monthlyPointsAmt.AutoSize = true;
            monthlyPointsAmt.Font = new Font("Consolas", 15F);
            monthlyPointsAmt.Location = new Point(327, 23);
            monthlyPointsAmt.Name = "monthlyPointsAmt";
            monthlyPointsAmt.Size = new Size(43, 23);
            monthlyPointsAmt.TabIndex = 3;
            monthlyPointsAmt.Text = "INT";
            // 
            // monthlyPointsAmtLabel
            // 
            monthlyPointsAmtLabel.Anchor = AnchorStyles.None;
            monthlyPointsAmtLabel.AutoSize = true;
            monthlyPointsAmtLabel.Font = new Font("Consolas", 15F);
            monthlyPointsAmtLabel.Location = new Point(3, 23);
            monthlyPointsAmtLabel.Name = "monthlyPointsAmtLabel";
            monthlyPointsAmtLabel.Size = new Size(318, 23);
            monthlyPointsAmtLabel.TabIndex = 1;
            monthlyPointsAmtLabel.Text = "Points collected this month:";
            // 
            // monthlySummaryPanel
            // 
            monthlySummaryPanel.Controls.Add(monthlySummaryLabel);
            monthlySummaryPanel.Dock = DockStyle.Left;
            monthlySummaryPanel.Location = new Point(0, 0);
            monthlySummaryPanel.Name = "monthlySummaryPanel";
            monthlySummaryPanel.Size = new Size(373, 68);
            monthlySummaryPanel.TabIndex = 0;
            // 
            // monthlySummaryLabel
            // 
            monthlySummaryLabel.Anchor = AnchorStyles.None;
            monthlySummaryLabel.AutoSize = true;
            monthlySummaryLabel.Font = new Font("Consolas", 15F);
            monthlySummaryLabel.Location = new Point(71, 23);
            monthlySummaryLabel.Name = "monthlySummaryLabel";
            monthlySummaryLabel.Size = new Size(241, 23);
            monthlySummaryLabel.TabIndex = 1;
            monthlySummaryLabel.Text = "Current month summary";
            monthlySummaryLabel.Click += weeklySummaryLabel_Click;
            // 
            // chartPanel
            // 
            chartPanel.Controls.Add(monthlyChart);
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(0, 68);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(763, 382);
            chartPanel.TabIndex = 1;
            // 
            // monthlyChart
            // 
            chartArea1.Name = "ChartArea1";
            monthlyChart.ChartAreas.Add(chartArea1);
            monthlyChart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            monthlyChart.Legends.Add(legend1);
            monthlyChart.Location = new Point(0, 0);
            monthlyChart.Name = "monthlyChart";
            monthlyChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            monthlyChart.Series.Add(series1);
            monthlyChart.Size = new Size(763, 382);
            monthlyChart.TabIndex = 0;
            monthlyChart.Text = "chart1";
            // 
            // monthlySummary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 450);
            Controls.Add(chartPanel);
            Controls.Add(dataPanel);
            Name = "monthlySummary";
            Text = "monthlySummary";
            dataPanel.ResumeLayout(false);
            dataPanel2.ResumeLayout(false);
            dataPanel2.PerformLayout();
            monthlySummaryPanel.ResumeLayout(false);
            monthlySummaryPanel.PerformLayout();
            chartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)monthlyChart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel dataPanel;
        private Panel dataPanel2;
        private Panel monthlySummaryPanel;
        private Panel chartPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart monthlyChart;
        private Label monthlySummaryLabel;
        private Label monthlyPointsAmtLabel;
        private Label monthlyPointsAmt;
    }
}