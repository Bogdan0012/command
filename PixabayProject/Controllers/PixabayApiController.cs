using Microsoft.AspNetCore.Mvc;
using PixabayProject.Models;

namespace PixabayProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixabayApiController : ControllerBase
    {
        [HttpGet]
        [Route("GetPictures")]
        public async Task<List<Pixabay>> GetPixabayPictures(string images)
        {
            PixabayController pixabayController = new PixabayController();
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
    }
}
