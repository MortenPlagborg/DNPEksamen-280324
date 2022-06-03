using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class ToyApiService : IToyData
    {
        private string url = "https://localhost:5004";
        
        private readonly HttpClient client;

        public ToyApiService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Toy>> getToysAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/toy");

            if (responseMessage.IsSuccessStatusCode)
            {
                var toys = await responseMessage.Content.ReadFromJsonAsync<List<Toy>>();
                return toys;
            }
            
            return new List<Toy>();
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