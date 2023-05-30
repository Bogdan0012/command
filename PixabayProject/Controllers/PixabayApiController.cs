using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PixabayProject.Models;

namespace PixabayProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixabayApiController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public PixabayApiController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetPictures")]
        public async Task<List<Pixabay>> GetPixabayPictures(string images)
        {
            PixabayController pixabayController = new PixabayController(configuration);
            try
            {
                var requestToController = pixabayController.FindPicture(images);
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
