using System.ComponentModel.DataAnnotations;

namespace JustInfo.Helpers.Mappings
{
    public class UserProfileResponse
    {
        [Required]
        public string Id { get; set; }
        public string ProfileName { get; set; }
        [Required]
        public string IdentityId { get; set; }
        public string Email { get; set; }

        public string Location { get; set; }
        public int Gender { get; set; }
        public int ColorTheme { get; set; }
    }
}