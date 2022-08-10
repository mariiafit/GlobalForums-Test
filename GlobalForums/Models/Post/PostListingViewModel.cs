﻿using GlobalForums.Models.Forum;

namespace GlobalForums.Models.Post
{
    public class PostListingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string DatePosted { get; set; }

        public ForumListingViewModel Forum { get; set; }

        public int RepliesCount { get; set; }
    }
}
