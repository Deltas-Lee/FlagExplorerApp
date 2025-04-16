using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class Flag
    {
        [JsonPropertyName("svg")]
        public string Svg { get; set; }
        [JsonPropertyName("png")]
        public string Png { get; set; }

    }
}
