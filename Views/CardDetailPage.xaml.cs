using CommunityToolkit.Maui.Core;
using System.Threading;
using SWIFTcard.Models;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Maui.Alerts;
using AndroidX.Lifecycle;
using SWIFTcard.ViewModels;

namespace SWIFTcard.Views;

public partial class CardDetailPage : ContentPage
{
    private CardDetailViewModel _viewModel;

    public CardDetailPage(CardDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void OnSwipedDown(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void AddNewCard(System.Object sender, System.EventArgs e)
    {
        Card newCard = new Card();
        newCard.Question = Question.EntryText;
        newCard.Answer = Answer.EntryText;
        newCard.Context = Context.EntryText;
        newCard.Deck = _viewModel.GetActiveDeck();

        Question.HideKeyboard();
        Answer.HideKeyboard();
        Context.HideKeyboard();

        _viewModel.AddNewCard(newCard);

        var snackbar = Snackbar.Make($"{newCard.Question} card added");
        await snackbar.Show();

        Question.EntryText = string.Empty;
        Answer.EntryText = string.Empty;
        Context.EntryText = string.Empty;

        Question.FocusKeyboard();
    }
}
