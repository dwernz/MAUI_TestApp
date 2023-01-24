namespace TestApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		Routing.RegisterRoute("SalesCalculator", typeof(SalesCalculator));
		Routing.RegisterRoute("TipCalculator", typeof(TipCalculator));
		Routing.RegisterRoute("Counter", typeof(Counter));
	}
}
