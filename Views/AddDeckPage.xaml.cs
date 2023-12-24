using AndroidX.Lifecycle;
using SWIFTcard.ViewModels;

namespace SWIFTcard.Views;

public partial class AddDeckPage : ContentPage
{
    AddDeckViewModel _viewModel;

	public AddDeckPage(AddDeckViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void OnSwipedDown(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
