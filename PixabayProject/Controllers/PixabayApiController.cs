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
        private readonly IImageController<Pixabay> imageController;

        public PixabayApiController(IConfiguration configuration, IImageController<Pixabay> imageController)
        {
            this.configuration = configuration;
            this.imageController = imageController;
        }

        [HttpGet]
        [Route("GetPictures")]
        public async Task<List<Pixabay>> GetPixabayPictures(string images)
        {
            try
            {
                var requestToController = imageController.FindPicture(images);
                if (requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<Pixabay>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<Pixabay>();
                }
            }
            catch (Exception ex)
            {
                return new List<Pixabay>();
            }
        }

        [HttpGet]
        [Route("GetPicturesByUser/{username}")]
        public async Task<List<Pixabay>> GetPixabayPicturesByUser(string username)
        {
            try
            {
                var requestToController = imageController.FindPictureByUser(username);
                if (requestToController != null)
                {
                    var responseData = await requestToController;
                    var responseToController = new List<Pixabay>(responseData);
                    return responseToController;
                }
                else
                {
                    return new List<Pixabay>();
                }
            }
            catch (Exception ex)
            {
                return new List<Pixabay>();
            }
        }
    }
}
