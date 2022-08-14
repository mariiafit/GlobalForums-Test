using GlobalForums.Domains.Models.Post;
using System.Collections.Generic;

namespace GlobalForums.Domains.Models.Forum
{
    public class ForumTopicViewModel
    {
        public ForumListingViewModel Forum { get; set; }
        public IEnumerable<PostListingViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
    }
}
