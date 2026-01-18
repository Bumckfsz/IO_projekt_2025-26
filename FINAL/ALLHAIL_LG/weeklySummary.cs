//weeklySummary.cs
using Activity.Domain.Models;
using Activity.Domain.Data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Potrzebne do wykresów

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

            // Tablica na punkty z 7 dni (indeks 0 = dzisiaj, 1 = wczoraj...)
            // Albo lepiej: Indeks 0 = 6 dni temu, Indeks 6 = Dzisiaj (chronologicznie)
            int[] dailyPoints = new int[7];
            string[] dayLabels = new string[7];

            using (var db = new ActivityContext())
            {
                DateTime today = DateTime.Today;

                // Pętla od 6 dni temu do dzisiaj
                for (int i = 0; i < 7; i++)
                {
                    // Data, którą sprawdzamy (zaczynamy od najstarszej)
                    DateTime checkDate = today.AddDays(-6 + i);
                    dayLabels[i] = checkDate.ToString("ddd"); // np. "Pon", "Wt"

                    // Pobieramy zadania ukończone TEGO KONKRETNEGO DNIA
                    int count = db.ProjectTasks
                        .Where(t => t.Status == Status.Completed
                                 && t.EndDate.HasValue
                                 && t.EndDate.Value.Date == checkDate)
                        .Count();

                    int points = count * 50; // 50 pkt za zadanie
                    dailyPoints[i] = points;
                    totalPoints += points;
                }
            }

            //  Ustawiamy Label z sumą punktów (Twój label)
            // Szukamy labela po nazwie, żeby uniknąć błędu kompilacji jeśli go nie ma
            Control lbl = this.Controls.Find("weeklyPointsAmt", true).FirstOrDefault();
            if (lbl != null) lbl.Text = totalPoints.ToString();
            else
            {
                // Fallback jeśli nazwa w designerze jest inna
                if (weeklySummaryLabel != null) weeklySummaryLabel.Text = totalPoints.ToString();
            }

            // 2. Rysujemy Wykres (Chart)
            CreateOrUpdateChart(dailyPoints, dayLabels);
        }

        private void CreateOrUpdateChart(int[] data, string[] labels)
        {
            // Sprawdzamy, czy masz już Chart w designerze
            Chart chart = this.Controls.OfType<Chart>().FirstOrDefault();

            // Jeśli nie ma, tworzymy go kodem (żebyś widział efekt od razu)
            if (chart == null)
            {
                chart = new Chart();
                chart.Parent = this;
                chart.Dock = DockStyle.Bottom; // Przypnij do dołu
                chart.Height = 200;
                chart.ChartAreas.Add(new ChartArea("MainArea"));
            }

            chart.Series.Clear();
            Series series = new Series("Punkty");
            series.ChartType = SeriesChartType.Column; // Wykres słupkowy
            series.Color = Color.CornflowerBlue;
            series.IsValueShownAsLabel = true; // Pokaż wartości nad słupkami

            // Wrzucamy dane
            for (int i = 0; i < data.Length; i++)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(labels[i], data[i]);
                p.ToolTip = $"{labels[i]}: {data[i]} pkt";
                series.Points.Add(p);
            }

            chart.Series.Add(series);

            // Stylizacja osi
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.Interval = 1;
        }

        // Puste metody designera
        private void weeklySummaryLabel_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
