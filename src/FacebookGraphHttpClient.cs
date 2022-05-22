using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Talrand.SocialMedia.Instagram
{
    internal class FacebookGraphHttpClient
    {
        private readonly HttpClient _httpClient;

        internal FacebookGraphHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://graph.facebook.com/v10.0/");
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            string responseContent = await GetAsync(url).ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(responseContent);
        }

        protected async Task<string> GetAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            // Throw an error if response is not successful
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            // Ensure parameters are valid
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));
            if (content == null) throw new ArgumentNullException(nameof(content));

            // Post passed data as json to the url
            HttpResponseMessage response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);

            // Throw an error if response is not successful
            response.EnsureSuccessStatusCode();

            // Deserialize response into requested model
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        }
    }
}