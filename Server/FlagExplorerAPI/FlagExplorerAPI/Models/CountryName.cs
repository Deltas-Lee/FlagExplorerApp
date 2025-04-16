using System.Text.Json.Serialization;
using System.Transactions;
using System.Collections.Generic;

namespace FlagExplorerAPI.Models
{
    public class CountryName
    {
        [JsonPropertyName("nativeName")]
        public Dictionary<string, Translation>? NativeName { get; set; }
    }
}
