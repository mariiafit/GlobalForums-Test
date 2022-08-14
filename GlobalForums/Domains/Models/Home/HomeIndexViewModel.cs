using GlobalForums.Domains.Models.Post;
using System.Collections.Generic;

namespace GlobalForums.Domains.Models.Home
{
    public class HomeIndexViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingViewModel> LatestPosts { get; set; }
    }
}
