using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Login
    {
        [Required]
        public string Uuid { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }
        
        public string? Md5 { get; set; }

        public string? Sha1 { get; set; }

        public string? Sha256 { get; set; }
    }
}
