using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Name
    {
        public string? Title { get; set; }

        public string First { get; set; }

        public string Last { get; set; }
    }
}
