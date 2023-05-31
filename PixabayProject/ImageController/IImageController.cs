using System.Threading.Tasks;

namespace PixabayProject.ImageController
{
    public interface IImageController<T> where T : class
    {
        Task<List<T>> FindPicture(string request);
        Task<List<T>> FindPictureByUser(string request);
    }
}
