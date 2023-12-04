using CommunityToolkit.Maui.Extensions;

namespace SWIFTcard.ContentViews;

public partial class CardView : ContentView
{
    public static readonly BindableProperty IsBackProperty = BindableProperty.Create(nameof(IsBack), typeof(bool), typeof(CardView), false);

    public bool IsBack
    {
        get => (bool)GetValue(IsBackProperty);
        set => SetValue(IsBackProperty, value);
    }

    public static readonly BindableProperty FrontHeaderProperty = BindableProperty.Create(nameof(FrontHeader), typeof(string), typeof(CardView), string.Empty);

    public string FrontHeader
    {
        get => (string)GetValue(FrontHeaderProperty);
        set => SetValue(FrontHeaderProperty, value);
    }

    public static readonly BindableProperty FrontFooterProperty = BindableProperty.Create(nameof(FrontFooter), typeof(string), typeof(CardView), string.Empty);

    public string FrontFooter
    {
        get => (string)GetValue(FrontFooterProperty);
        set => SetValue(FrontFooterProperty, value);
    }

    public static readonly BindableProperty BackHeaderProperty = BindableProperty.Create(nameof(BackHeader), typeof(string), typeof(CardView), string.Empty);

    public string BackHeader
    {
        get => (string)GetValue(BackHeaderProperty);
        set => SetValue(BackHeaderProperty, value);
    }

    public static readonly BindableProperty BackFooterProperty = BindableProperty.Create(nameof(BackFooter), typeof(string), typeof(CardView), string.Empty);

    public string BackFooter
    {
        get => (string)GetValue(BackFooterProperty);
        set => SetValue(BackFooterProperty, value);
    }

    public static readonly BindableProperty BackContextProperty = BindableProperty.Create(nameof(BackContext), typeof(string), typeof(CardView), string.Empty);

    public string BackContext
    {
        get => (string)GetValue(BackContextProperty);
        set => SetValue(BackContextProperty, value);
    }

    public CardView()
	{
		InitializeComponent();
	}

    async void RevealIcon_Clicked(System.Object sender, System.EventArgs e)
    {
        var resourceDictionary = App.Current.Resources.MergedDictionaries.First();

        //If front then switch to back
        if (!IsBack)
        {
            var hasValue = resourceDictionary.TryGetValue("CardBackgroundBrush", out object whiteColor);

            if (hasValue && whiteColor is SolidColorBrush brush)
            {
                _ = HeaderLabel.TextColorTo(brush.Color, 16, 500, Easing.SinInOut);
                _ = FooterLabel.TextColorTo(brush.Color, 16, 500, Easing.SinInOut);
            }
            else
            {
                _ = HeaderLabel.TextColorTo(Colors.White, 16, 500, Easing.SinInOut);
                _ = FooterLabel.TextColorTo(Colors.White, 16, 500, Easing.SinInOut);
            }

            IsBack = true;
            _ = EllipseAnimation.ScaleTo(14, 500, Easing.SinInOut);

            await Task.Delay(300);

            HeaderLabel.SetBinding(Label.TextProperty, new Binding(nameof(BackHeader)));
            FooterLabel.SetBinding(Label.TextProperty, new Binding(nameof(BackFooter)));
        }
        //If back then switch to front
        else
        {
            var hasValue = resourceDictionary.TryGetValue("CardBackgroundInvertedBrush", out object blackColor);

            if (hasValue && blackColor is SolidColorBrush brush)
            {
                _ = HeaderLabel.TextColorTo(brush.Color, 16, 500, Easing.SinInOut);
                _ = FooterLabel.TextColorTo(brush.Color, 16, 500, Easing.SinInOut);
            }
            else
            {
                _ = HeaderLabel.TextColorTo(Colors.Black, 16, 500, Easing.SinInOut);
                _ = FooterLabel.TextColorTo(Colors.Black, 16, 500, Easing.SinInOut);
            }

            IsBack = false;
            _ = EllipseAnimation.ScaleTo(0, 500, Easing.SinInOut);

            await Task.Delay(300);

            HeaderLabel.SetBinding(Label.TextProperty, new Binding(nameof(FrontHeader)));
            FooterLabel.SetBinding(Label.TextProperty, new Binding(nameof(FrontFooter)));
        }
    }
}
