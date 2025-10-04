using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RUZWatcher.Models
{
    /// <summary>
    /// Účtovná závierka.
    /// </summary>
    public class UctovnaZavierka
    {
        [Key]
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("idUJ")]
        public long? IdUJ { get; set; }

        [ForeignKey(nameof(IdUJ))]
        public UctovnaJednotka? UctovnaJednotka { get; set; }

        [JsonPropertyName("obdobieDo")]
        public string? Rok { get; set; }

        [JsonPropertyName("typ")]
        public string? Typ { get; set; }

        [NotMapped]
        [JsonPropertyName("idUctovnychVykazov")]
        public List<long>? IdUctovnychVykazov { get; set; }

        public string? LinkPdf { get; set; }
    }
}
