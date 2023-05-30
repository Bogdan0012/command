using Newtonsoft.Json.Linq;
using PixabayProject.Models;
using System;
using System.Net.Http;

namespace PixabayProject.Controllers
{
    public class PixabayController
    {
        public async Task<bool> FindPicture(Pixabay pixabay)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/?key=28501269-85beb46cbb93172460c9f97d2&q={Uri.EscapeDataString(pixabay.imageURL)}&image_type=photo");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseContent);
                JArray images = jsonResponse.Value<JArray>("hits");
                return images.Count > 0;
            }
            else
            {
                return false;
            }
        }

    }

}
