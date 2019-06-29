using System;
namespace JustInfo.Domain.Models
{
    public class ScrapCommentLikes
    {
        public string ScrapCommentLikeId { get; set; }

        public string ScrapCommentId { get; set; }
        public ScrapComment ScrapComment { get; set; }

        public string IdentityId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
