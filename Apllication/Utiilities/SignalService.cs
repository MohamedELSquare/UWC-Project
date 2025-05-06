using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL
{
    

    public class SignalService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task AddSignalAsync(TagDirection signal)
        {
            var client = _httpClientFactory.CreateClient("SignalApi");

            try
            {
                var json = JsonSerializer.Serialize(signal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Signal", content);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {responseBody}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to call Signal API: {ex.Message}");
            }
        }
        public async Task UpdateSignalAsync(TagDirection signal)
        {
            var client = _httpClientFactory.CreateClient("SignalApi");

            try
            {
                var json = JsonSerializer.Serialize(signal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("Update", content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Update Response: {responseBody}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to update signal: {ex.Message}");
            }
        }
    }
}
