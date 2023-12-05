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

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushModalAsync(new CardDetailPage());
    }
}


