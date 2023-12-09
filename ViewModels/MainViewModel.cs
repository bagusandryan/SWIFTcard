using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWIFTcard.Models;
using SWIFTcard.Services;
using SWIFTcard.Views;

namespace SWIFTcard.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Deck> _deckList;

        [ObservableProperty]
        List<Card> _cardList;
       
        [ObservableProperty]
        bool _isModalOpen;

        CardService _cardService;
        DeckService _deckService;

        public MainViewModel(CardService cardService, DeckService deckService)
        {
            _cardService = cardService;
            _deckService = deckService;
            _ = InitialLoadAsync();
        }

        public async Task InitialLoadAsync()
        {
            await LoadAllDecksAsync();
            await LoadAllCardsAsync();
        }

        public async Task LoadAllCardsAsync()
        {
            if (_cardService == null) return;
            CardList = await _cardService.GetCardsAsync(_deckService.GetActiveDeck());
        }

        public async Task LoadAllDecksAsync()
        {
            if (_deckService == null) return;
            DeckList = await _deckService.GetDecksAsync();
            if (_deckService.GetActiveDeck() == null && DeckList != null && DeckList.Count > 0)
            {
                var activeDeck = DeckList.FirstOrDefault(item => item.IsActive);

                if (activeDeck == null) activeDeck = DeckList[0];

                SetActiveDeck(activeDeck);
            }
        }

        public void SetActiveDeck(Deck deck)
        {
            _deckService.SetActiveDeck(deck);
        }

        [RelayCommand]
        void Appearing()
        {
            UpdateStatusBarColor("AppBackgroundColor", StatusBarStyle.DarkContent);
            IsModalOpen = false;
        }

        void UpdateStatusBarColor(string colorKey, StatusBarStyle statusBarStyle)
        {
            var rd = App.Current.Resources.MergedDictionaries.First();
            AppShell.Current.Behaviors.Add(new StatusBarBehavior
            {
                StatusBarColor = (Color)rd[colorKey],
                StatusBarStyle = statusBarStyle
            });
        }

        [RelayCommand]
        async Task AddNewCard()
        {
            IsModalOpen = true;
            UpdateStatusBarColor("Gray300", StatusBarStyle.LightContent);
            await App.Current.MainPage.Navigation.PushModalAsync(new CardDetailPage(new CardDetailViewModel(_cardService, _deckService)));
        }
    }
}

