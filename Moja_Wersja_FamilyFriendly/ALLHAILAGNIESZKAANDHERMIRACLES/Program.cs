
//Program.cs
using Activity.Domain.Data;
namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {
            using (var db = new ActivityContext())
            {
                // Ta linijka sprawdza: "Czy baza istnieje? Czy ma tabele?"
                // Jeœli nie -> Tworzy plik i zak³ada w nim wszystkie tabele (Projects, Tasks itd.)
                db.Database.EnsureCreated();
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}