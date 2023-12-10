using System.ComponentModel;
using SWIFTcard.Models;
using CommunityToolkit.Maui.Extensions;
using SWIFTcard.ViewModels;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using AndroidX.Core.Graphics;

namespace SWIFTcard.Views;

public partial class MainPage : ContentPage
{
    private MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void ShowMenu(System.Object sender, System.EventArgs e)
    {
        if (!Menu.IsVisible)
        {
            Menu.IsVisible = true;
            _ = Menu.ScaleTo(1, 250);
            await Task.Delay(100);
            _viewModel.IsModalOpen = true;
            return;
        }
        _ = Menu.ScaleTo(0, 250);
        await Task.Delay(100);
        _viewModel.IsModalOpen = false;
        Menu.IsVisible = false;
    }
}


