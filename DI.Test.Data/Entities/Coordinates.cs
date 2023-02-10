using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Coordinates
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
