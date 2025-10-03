using System.Text.Json.Serialization;

namespace RUZWatcher.Models
{
    public class ZoznamIdentifikatorov
    {
        [JsonPropertyName("id")]
        public List<long>? Ids { get; set; }
        [JsonPropertyName("existujeDalsieId")]
        public bool ExistujeDalsieId { get; set; }

    }
}
