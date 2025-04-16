using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class CountryDetails: Translation
    {

        [JsonPropertyName("name")]
        public Translation Name { get; set; }
        [JsonPropertyName("flags")]
        public Flag Flag { get; set; }
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }
        [JsonPropertyName("population")]
        public int Population { get; set; }

    }
}
