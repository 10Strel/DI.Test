using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Street
    {
        public string? Number { get; set; }

        public string Name { get; set; }
    }
}
