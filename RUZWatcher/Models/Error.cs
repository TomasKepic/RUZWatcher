namespace RUZWatcher.Models
{
    /// <summary>
    /// Chybový objekt.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Kód chyby.
        /// </summary>
        public string Code { get; set; } = "";

        /// <summary>
        /// Chybová hláška.
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// Technický detail chyby.
        /// </summary>
        public string? Detail { get; set; }
    }
}
