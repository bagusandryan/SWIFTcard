using Android.Content;
using AndroidX.Lifecycle;
using SWIFTcard.Models;
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

    async void AddNewDeck_OnClicked(System.Object sender, System.EventArgs e)
    {
        Deck deck = new Deck();
        deck.QuestionLang = Question.EntryText;
        deck.AnswerLang = Answer.EntryText;
        deck.Name = Name.EntryText;
        deck.Id = DateTime.Now.Ticks + "_" + deck.Name;

        await _viewModel.AddNewDeck(deck);

        Question.HideKeyboard();
        Answer.HideKeyboard();
        Name.HideKeyboard();

        await Task.Delay(150);

        await Navigation.PopModalAsync();
    }
}
