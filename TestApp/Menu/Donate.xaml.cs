namespace TestApp;

public partial class Donate : ContentPage
{
	public Donate()
	{
		InitializeComponent();
	}

	private void DonateText(object sender, EventArgs e)
	{
		lblDonateText.Text =
            "Thank you for considering a donation to support the development of more " +
			"applications. Your contribution will help Daniel to continue creating " +
			"useful and innovative programs for you to enjoy. Whether it's a small or " +
			"large donation, every bit helps in the pursuit of creating high-quality, " +
			"user-friendly software. Your generosity is greatly appreciated and will " +
			"help to ensure that the developer can continue to provide you with the " +
			"best applications possible. Thank you for your support!";
	}
	private async void GoToDonationPage(object sender, EventArgs e)
    {
        var url = "https://www.paypal.com/donate?business=SDBV8BK2G5NQ8&item_name=Every little bit helps and I am truly grateful for your support. Thank you for helping me make a difference.&currency_code=USD";
        await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
    }
}