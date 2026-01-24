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
    public partial class monthlySummary : Form
    {
        public monthlySummary()
        {
            InitializeComponent();
            LoadMonthlyData();
        }

        private void LoadMonthlyData()
        {
            int totalPoints = 0;

            int[] weeklyPoints = new int[5];
            string[] weekLabels = { "Tydz 1", "Tydz 2", "Tydz 3", "Tydz 4", "Tydz 5" };

            using (var db = new ActivityContext())
            {
                DateTime now = DateTime.Now;
                int currentMonth = now.Month;
                int currentYear = now.Year;

                // Pobieramy wszystkie zadania z tego miesiąca
                var tasks = db.ProjectTasks
                    .Where(t => t.Status == Status.Completed
                             && t.EndDate.HasValue
                             && t.EndDate.Value.Month == currentMonth
                             && t.EndDate.Value.Year == currentYear)
                    .ToList();

                // Zliczamy punkty i przypisujemy do odpowiedniego tygodnia
                foreach (var task in tasks)
                {
                    int day = task.EndDate.Value.Day;
                    int weekIndex = (day - 1) / 7;

                    if (weekIndex < 5)
                    {
                        weeklyPoints[weekIndex] += 50; // 50 pkt za zadanie
                        totalPoints += 50;
                    }
                }
            }

            // 1. Ustawiamy Label z sumą punktów 
            Control lbl = this.Controls.Find("monthlyPointsAmt", true).FirstOrDefault();
            if (lbl != null) lbl.Text = totalPoints.ToString();
            else
            {
                foreach (Control c in this.Controls)
                    if (c is Label && c.Name.Contains("Points")) c.Text = totalPoints.ToString();
            }

            CreateOrUpdateChart(weeklyPoints, weekLabels);
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
            Series series = new Series("PunktyMiesiac");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.MediumSeaGreen;
            series.IsValueShownAsLabel = true;

            for (int i = 0; i < data.Length; i++)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(labels[i], data[i]);
                series.Points.Add(p);
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void weeklySummaryLabel_Click(object sender, EventArgs e) { }

        private void monthlyPointsAmtLabel_Click(object sender, EventArgs e)
        {

        }

        private void dataPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
