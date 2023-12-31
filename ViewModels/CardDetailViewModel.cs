﻿using System;
using System.Collections.ObjectModel;
using Android.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using SWIFTcard.Models;
using SWIFTcard.Services;

namespace SWIFTcard.ViewModels
{
    public partial class CardDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isAddMode;

        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        ObservableCollection<Card> _cardList;

        CardService _cardService;
        DeckService _deckService;

        public CardDetailViewModel(CardService cardService, DeckService deckService)
        {
            _cardService = cardService;
            _deckService = deckService;
            App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>()
            .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            if (!IsAddMode)
            {
                _ = LoadAllCardsAsync();
            }
        }

        public Deck GetActiveDeck()
        {
            return _deckService.GetActiveDeck();
        }

        public void AddNewCard(Card card)
        {
            _cardService.AddNewCard(card);
        }

        public async Task LoadAllCardsAsync()
        {
            if (_cardService == null || _deckService == null) return;
            IsBusy = true;
            await Task.Delay(500);
            CardList = await _cardService.GetCardsAsync(GetActiveDeck());
            IsBusy = false;
        }

        [RelayCommand]
        async Task DeleteCard(Card card)
        {
            bool answer = await Shell.Current.DisplayAlert($"Delete {card.Question}", "Would you like to delete this card? This action cannot be undone.", "Delete", "No");
            if (answer)
            {
                _cardService.DeleteCard(card);
            }
        }
    }
}

