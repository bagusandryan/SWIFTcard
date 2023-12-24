using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using SWIFTcard.Models;
using SWIFTcard.Services;

namespace SWIFTcard.ViewModels
{
	public partial class AddDeckViewModel : ObservableObject
	{
        DeckService _deckService;

        public AddDeckViewModel(DeckService deckService)
		{
			_deckService = deckService;
            App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>()
          .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        public async Task AddNewDeck(Deck deck)
        {
            _deckService.AddNewDeck(deck);

            await Helpers.CustomSnackbar.ShowCustomSnackbar($"{deck.Name} deck added");
        }
    }
}

