namespace TestApp;

public partial class PrivacyPage : ContentPage
{
	public PrivacyPage()
	{
		InitializeComponent();
	}

    private async void GoToPrivacyPage(object sender, EventArgs e)
    {
        var url = "https://dwernzcv.azurewebsites.net/MauiTestAppPrivacy";
        await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
    }
}