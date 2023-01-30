namespace TestApp;

public partial class Counter : ContentPage
{
	// Initialize count to 0.
    int count = 0;

	public Counter()
	{
		InitializeComponent();
	}

	private void IncrementOne(object sender, EventArgs e)
	{
		count++;

		LblCountApp.Text = $"Count: {count}";
	}

    private void DecrementOne(object sender, EventArgs e)
    {
        count--;

        LblCountApp.Text = $"Count: {count}";
    }

    private void IncrementFive(object sender, EventArgs e)
    {
        count += 5;

        LblCountApp.Text = $"Count: {count}";
    }

    private void DecrementFive(object sender, EventArgs e)
    {
        count -= 5;

        LblCountApp.Text = $"Count: {count}";
    }

    private void IncrementTen(object sender, EventArgs e)
    {
        count += 10;

        LblCountApp.Text = $"Count: {count}";
    }

    private void DecrementTen(object sender, EventArgs e)
    {
        count -= 10;

        LblCountApp.Text = $"Count: {count}";
    }

    private async void AboutCounter(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AboutCounter");
    }
}