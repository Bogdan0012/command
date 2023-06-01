using System.Collections.Generic;
using System.Threading.Tasks;

namespace PixabayProject.ImageController
{
    public interface IImageController<T, T1> where T : class
    {
        Task<List<T>> FindPicture(string request);
        Task<List<T>> FindPictureByUser(string request);
        Task<List<T>> FindPictureByUser(string user, string promt);
        Task<List<T1>> FindVideos(string request);
        Task<List<T1>> FindVideoByUser(string request);
    }
}
