using AndroidX.Lifecycle;
using SWIFTcard.ContentViews;
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

    void DecksFlexLayout_Loaded(System.Object sender, System.EventArgs e)
    {
        foreach(var item in _viewModel.DeckList)
        {
            DeckView deckView = new DeckView();
            deckView.QuestionHeader = item.Name;
            deckView.InfoFooter = item.DeckInfo;
            deckView.IsActive = item.IsActive;
            deckView.Margin = new Thickness(
                _viewModel.DeckList.IndexOf(item) % 2 != 0 ? 10 : 0, _viewModel.DeckList.IndexOf(item) != 0 ? 2 : 0, 0, 2);
            DecksFlexLayout.Add(deckView);
        }
      
    }
}
