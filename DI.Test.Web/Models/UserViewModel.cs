using System.Text.Json;

namespace DI.Test.Web.Models
{
    public class UserViewModel : ISerializedViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public DateTime? DateBorn { get; set; }

        public string ImageUrl { get; set; }

        public UserViewModel() { }

        public UserViewModel(Data.Entities.User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            this.Id = user.Id;
            this.Title = user.Name.Title;
            this.First = user.Name.First;
            this.Last = user.Name.Last;
            this.DateBorn = user.DoB.Date;
            this.ImageUrl = user.Picture.Large.Url;
        }

        public string Serialize(JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(this, options);
        }
    }
}
