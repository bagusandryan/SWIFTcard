namespace SWIFTcard;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		//Force Light Theme
        Current.UserAppTheme = AppTheme.Light;
    }
}

