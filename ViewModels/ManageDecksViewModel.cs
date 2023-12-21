using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using SWIFTcard.Services;

namespace SWIFTcard.ViewModels
{
    public partial class ManageDecksViewModel : ObservableObject
    {
        CardService _cardService;
        DeckService _deckService;

        public ManageDecksViewModel(CardService cardService, DeckService deckService)
        {
            _cardService = cardService;
            _deckService = deckService;
        }
    }
}

