using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Timezone
    {
        [Required]
        public string Offset { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
