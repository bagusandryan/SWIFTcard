using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using AndroidX.AppCompat.App;
using SWIFTcard.Views;
using SWIFTcard.ViewModels;
using SWIFTcard.Services;

namespace SWIFTcard;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
            });
		// Initialize the .NET MAUI Community Toolkit by adding the below line of code
		builder.UseMauiCommunityToolkit();
        builder.Services.AddSingleton<Views.MainPage>();
        builder.Services.AddSingleton<ViewModels.MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        //Force Light Theme
        AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

        builder.Services.AddSingleton<CardService>();
        builder.Services.AddSingleton<DeckService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        return builder.Build();
	}
}

