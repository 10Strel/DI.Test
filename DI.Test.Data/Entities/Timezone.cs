using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Timezone
    {
        public string Offset { get; set; }

        public string Description { get; set; }
    }
}
