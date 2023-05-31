using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PixabayProject.ImageController;
using PixabayProject.Models;

namespace PixabayProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixabayApiController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IImageController<PixabayImages, PixabayVideos> imageController;

        public PixabayApiController(IConfiguration configuration, IImageController<PixabayImages, PixabayVideos> imageController)
        {
            this.configuration = configuration;
            this.imageController = imageController;
        }

        [HttpGet]
        [Route("GetPictures")]
        public async Task<List<PixabayImages>> GetPixabayPictures(string images)
        {
            try
            {
                var requestToController = imageController.FindPicture(images);
                if (requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<PixabayImages>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<PixabayImages>();
                }
            }
            catch (Exception)
            {
                return new List<PixabayImages>();
            }
        }

        [HttpGet]
        [Route("GetVideos")]
        public async Task<List<PixabayVideos>> GetPixabayVideos(string videos)
        {
            try
            {
                var requestToController = imageController.FindVideos(videos);
                if(requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<PixabayVideos>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<PixabayVideos>();
                }
            }
            catch (Exception)
            {

                return new List<PixabayVideos>();
            }
        }

        [HttpGet]
        [Route("GetPicturesByUser/{username}")]
        public async Task<List<PixabayImages>> GetPixabayPicturesByUser(string username)
        {
            try
            {
                var requestToController = imageController.FindPictureByUser(username);
                if (requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<PixabayImages>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<PixabayImages>();
                }
            }
            catch (Exception)
            {
                return new List<PixabayImages>();
            }
        }

        [HttpGet]
        [Route("GetVideosByUser/{username}")]
        public async Task<List<PixabayVideos>> GetPixabayVideoByUser(string username)
        {
            try
            {
                var requestToController = imageController.FindVideoByUser(username);
                if (requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<PixabayVideos>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<PixabayVideos>();
                }
            }
            catch (Exception)
            {
                return new List<PixabayVideos>();
            }
        }
    }
}
