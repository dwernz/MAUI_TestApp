using TestApp.Applications;
using TestApp.About;

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
		Routing.RegisterRoute("HourCalculator", typeof(HourCalculator));
		Routing.RegisterRoute("FizzBuzzNumberGenerator", typeof(FizzBuzzNumberGenerator));
        Routing.RegisterRoute("MathQuiz", typeof(MathQuiz));
        Routing.RegisterRoute("TicTacToe", typeof(TicTacToe));
		Routing.RegisterRoute("ShoppingTotal", typeof(ShoppingTotal));
		Routing.RegisterRoute("Dice", typeof(Dice));
        Routing.RegisterRoute("AboutApp", typeof(AboutApp));
		Routing.RegisterRoute("AboutCounter", typeof(AboutCounter));
        Routing.RegisterRoute("AboutFizzBuzz", typeof(AboutFizzBuzz));
        Routing.RegisterRoute("AboutHours", typeof(AboutHours));
        Routing.RegisterRoute("AboutMathQuiz", typeof(AboutMathQuiz));
        Routing.RegisterRoute("AboutShoppingTotal", typeof(AboutShoppingTotal));
        Routing.RegisterRoute("AboutTicTacToe", typeof(AboutTicTacToe));
        Routing.RegisterRoute("AboutTipCalc", typeof(AboutTipCalc));
        Routing.RegisterRoute("AboutDice", typeof(AboutDice));
        Routing.RegisterRoute("PrivacyPage", typeof(PrivacyPage));
        Routing.RegisterRoute("Contact", typeof(Contact));
        Routing.RegisterRoute("Donate", typeof(Donate));
        Routing.RegisterRoute("ShoppingList", typeof(ShoppingList));
    }
}
