using System.Collections.Generic;

namespace JustInfo.Domain.Models
{
    public class ScrapComment
    {
        public string CommentId { get; set; }
        public string CommentDescription { get; set; }

        public string ScrapId { get; set; }
        public Scrap Scrap { get; set; }

        public string IdentityId { get; set; }
        public UserInfo UserInfo { get; set; }

        public IList<ScrapCommentLikes> ScrapCommentLikes { get; set; } = new List<ScrapCommentLikes>();
    }
}