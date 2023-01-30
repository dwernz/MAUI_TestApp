using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestApp.Applications;

public partial class Dice : ContentPage
{
    public ObservableCollection<PreviousNumber> previousNumbers { get; set; } = new ObservableCollection<PreviousNumber>();

    public Dice()
	{
		InitializeComponent();
        BindingContext = this;

        // Default to 6-sided die
        pickNumberOfSides.SelectedIndex = 2;
	}

    private static Random _generator = new Random();

    private void RollDice(object sender, EventArgs e)
    {
        // get picker
        var picker = pickNumberOfSides;
        // get the selectedIndex
        int selectedIndex = picker.SelectedIndex;

        // if nothing is selected
        if (selectedIndex.ToString() == "" || selectedIndex == -1)
        {
            DisplayAlert("Error", "Please select number of sides", "Ok");
            return;
        }

        // get the number of sides of the die
        int numOfSides = (int)picker.ItemsSource[selectedIndex];

        // generate a random number between 1 and number of sides.
        int rolledNumber = NumberBetween(numOfSides);

        // display the result
        lblRollResult.Text = rolledNumber.ToString();


        var prevNumber = new PreviousNumber { NumOfSides = numOfSides, RollResult = rolledNumber };

        previousNumbers.Insert(0, prevNumber);
    }
        

    public static int NumberBetween(int maximumValue)
    {
        return _generator.Next(1, maximumValue + 1);
    }

    public class PreviousNumber : INotifyPropertyChanged
    {
        public int NumOfSides { get; set; }
        public int RollResult { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private async void AboutDice(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AboutDice");
    }
}