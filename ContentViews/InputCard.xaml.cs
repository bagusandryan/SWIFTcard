namespace SWIFTcard.ContentViews;

public partial class InputCard : ContentView
{
    public static readonly BindableProperty CardHeightProperty = BindableProperty.Create(nameof(CardHeight), typeof(double), typeof(InputCard), double.NaN);

    public double CardHeight
    {
        get => (double)GetValue(CardHeightProperty);
        set => SetValue(CardHeightProperty, value);
    }

    public static readonly BindableProperty IsMultipleLinesProperty = BindableProperty.Create(nameof(IsMultipleLines), typeof(bool), typeof(BigEntry), false);

    public bool IsMultipleLines
    {
        get => (bool)GetValue(IsMultipleLinesProperty);
        set => SetValue(IsMultipleLinesProperty, value);
    }

    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(string), typeof(InputCard), string.Empty);

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(InputCard), string.Empty);

    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    public void HideKeyboard()
    {
        if(!IsMultipleLines)
        {
            BigEntry.HideKeyboard();
        }
        else
        {
            BigEditor.HideKeyboard();
        }
    }

    public InputCard()
	{
		InitializeComponent();
	}
}
