using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SWIFTcard.Helpers;
using SWIFTcard.Models;

namespace SWIFTcard.Services
{
	public class CardService
	{
        ObservableCollection<Card> cardList;

        public CardService()
		{
		}

		public async Task<ObservableCollection<Card>> GetCardsAsync(Deck deck)
		{
            CancellationToken cancellationToken = new CancellationToken();

            using var reader = File.OpenText(Helpers.UserFile.GetCardsJson(deck));
            await using var jsonReader = new JsonTextReader(reader);

            var data = await JToken.LoadAsync(jsonReader, new JsonLoadSettings
            {
            }, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            cardList = data.ToObject<ObservableCollection<Card>>();

            foreach(var item in cardList)
            {
                item.Deck = deck;
            }

            return cardList;
        }

        public void AddNewCard(Card card)
        {
            if(card.Deck == null)
            {
                throw new Exception("Deck is null. Card can only be added when Deck exists");
            }
            cardList.Add(card);
            Json.Write(UserFile.GetCardsJson(card.Deck), cardList);
        }

    }
}

