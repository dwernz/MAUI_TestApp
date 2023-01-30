namespace TestApp.About;

public partial class AboutCounter : ContentPage
{
	public AboutCounter()
	{
		InitializeComponent();
	}

	private void AboutCounterInformation(object sender, EventArgs e)
	{
		lblAboutCounter.Text = 
			"This is a simple counter app to help users keep track of a counter. " +
			Environment.NewLine + Environment.NewLine +
			"Users can increment or decrement the count by pressing the corresponding " +
			"buttons. Value can be changed in increments of 1, 5, or 10.";
	}
}