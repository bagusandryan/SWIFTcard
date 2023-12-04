using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SWIFTcard.Models;

namespace SWIFTcard.Services
{
	public class CardService
	{
		List<Card> cardList;

		public CardService()
		{
		}

		public async Task<List<Card>> GetCardsAsync(Deck deck)
		{
            CancellationToken cancellationToken = new CancellationToken();

            using var reader = File.OpenText(Helpers.UserFile.GetCardsJson(deck));
            await using var jsonReader = new JsonTextReader(reader);

            var data = await JToken.LoadAsync(jsonReader, new JsonLoadSettings
            {
            }, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            cardList = data.ToObject<List<Card>>();

            cardList.ForEach(item => item.Deck = deck);

            return cardList;
        }
    }
}

