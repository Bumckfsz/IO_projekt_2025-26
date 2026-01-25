//weeklySummary.cs
using Activity.Domain.Models;
using Activity.Domain.Data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class weeklySummary : Form
    {
        public weeklySummary()
        {
            InitializeComponent();
            LoadWeeklyData();
        }

        private void LoadWeeklyData()
        {
            int totalPoints = 0;

            int[] dailyPoints = new int[7];
            string[] dayLabels = new string[7];

            using (var db = new ActivityContext())
            {
                DateTime today = DateTime.Today;

                for (int i = 0; i < 7; i++)
                {
                    DateTime checkDate = today.AddDays(-6 + i);
                    dayLabels[i] = checkDate.ToString("ddd");

                    int count = db.ProjectTasks
                        .Where(t => t.Status == Status.Completed
                                 && t.EndDate.HasValue
                                 && t.EndDate.Value.Date == checkDate)
                        .Count();

                    int points = count * 50; 
                    dailyPoints[i] = points;
                    totalPoints += points;
                }
            }

            Control lbl = this.Controls.Find("weeklyPointsAmt", true).FirstOrDefault();
            if (lbl != null) lbl.Text = totalPoints.ToString();
            else
            {
                if (weeklySummaryLabel != null) weeklySummaryLabel.Text = totalPoints.ToString();
            }

            CreateOrUpdateChart(dailyPoints, dayLabels);
        }

        private void CreateOrUpdateChart(int[] data, string[] labels)
        {
            Chart chart = this.Controls.OfType<Chart>().FirstOrDefault();

            if (chart == null)
            {
                chart = new Chart();
                chart.Parent = this;
                chart.Dock = DockStyle.Bottom; 
                chart.Height = 200;
                chart.ChartAreas.Add(new ChartArea("MainArea"));
            }

            chart.Series.Clear();
            Series series = new Series("Punkty");
            series.ChartType = SeriesChartType.Column; 
            series.Color = Color.CornflowerBlue;
            series.IsValueShownAsLabel = true; 

            for (int i = 0; i < data.Length; i++)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(labels[i], data[i]);
                p.ToolTip = $"{labels[i]}: {data[i]} pkt";
                series.Points.Add(p);
            }

            chart.Series.Add(series);

            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.Interval = 1;
        }

        private void weeklySummaryLabel_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void weeklyDataChart_Click(object sender, EventArgs e)
        {

        }
    }
}
