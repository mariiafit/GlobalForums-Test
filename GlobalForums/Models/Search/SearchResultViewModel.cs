using GlobalForums.Models.Post;
using System.Collections.Generic;

namespace GlobalForums.Models.Search
{
    public class SearchResultViewModel
    {
        public IEnumerable<PostListingViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
