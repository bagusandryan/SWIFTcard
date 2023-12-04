using System.ComponentModel;
using SWIFTcard.Models;
using CommunityToolkit.Maui.Extensions;
using SWIFTcard.ViewModels;

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
}


