//UserControl3.cs
using System;
using System.Windows.Forms;
// Alias dla Activity z bazy danych
using DomainActivity = Activity.Domain.Models.Activity;

namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    public partial class UIActivityObject : UserControl
    {
        // Dane z bazy
        public DomainActivity ActivityData { get; private set; }

        public UIActivityObject()
        {
            InitializeComponent();
        }

        //  konstruktor przyjmujący dane z bazy
        public UIActivityObject(DomainActivity activity) : this()
        {
            ActivityData = activity;

            // Formatowanie tekstu: Data + Opis

            string displayText = $"[{activity.Date.ToShortTimeString()}] {activity.Description}";
            activityBox.Text = displayText;


        }

        private void activityBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}