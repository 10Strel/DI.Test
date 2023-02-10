using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class DateValue
    {
        public DateTime Date { get; set; }

        public int Age { get; set; }
    }
}
