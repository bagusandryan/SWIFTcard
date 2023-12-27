using System;
using Android.App;

namespace SWIFTcard.Helpers
{
	public static class UI
	{
        public static void UpdateNavigationBarColor(bool isModalOpen)
        {
            var resourceDictionary = App.Current.Resources.MergedDictionaries.FirstOrDefault();
            Activity activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
            if (resourceDictionary != null && activity != null)
            {
                var hasValue = resourceDictionary.TryGetValue(isModalOpen ? "Gray300" : "AppBackgroundColor", out object backgroundColor);
                if (hasValue && backgroundColor is Color color)
                {
                    activity.Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
                }
                return;
            }
            activity.Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor(isModalOpen ? "#ACACAC" : "#FAFAFA"));
        }
    }
}

