using System;
using System.Collections.Generic;

namespace JustInfo.Domain.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string ProfileName { get; set; }
        public string IdentityId { get; set; }

        public string Location { get; set; }
        public int Gender { get; set; }
        public int ColorTheme { get; set; }

        public AppUser Identity { get; set; } // Navigation Property

        public IList<Scrap> Scraps { get; set; } = new List<Scrap>();
        public IList<ScrapComment> ScrapComments { get; set; } = new List<ScrapComment>();
        public IList<ScrapLike> ScrapLikes { get; set; } = new List<ScrapLike>();
    }
}
