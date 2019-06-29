using System;
namespace JustInfo.Domain.Models
{
    public class ScrapLike
    {
        public string LikeId { get; set; }

        public string ScrapId { get; set; }
        public Scrap Scrap { get; set; }

        public string IdentityId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
