using System;
using System.Collections.Generic;
using JustInfo.Domain.Models;

namespace JustInfo.UIResources
{
    public class ScrapResponse
    {
        public string ScrapId { get; set; }
        public string Post { get; set; }

        public string IdentityId { get; set; }
        public IList<ScrapComment> Comments { get; set; } = new List<ScrapComment>();
        public IList<ScrapLike> ScrapLikes { get; set; } = new List<ScrapLike>();
    }
}
