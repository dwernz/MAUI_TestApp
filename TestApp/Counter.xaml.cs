namespace TestApp;

public partial class Counter : ContentPage
{
	int count = 0;

	public Counter()
	{
		InitializeComponent();
	}

	private void IncrementOne(object sender, EventArgs e)
	{
		string buttonClicked = btnIncrementOne.Text;
		
		count++;

		LblCountApp.Text = $"Count: {count}";
	}

    private void DecrementOne(object sender, EventArgs e)
    {
        string buttonClicked = btnDecrementOne.Text;

        count--;

        LblCountApp.Text = $"Count: {count}";
    }

    private void IncrementFive(object sender, EventArgs e)
    {
        string buttonClicked = btnIncrementFive.Text;

        count += 5;

        LblCountApp.Text = $"Count: {count}";
    }

    private void DecrementFive(object sender, EventArgs e)
    {
        string buttonClicked = btnDecrementFive.Text;

        count -= 5;

        LblCountApp.Text = $"Count: {count}";
    }

    private void IncrementTen(object sender, EventArgs e)
    {
        string buttonClicked = btnIncrementTen.Text;

        count += 10;

        LblCountApp.Text = $"Count: {count}";
    }

    private void DecrementTen(object sender, EventArgs e)
    {
        string buttonClicked = btnDecrementTen.Text;

        count -= 10;

        LblCountApp.Text = $"Count: {count}";
    }
}