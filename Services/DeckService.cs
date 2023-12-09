using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SWIFTcard.Models;

namespace SWIFTcard.Services
{
	public class DeckService
	{
        List<Deck> _deckList;

        Deck _activeDeck;

        bool _init;

        public DeckService()
		{
		}

        public void SetActiveDeck(Deck deck)
        {
            _activeDeck = deck;
        }

        public Deck GetActiveDeck()
        {
            return _activeDeck;
        }

        public async Task<List<Deck>> GetDecksAsync()
        {
            //If Json file doesn't exist or newly created or empty then copy the decks json from app package
            if (string.IsNullOrEmpty(File.ReadAllText(Helpers.UserFile.GetDecksJson())))
            {
                _init = true;
                await Helpers.UserFile.CopyFileFromAppPackageToAppDataDirectory("decks.json", Helpers.UserDirectory.GetAppDataDirectory());
            }

            CancellationToken cancellationToken = new CancellationToken();

            using var reader = File.OpenText(Helpers.UserFile.GetDecksJson());
            await using var jsonReader = new JsonTextReader(reader);

            var data = await JToken.LoadAsync(jsonReader, new JsonLoadSettings
            {
            }, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            _deckList = data.ToObject<List<Deck>>();

            if(_init && _deckList != null && _deckList.Count > 0)
            {
                await Helpers.UserFile.CopyFileFromAppPackageToAppDataDirectory("cards.json", Helpers.UserDirectory.GetDeckDirectory(_deckList[0]));
            }

            return _deckList;
        }
    }
}

