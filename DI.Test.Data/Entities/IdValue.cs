using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class IdValue
    {
        public string? Name { get; set; }

        public string Value { get; set; }
    }
}