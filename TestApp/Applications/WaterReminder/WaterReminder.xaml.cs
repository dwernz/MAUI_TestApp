using SQLite;
using System.ComponentModel;

namespace TestApp.Applications;

public partial class WaterReminder : ContentPage
{
	public WaterReminder()
	{
		InitializeComponent();
		pickFrequency.SelectedIndex = 2;
	}

	public class WaterFrequency : INotifyPropertyChanged
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime WakeUpTime { get; set; }
        public DateTime BedTime { get; set; }
        public bool Notifications { get;set; }
        public int OzToDrink { get; set; }
        public int FrequencyIndex { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

	public static class WaterService
	{
		static SQLiteAsyncConnection db;

		static async Task Init()
		{
            // Get an absolute path to the database file
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "WaterFrequency.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<WaterFrequency>();
        }
	}

}