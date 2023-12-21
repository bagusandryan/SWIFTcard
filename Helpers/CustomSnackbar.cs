using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace SWIFTcard.Helpers
{
	public static class CustomSnackbar
	{
		public static async Task ShowCustomSnackbar(string text)
		{
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var resourceDictionary = App.Current.Resources.MergedDictionaries.First();

            var hasValue = resourceDictionary.TryGetValue("CardBackgroundColor", out object cardBackgroundColor);
            var hasValue2 = resourceDictionary.TryGetValue("CardBackgroundInvertedColor", out object cardInvertedBackgroundColor);
            var hasValue3 = resourceDictionary.TryGetValue("Primary", out object primaryColor);

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = hasValue &&  cardBackgroundColor is Color ?  (Color)cardBackgroundColor : Colors.White,
                TextColor = hasValue2 && cardInvertedBackgroundColor is Color ? (Color)cardInvertedBackgroundColor : Colors.Black,
                ActionButtonTextColor = hasValue2 && cardInvertedBackgroundColor is Color ? (Color)primaryColor : Colors.Pink,
                CornerRadius = new CornerRadius(30),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14)
            };

            string actionButtonText = "OK";

            var snackbar = Snackbar.Make(text, null, actionButtonText, null, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
	}
}

