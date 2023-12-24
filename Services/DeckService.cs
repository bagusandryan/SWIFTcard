using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SWIFTcard.Helpers;
using SWIFTcard.Models;

namespace SWIFTcard.Services
{
	public class DeckService
	{
        ObservableCollection<Deck> _deckList;

        Deck _activeDeck;

        bool _init;

        public DeckService()
		{
		}

        public void SetActiveDeck(Deck deck)
        {
            _activeDeck = deck;

            foreach (var item in _deckList)
            {
                item.IsActive = false;
            }

            if (_deckList.Where(item => item.Id == deck.Id).FirstOrDefault() is Deck activeDeck)
            {
                activeDeck.IsActive = true;
            }
        }

        public Deck GetActiveDeck()
        {
            return _activeDeck;
        }

        public async Task<ObservableCollection<Deck>> GetDecksAsync()
        {
            //If Json file doesn't exist or newly created or empty then copy the decks json from app package
            if (string.IsNullOrEmpty(File.ReadAllText(Helpers.UserFile.GetDecksJson())))
            {
                _init = true;
                await Helpers.UserFile.CopyFileFromAppPackageToAppDataDirectory("decks.json", Helpers.UserDirectory.GetAppDataDirectory());
            }

            if (_deckList != null) return _deckList;

            CancellationToken cancellationToken = new CancellationToken();

            using var reader = File.OpenText(Helpers.UserFile.GetDecksJson());
            await using var jsonReader = new JsonTextReader(reader);

            var data = await JToken.LoadAsync(jsonReader, new JsonLoadSettings
            {
            }, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            _deckList = data.ToObject<ObservableCollection<Deck>>();

            if(_init && _deckList != null && _deckList.Count > 0)
            {
                await Helpers.UserFile.CopyFileFromAppPackageToAppDataDirectory("cards.json", Helpers.UserDirectory.GetDeckDirectory(_deckList[0]));
            }

            return _deckList;
        }


        public void AddNewDeck(Deck deck)
        {
            _deckList.Add(deck);
            Json.Write(UserFile.GetDecksJson(), _deckList);
        }
    }
}

