using System;
using Android.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWIFTcard.Models;
using SWIFTcard.Services;

namespace SWIFTcard.ViewModels
{
    public partial class CardDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isAddMode;

        CardService _cardService;
        DeckService _deckService;

        public CardDetailViewModel(CardService cardService, DeckService deckService)
        {
            _cardService = cardService;
            _deckService = deckService;
        }

        public Deck GetActiveDeck()
        {
            return  _deckService.GetActiveDeck();
        }

        public void AddNewCard(Card card)
        {
            _cardService.AddNewCard(card);
        }
	}
}

