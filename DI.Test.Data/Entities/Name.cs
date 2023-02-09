using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Name
    {
        public string? Title { get; set; }

        [Required]
        public string First { get; set; }

        [Required]
        public string Last { get; set; }
    }
}
