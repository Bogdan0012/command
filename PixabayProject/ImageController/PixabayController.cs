using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PixabayProject.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace PixabayProject.ImageController
{
    public class PixabayController : IImageController<PixabayImages, PixabayVideos>
    {
        private readonly string key;

        public PixabayController(string key)
        {
            this.key = key;
        }

        public async Task<List<PixabayImages>> FindPicture(string imgURL)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/?key={key}&q={HttpUtility.UrlEncode(imgURL)}&image_type=photo");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(responseContent);
                return response.hitsOfImages;
            }
            else
            {
                return new List<PixabayImages>();
            }
        }

        public async Task<List<PixabayImages>> FindPictureByUser(string user)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/?key={key}&q=user:{HttpUtility.UrlEncode(user)}");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(responseContent);
                return response.hitsOfImages;
            }
            else
            {
                return new List<PixabayImages>();
            }
        }

        public async Task<List<PixabayVideos>> FindVideos(string imgURL)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/videos/?key={key}&q={HttpUtility.UrlEncode(imgURL)}");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var repsonseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(repsonseContent);
                return response.hitsOfVideos;
            }
            else
            {
                return new List<PixabayVideos>();
            }
        }

        public async Task<List<PixabayVideos>> FindVideoByUser(string user)
        {
            HttpClient httpClient = new HttpClient();
            using var requestPass = new HttpRequestMessage(HttpMethod.Get, $"https://pixabay.com/api/videos/?key={key}&q=user:{user}");
            using var responseSend = await httpClient.SendAsync(requestPass);
            if (responseSend.IsSuccessStatusCode)
            {
                var responseContent = await responseSend.Content.ReadAsStringAsync();
                PixabayResponse response = JsonConvert.DeserializeObject<PixabayResponse>(responseContent);
                return response.hitsOfVideos;
            }
            else
            {
                return new List<PixabayVideos>();
            }
        }

    }

}
