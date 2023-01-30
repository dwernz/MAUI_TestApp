namespace TestApp;

public partial class Contact : ContentPage
{
	public Contact()
	{
		InitializeComponent();
	}

    private async void GoToWebsite(object sender, EventArgs e)
    {
        var url = "https://dwernzcv.azurewebsites.net";
        await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
    }

    private async void OnSendEmailButtonClicked(object sender, EventArgs e)
    {
        if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            var email = new EmailMessage
            {
                Subject = "Daniel's MAUI Test App",
                Body = "Hello Daniel," +
            Environment.NewLine + Environment.NewLine +
            "I wanted to contact you about your App.",
                To = { "dwernz@att.net" }
            };
            Email.ComposeAsync(email);
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            if (Email.Default.IsComposeSupported)
            {

                string subject = "Daniel's MAUI Test App";
                string body = "Hello Daniel," + 
                    Environment.NewLine + Environment.NewLine +
                    "I wanted to contact you about your app." + 
                    Environment.NewLine + Environment.NewLine;
                string[] recipients = new[] { "dwernz@att.net" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await Email.Default.ComposeAsync(message);
            }
        }
        
    }
}