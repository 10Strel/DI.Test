using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Picture
    {
        public PictureValue Large { get; set; }

        public PictureValue Medium { get; set; }

        public PictureValue Thumbnail { get; set; }
    }
}
