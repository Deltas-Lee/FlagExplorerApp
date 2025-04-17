using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class Flag
    {
        [JsonPropertyName("svg")]
        public string Svg { get; set; } = string.Empty;
        [JsonPropertyName("png")]
        public string Png { get; set; } = string.Empty;

    }
}
