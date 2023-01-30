//Model that will be used for API data
namespace PagedListViewer.Models
{
	public class Photo
	{
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
}
//If it were possible to change the API, I would suggest removing the albumId as in this case it is not being used for anything. 