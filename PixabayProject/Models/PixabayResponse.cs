namespace PixabayProject.Models
{
    public class PixabayResponse
    {
        public List<PixabayImages> hitsOfImages { get; set; } = new List<PixabayImages>();
        public List<PixabayVideos> hitsOfVideos { get; set; } = new List<PixabayVideos>();
    }
}
