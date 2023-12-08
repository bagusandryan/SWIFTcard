using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using AndroidX.AppCompat.App;
using SWIFTcard.Views;
using SWIFTcard.ViewModels;
using SWIFTcard.Services;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

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


        //Remove borders from Entry
        FormHandler.RemoveBorders();

        return builder.Build();
	}
}

public static class FormHandler
{
    public static void RemoveBorders()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }
}