using System.Collections.ObjectModel;
using AndroidX.Lifecycle;
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
        ObservableCollection<Deck> _deckList;

        [ObservableProperty]
        ObservableCollection<Card> _cardList;
       
        [ObservableProperty]
        bool _isModalOpen;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsAnyDeckOrCardLoaded))]
        bool _isAnyCardLoaded;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsAnyDeckOrCardLoaded))]
        bool _isAnyDeckLoaded;

        public bool IsAnyDeckOrCardLoaded => IsAnyCardLoaded || IsAnyDeckLoaded;

        CardService _cardService;
        DeckService _deckService;

        Frame _menu;

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
            if (_cardService == null || _deckService == null || _deckService.GetActiveDeck() == null)
            {
                IsAnyCardLoaded = false;
                return;
            }

            CardList = await _cardService.GetCardsAsync(_deckService.GetActiveDeck());
            IsAnyCardLoaded = true;
        }

        public async Task LoadAllDecksAsync()
        {
            if (_deckService == null)
            {
                IsAnyDeckLoaded = false;
                return;
            }
            DeckList = await _deckService.GetDecksAsync();
            if (_deckService.GetActiveDeck() == null && DeckList != null && DeckList.Count > 0)
            {
                var activeDeck = DeckList.FirstOrDefault(item => item.IsActive);

                if (activeDeck == null) activeDeck = DeckList[0];

                SetActiveDeck(activeDeck);
                IsAnyCardLoaded = true;
            }
        }

        public void SetActiveDeck(Deck deck)
        {
            _deckService.SetActiveDeck(deck);
        }

        [RelayCommand]
        async Task Appearing()
        {
            SetModal(false);
            await LoadAllCardsAsync();
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
            SetModal(true);
            CardDetailViewModel cardDetailViewModel = new CardDetailViewModel(_cardService, _deckService);
            cardDetailViewModel.IsAddMode = true;
            await App.Current.MainPage.Navigation.PushModalAsync(new CardDetailPage(cardDetailViewModel));
        }

        [RelayCommand]
        async Task ShowAllCards()
        {
            SetModal(true);
            CardDetailViewModel cardDetailViewModel = new CardDetailViewModel(_cardService, _deckService);
            cardDetailViewModel.IsAddMode = false;
            await App.Current.MainPage.Navigation.PushModalAsync(new CardDetailPage(cardDetailViewModel));
            await HideMenu();
        }

        [RelayCommand]
        async Task ShowDecks()
        {
            SetModal(true);
            ManageDecksViewModel manageDecksViewModel = new ManageDecksViewModel(_cardService, _deckService);
            await App.Current.MainPage.Navigation.PushModalAsync(new ManageDecksPage(manageDecksViewModel));
            await HideMenu();
        }

        [RelayCommand]
        async Task ShowMenu(Frame Menu)
        {
            _menu = Menu;
            if (!_menu.IsVisible)
            {
                _menu.IsVisible = true;
                _ = _menu.ScaleTo(1, 250);
                await Task.Delay(100);
                SetModal(true);
                return;
            }
            SetModal(false);
            await HideMenu();
        }

        [RelayCommand]
        void ReloadDeck()
        {
            _ = InitialLoadAsync();
        }

        async Task HideMenu()
        {
            if (_menu == null) return;
            _ = _menu.ScaleTo(0, 250);
            await Task.Delay(100);
            SetModal(IsModalOpen);
            _menu.IsVisible = false;
        }

        void SetModal(bool isOpen)
        {
            IsModalOpen = isOpen;
            if (IsModalOpen)
            {
                UpdateStatusBarColor("Gray300", StatusBarStyle.LightContent);
            }
            else
            {
                UpdateStatusBarColor("AppBackgroundColor", StatusBarStyle.DarkContent);
            }
        }
    }
}

