using GlobalForums.Models.Post;
using System.Collections.Generic;

namespace GlobalForums.Models.Home
{
    public class HomeIndexViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingViewModel> LatestPosts { get; set; }
    }
}
