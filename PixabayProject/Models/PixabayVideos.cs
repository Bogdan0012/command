namespace PixabayProject.Models
{
    public class PixabayVideos
    {
        public int? views { get; set; }
        public int? likes { get; set; }
        public string? user { get; set; }
        public string? userImageURL { get; set; }
        public VideoListModel? videos { get; set; }
    }
}
