using System.Collections.ObjectModel;

namespace TestApp;

public partial class FizzBuzzNumberGenerator : ContentPage
{
	
	public FizzBuzzNumberGenerator()
	{
		InitializeComponent();

		

    }

	public void GenerateFizzBuzz(object sender, EventArgs e)
	{

        int maxNumber = Convert.ToInt32(txtMaxNumber.Text);

        ObservableCollection<string> fizzBuzz = new ObservableCollection<string>();
        for (int i = 1; i <= maxNumber; i++)
        {
            if (i % 15 == 0)
                fizzBuzz.Add("FizzBuzz");
            else if (i % 3 == 0)
                fizzBuzz.Add("Fizz");
            else if (i % 5 == 0)
                fizzBuzz.Add("Buzz");
            else
                fizzBuzz.Add(i.ToString());
        }
        fizzBuzzBox.ItemsSource = fizzBuzz;
    }
	
}