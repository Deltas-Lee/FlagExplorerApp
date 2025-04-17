using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class Country : Translation
    {
        [JsonPropertyName("name")]
        public Translation Name { get; set; } = new Translation();
        [JsonPropertyName("flags")]
        public Flag Flag { get; set; } = new Flag();
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; } = Array.Empty<string>();
        [JsonPropertyName("population")]
        public int Population { get; set; } 
    }
}
