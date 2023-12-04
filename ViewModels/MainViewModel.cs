 using CommunityToolkit.Mvvm.ComponentModel;
using SWIFTcard.Models;
using SWIFTcard.Services;

namespace SWIFTcard.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Deck> _deckList;

        [ObservableProperty]
        List<Card> _cardList;

        [ObservableProperty]
        Deck _activeDeck;

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
            CardList = await _cardService.GetCardsAsync(ActiveDeck);
        }

        public async Task LoadAllDecksAsync()
        {
            if (_deckService == null) return;
            DeckList = await _deckService.GetDecksAsync();
            if(ActiveDeck == null && DeckList != null && DeckList.Count >0)
            {
                var activeDeck = DeckList.FirstOrDefault(item => item.IsActive);

                if (activeDeck == null) activeDeck = DeckList[0];

                SetActiveDeck(activeDeck);
            }
        }

        public void SetActiveDeck(Deck deck)
        {
            ActiveDeck = deck;
        }
    }
}

