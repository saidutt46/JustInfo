using System;
using System.Collections.Generic;
using JustInfo.Domain.Models;

namespace JustInfo.UIResources
{
    public class ScrapCommentResponse
    {
        public string CommentId { get; set; }
        public string CommentDescription { get; set; }

        public string ScrapId { get; set; }
        public string IdentityId { get; set; }
        public IList<ScrapCommentLikes> ScrapCommentLikes { get; set; }

    }
}
