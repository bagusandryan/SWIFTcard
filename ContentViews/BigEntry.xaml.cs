﻿using Microsoft.Maui.Controls;
using static Android.Preferences.PreferenceActivity;

namespace SWIFTcard.ContentViews;

public partial class BigEntry : ContentView
{
    bool _headerMovedUp;

    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(string), typeof(BigEntry), string.Empty);

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(BigEntry), string.Empty);

    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    public BigEntry()
	{
		InitializeComponent();
	}

    async void TrueEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (TrueEntry != null && !string.IsNullOrEmpty(TrueEntry.Text) && !TrueEntry.IsFocused)
        {
            await MoveHeaderUp();
        }
    }

    async void TrueEntry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        await MoveHeaderUp();
    }

    async Task MoveHeaderUp()
    {
        if (!_headerMovedUp)
        {
            _ = HeaderLabel.TranslateTo(0, -14);
            await HeaderLabel.ScaleTo(0.5);
            _headerMovedUp = true;
        }
    }

    async void TrueEntry_Unfocused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        if (TrueEntry != null && string.IsNullOrWhiteSpace(TrueEntry.Text) && _headerMovedUp)
        {
            _ = HeaderLabel.TranslateTo(0, 0);
            await HeaderLabel.ScaleTo(1);
            _headerMovedUp = false;
        }
    }
}
