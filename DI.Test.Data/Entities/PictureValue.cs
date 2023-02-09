using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class PictureValue
    {
        public string Url { get; set; }

        public byte[] Image { get; set; }
    }
}
