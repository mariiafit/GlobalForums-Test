using System;

namespace GlobalForums.Models.Reply
{
    public class PostReplyViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReplyContent { get; set; }
        public bool IsAuthorAdmin { get; set; }

        public int PostId { get; set; }
    }
}
