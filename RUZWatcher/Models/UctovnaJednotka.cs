using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RUZWatcher.Models
{
    /// <summary>
    /// Účtovná jednotka.
    /// </summary>
    public class UctovnaJednotka
    {
        [Key]
        [JsonPropertyName("id")]

        public long? Id { get; set; }

        [JsonPropertyName("nazovUJ")]
        public string? NazovSubjektu { get; set; }

        [JsonPropertyName("pravnaForma")]
        public string? PravnaForma { get; set; }

        [JsonPropertyName("mesto")]
        public string? AdresaMesto { get; set; }

        [JsonPropertyName("ulica")]
        public string? AdresaUlica { get; set; }

        [JsonPropertyName("psc")]
        public string? AdresaPSC { get; set; }

        [JsonPropertyName("datumZalozenia")]
        public DateTime? DatumVzniku { get; set; }
        
        [NotMapped]
        [JsonPropertyName("idUctovnychZavierok")]
        public List<long>? IdsUctovnychZavierok { get; set; }

        public List<UctovnaZavierka>? UctovneZavierky { get; set; }

        public string? Poznámka { get; set; }

        public int Hodnotenie { get; set; } = 0;

    }
}
