using System;
using System.ComponentModel.DataAnnotations;

namespace JustInfo.UIResources.UIInput
{
    public class ScrapInput
    {
        [Required]
        [MaxLength(5000)]
        public string Post { get; set; }
        public DateTime CreatedTime { get; set; }
        [Required]
        public string IdentityId { get; set; }
    }
}
