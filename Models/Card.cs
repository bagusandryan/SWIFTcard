using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SWIFTcard.Models
{
	public partial class Card : ObservableObject
	{
        [JsonProperty("deck_id")]
        [property: JsonIgnore]
        string DeckId => Deck.Id;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DeckId))]
        Deck _deck;

        [JsonProperty("question")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _question;

        [JsonProperty("answer")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _answer;

        [JsonProperty("context")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _context;
    }
}

