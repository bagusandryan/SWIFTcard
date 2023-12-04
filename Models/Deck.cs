using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace SWIFTcard.Models
{
    public partial class Deck : ObservableObject
    {
        [JsonProperty("id")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _id;

        [JsonProperty("is_active")]
        [property: JsonIgnore]
        [ObservableProperty]
        bool _isActive;

        [JsonProperty("name")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _name;

        [JsonProperty("question_language")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _questionLang;

        [JsonProperty("answer_language")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _answerLang;
    }
}

