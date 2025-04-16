using System.Text.Json.Serialization;

namespace FlagExplorerAPI.Models
{
    public class Translation
    {
        /// <summary>
        /// Gets or sets official name.
        /// </summary>
        [JsonPropertyName("official")]
        public string Official { get; set; }

        /// <summary>
        /// Gets or sets common used name.
        /// </summary>
        [JsonPropertyName("common")]
        public string Common { get; set; }
    }
}