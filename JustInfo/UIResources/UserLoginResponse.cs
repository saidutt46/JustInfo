using System;
namespace JustInfo.UIResources
{
    public class UserLoginResponse
    {
        public string Id { get; set; }
        public string ProfileName { get; set; }
        public string IdentityId { get; set; }

        public string Location { get; set; }
        public int Gender { get; set; }
        public int ColorTheme { get; set; }
        public object Jwt { get; set; }
    }
}
