using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Street
    {
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
