using System;
using System.Collections.Generic;
using JustInfo.Domain.Models;

namespace JustInfo.UIResources.UIOutput
{
    public class UserOutput
    {
        public string Id { get; set; }
        public string ProfileName { get; set; }
        public string IdentityId { get; set; }
        public string Email { get; set; }

        public string Location { get; set; }
        public int Gender { get; set; }
        public int ColorTheme { get; set; }
        public DateTime CreatedTime { get; set; }

        //public AppUser Identity { get; set; } // Navigation Property

        //public IList<Scrap> Scraps { get; set; } = new List<Scrap>();
    }
}
