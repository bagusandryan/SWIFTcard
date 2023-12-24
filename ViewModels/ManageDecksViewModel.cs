using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using SWIFTcard.Models;
using SWIFTcard.Services;
using SWIFTcard.Views;

namespace SWIFTcard.ViewModels
{
    public partial class ManageDecksViewModel : ObservableObject
    {
        CardService _cardService;
        DeckService _deckService;

        [ObservableProperty]
        ObservableCollection<Deck> _deckList;

        [ObservableProperty]
        ObservableCollection<Card> _cardList;

        public ManageDecksViewModel(CardService cardService, DeckService deckService)
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

        public async Task LoadAllDecksAsync()
        {
            if (_deckService == null)
            {
                return;
            }
            DeckList = await _deckService.GetDecksAsync();
        }

        public async Task LoadAllCardsAsync()
        {
            if (_cardService == null || _deckService == null || _deckService.GetActiveDeck() == null)
            {
                return;
            }

            CardList = await _cardService.GetCardsAsync(_deckService.GetActiveDeck());

            if (CardList == null) return;

            foreach(Deck item in DeckList)
            {
                if (item.Id == CardList[0].Deck.Id)
                {
                    item.DeckInfo = CardList.Count.ToString() + " cards";
                    break;
                }
            }
        }

        public async Task AddNewDeck()
        {
            AddDeckViewModel addDeckViewModel = new AddDeckViewModel(_deckService);
            await App.Current.MainPage.Navigation.PushModalAsync(new AddDeckPage(addDeckViewModel));
        }
    }
}

