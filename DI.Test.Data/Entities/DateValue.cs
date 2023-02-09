using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class DateValue
    {
        [Required]
        public DateTime Date { get; set; }

        public int Age { get; set; }
    }
}
