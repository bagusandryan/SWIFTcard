using Microsoft.Maui.Controls;
using static Android.Preferences.PreferenceActivity;

namespace SWIFTcard.ContentViews;

public partial class BigEditor : ContentView
{
    bool _headerMovedUp;

    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(string), typeof(BigEditor), string.Empty);

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty EditorTextProperty = BindableProperty.Create(nameof(EditorText), typeof(string), typeof(BigEditor), string.Empty);

    public string EditorText
    {
        get => (string)GetValue(EditorTextProperty);
        set => SetValue(EditorTextProperty, value);
    }

    public BigEditor()
    {
        InitializeComponent();
    }

    async void TrueEditor_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (TrueEditor != null && !string.IsNullOrEmpty(TrueEditor.Text) && !TrueEditor.IsFocused)
        {
            await MoveHeaderUp();
        }
    }

    async void TrueEditor_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        await MoveHeaderUp();
    }

    async Task MoveHeaderUp()
    {
        if (!_headerMovedUp)
        {
            _ = HeaderLabel.TranslateTo(-37, -35);
            await HeaderLabel.ScaleTo(0.5);
            _headerMovedUp = true;
        }
    }

    async void TrueEditor_Unfocused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        if (TrueEditor != null && string.IsNullOrWhiteSpace(TrueEditor.Text) && _headerMovedUp)
        {
            _ = HeaderLabel.TranslateTo(0, 0);
            await HeaderLabel.ScaleTo(1);
            _headerMovedUp = false;
        }
    }
}
