using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class ToyApiService : IToyData
    {
        private string url = "https://localhost:5001";
        
        private readonly HttpClient client;

        public ToyApiService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Toy>> getToysAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/toy");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Toy> toy = JsonSerializer.Deserialize<List<Toy>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            });
            return toy;
        }

        public async Task AddToyAsync(Toy toys)
        {
            using HttpClient client = new HttpClient();
            String ToyAsJSON = JsonSerializer.Serialize(toys);
            HttpContent content = new StringContent(ToyAsJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5004/Index", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task RemoveToyAsync(string Name)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5004/Toy/{Name}");
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}