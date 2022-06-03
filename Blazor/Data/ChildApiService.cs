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
    public class ChildApiService : IChildData
    {
        private string url = "https://localhost:5004";

        private readonly HttpClient client;

        public ChildApiService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Child>> getChildAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/child");

            var children = await responseMessage.Content.ReadFromJsonAsync<List<Child>>();

            return children;
        }

        public async Task AddChildAsync(Child children)
        {
            using HttpClient client = new HttpClient();
            String ChildAsJSON = JsonSerializer.Serialize(children);
            HttpContent content = new StringContent(ChildAsJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5004/Child", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task RemoveChildAsync(string name)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5004/Child/{name}");
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}