using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class ChildApiService : IChildData
    {
        private string url = "https://localhost:5001";

        private readonly HttpClient client;

        public ChildApiService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Child>> getChildAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/child");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Child> child = JsonSerializer.Deserialize<List<Child>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            });
            return child;
        }

        public async Task AddChildAsync(Child children)
        {
            using HttpClient client = new HttpClient();
            String ChildAsJSON = JsonSerializer.Serialize(children);
            HttpContent content = new StringContent(ChildAsJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5004/Index", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task RemoveChildAsync(int Id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5004/Child/{Id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}