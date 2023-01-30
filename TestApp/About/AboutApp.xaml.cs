namespace TestApp.About;

public partial class AboutApp : ContentPage
{
	public AboutApp()
	{
		InitializeComponent();
	}

	public void AboutInfomation(object sender, EventArgs e)
	{
        lblAboutInformation.Text = 
            "This app is mainly used for testing and skill development. " +
            Environment.NewLine + Environment.NewLine +
            "Being a more novice programmer, I am using this app to build " +
            "fundamental skills with MAUI, .NET, and C#. Most applications " +
            "are made for my family or myself, but can be useful to others. " +
            Environment.NewLine + Environment.NewLine +
            "So far the applications I have made are Sales Calculator, " +
            "Tip Calculator, Counter, Hour Calculator, Fizz Buzz Number " +
            "Generator, Math Quiz, Tic Tac Toe, Shopping Total, and Dice. " +
            Environment.NewLine + Environment.NewLine +
            "Each app has an about page under the help menu to explain the application" +
            Environment.NewLine + Environment.NewLine +
            "Please contact Daniel at dwernz@att.net for any bugs, issues, suggestions, " +
            "or questions."
            ;
    }
}