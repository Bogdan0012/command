using Newtonsoft.Json;
using PixabayProject.Models;
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
                PixabayImageResponse? response = JsonConvert.DeserializeObject<PixabayImageResponse>(responseContent);
                if (response == null)
                {
                    throw new ArgumentNullException();
                }
                return response.hits;
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
                PixabayImageResponse? response = JsonConvert.DeserializeObject<PixabayImageResponse>(responseContent);
                if (response == null)
                {
                    throw new ArgumentNullException();
                }
                return response.hits;
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
                PixabayVideoResponse? response = JsonConvert.DeserializeObject<PixabayVideoResponse>(repsonseContent);
                if(response == null)
                {
                    throw new ArgumentNullException();
                }
                return response.hits;
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
                PixabayVideoResponse? response = JsonConvert.DeserializeObject<PixabayVideoResponse>(responseContent);
                if (response == null)
                {
                    throw new ArgumentNullException();
                }
                return response.hits;
            }
            else
            {
                return new List<PixabayVideos>();
            }
        }

    }

}
