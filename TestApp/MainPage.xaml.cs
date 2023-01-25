namespace TestApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void SalesCalculator(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("SalesCalculator");
	}

	private async void TipCalculator(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("TipCalculator");
	}

	private async void Counter(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Counter");
	}

	private async void HourCalculator(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("HourCalculator");
	}

	private async void FizzBuzzNumberGenerator(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("FizzBuzzNumberGenerator");
    }
	private async void MathQuiz(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("MathQuiz");
    }
}

