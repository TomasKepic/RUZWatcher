namespace RUZWatcher.Models
{
    /// <summary>
    /// REST odpoveď.
    /// </summary>
    public class RestResponse
    {
        /// <summary>
        /// Chyba.
        /// </summary>
        public Error? Error { get; set; }

        /// <summary>
        /// Správa o nenájdenom zázname.
        /// </summary>
        public string? NotFoundMessage { get; set; }
    }
}
