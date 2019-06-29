using System;
using System.Collections.Generic;

namespace JustInfo.Domain.Models
{
    public class Scrap
    {
        public string ScrapId { get; set; }
        public string Post { get; set; }

        public string IdentityId { get; set; }
        public IList<ScrapComment> Comments { get; set; } = new List<ScrapComment>();
        public IList<ScrapLike> ScrapLikes { get; set; } = new List<ScrapLike>();
        public UserInfo UserInfo { get; set; }
    }
}
