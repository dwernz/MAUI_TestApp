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

	private async void TicTacToe(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("TicTacToe");
	}

	private void NationalDayMessageGenerator (object sender, EventArgs e)
	{
		DateTime today = DateTime.Today;
        NationalDay nationalDay = new NationalDay();

        int month = today.Month;
		int day = today.Day;
		int year = today.Year;
		DayOfWeek dayOfWeek = today.DayOfWeek;

		string monthString = nationalDay.GetMonthString(month);
		string dayEnding = nationalDay.GetDayEnding(day);

		string message = nationalDay.NationalDayMessage(month, day);
		lblNationalDay.Text = $"Today is {dayOfWeek}, {monthString} {day}{dayEnding}, {year}." + Environment.NewLine +
			$"It's {message} Day!";
	}
}

