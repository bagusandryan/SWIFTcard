using AndroidX.Lifecycle;
using SWIFTcard.ViewModels;

namespace SWIFTcard.Views;

public partial class ManageDecksPage : ContentPage
{
	private ManageDecksViewModel _viewModel;


    public ManageDecksPage(ManageDecksViewModel manageDecksViewModel)
	{
		InitializeComponent();
		_viewModel = manageDecksViewModel;
		BindingContext = _viewModel;
    }

    async void OnSwipedDown(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void AddNewDeck(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await _viewModel.AddNewDeck();
        BackdropGrid.IsVisible = true;
    }

    void ContentPage_Appearing(System.Object sender, System.EventArgs e)
    {
        BackdropGrid.IsVisible = false;
    }
}
