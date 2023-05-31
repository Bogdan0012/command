using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PixabayProject.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace PixabayProject.Controllers
{
    public class PixabayController
    {
        private readonly string key;

        public PixabayController(string key)
        {
            this.key = key;
        }

        public async Task<List<Pixabay>> FindPicture(string imgURL)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/?key={key}&q={HttpUtility.UrlEncode(imgURL)}&image_type=photo");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(responseContent);
                return response.hits;
            }
            else
            {
                return new List<Pixabay>();
            }
        }

        public async Task<List<Pixabay>> FindPictureByUser(string user)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/?key={key}&q=user:{HttpUtility.UrlEncode(user)});
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(responseContent);
                return response.hits;
            }
            else
            {
                return new List<Pixabay>();
            }
        }

    }

}
