using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class IdValue
    {
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
