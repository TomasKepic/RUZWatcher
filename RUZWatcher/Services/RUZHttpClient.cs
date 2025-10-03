using RUZWatcher.Models;
using System.Net;
using System.Text.Json;

namespace RUZWatcher.Services
{
    /// <summary>
    /// Klient pre pripojenie na RUZ API.
    /// </summary>
    public class RUZHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Odpoveď volania.
        /// </summary>
        public RestResponse Response { get; private set; }

        public RUZHttpClient(HttpClient httpClient)
        {

            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://www.registeruz.sk/cruz-public/api/");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "RUZWatcherApp");

            Response = new RestResponse();
        }

        /// <summary>
        /// Zavolá GET.
        /// </summary>
        /// <param name="url">URL pre zavolanie.</param>
        /// <returns>Načítané string informácie.</returns>
        public async Task<string?> GetAsync(string url)
        {
            Response = new RestResponse();

            HttpResponseMessage? response;
            string? content;
            try
            {
                response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException ex)
            {
                SetExceptionResponse(ex);
                return null;
            }

            SetResponse(url, response.StatusCode, content);
            return response.StatusCode == HttpStatusCode.OK ? content : null;
        }

        private void SetExceptionResponse(HttpRequestException ex)
        {
            Response.Error = new Error
            {
                Code = "E_HTTP",
                Message = "Nepodarilo sa korektne zavolať RUZ API.",
                Detail = $"Url: {_httpClient.BaseAddress}\r\n\r\nDôvod: {ex.Message}"
            };
        }

        private void SetResponse(string url, HttpStatusCode code, string? content)
        {
            switch (code)
            {
                case HttpStatusCode.OK:
                    return;
                case HttpStatusCode.Created:
                    return;
                case HttpStatusCode.NoContent:
                    return;
                case HttpStatusCode.Accepted:
                    return;

                case HttpStatusCode.NotFound:
                    if (content == null)
                    {
                        Response.Error = new Error
                        {
                            Code = "E_HTTP404_NotFound",
                            Message = $"Nenašiel sa požadovaný údaj. Volanie služby: ({url})."
                        };
                    }
                    else
                    {
                        Response.NotFoundMessage = content;
                    }
                    return;

                case HttpStatusCode.InternalServerError:
                    Response.Error = new Error { Code = "E_HTTP_500", Message = "Internal server error." };
                    return;

                case HttpStatusCode.BadRequest:

                    if (content != null)
                    {
                        Response.Error = new Error { Code = "E_HTTP_400", Message = "Bad request.", Detail = content };
                    }
                    else
                    {
                        Response.Error = new Error { Code = "E_HTTP_400", Message = "Bad request - nesprávne formulovaná vstupná požiadavka." };
                    }
                    return;

                case HttpStatusCode.Unauthorized:
                    Response.Error = new Error { Code = "E_HTTP_401", Message = "Unahuthorized" };
                    return;

                default:
                    Response.Error = new Error { Code = $"E_HTTP_{code}", Message = "HTTP error." };
                    return;
            }
        }
    }
}
