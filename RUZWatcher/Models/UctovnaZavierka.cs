using System.Text.Json.Serialization;

namespace RUZWatcher.Models
{
    /// <summary>
    /// Účtovná závierka.
    /// </summary>
    public class UctovnaZavierka
    {

        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("idUJ")]
        public long? IdUJ { get; set; }

        [JsonPropertyName("obdobieDo")]
        public string? Rok { get; set; }

        [JsonPropertyName("typ")]
        public string? Typ { get; set; }

        [JsonPropertyName("idUctovnychVykazov")]
        public List<long>? IdUctovnychVykazov { get; set; }

        public string? LinkPdf { get; set; }
    }
}
