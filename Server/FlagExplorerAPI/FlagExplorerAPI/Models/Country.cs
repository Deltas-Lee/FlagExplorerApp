using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class Country : Translation
    {
        [JsonPropertyName("name")]
        public Translation Name { get; set; }
        [JsonPropertyName("flags")]
        public Flag Flag { get; set; }
    }
}
