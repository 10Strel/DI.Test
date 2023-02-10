using DI.Test.Console.Models;
using DI.Test.Data;

namespace DI.Test.Console
{
    public class Program
    {
        private static readonly MsSqlDbContext dbContext;

        static Program()
        {
            dbContext = new MsSqlDbContext();
        }

        public static void Main()
        {
            List<User> users = RandomUserService.GetRandomUsers();

            if (users != null)
            {
                foreach (var user in users)
                {
                    Data.Entities.User DbUser = GetDbUser(user);

                    if (DbUser != null)
                        dbContext.Users.Add(DbUser);
                }

                dbContext.SaveChanges();
            }
        }
        
        private static Data.Entities.User GetDbUser(User user)
        {
            Data.Entities.User DbUser = new();

            if (user != null)
            {
                DbUser.Gender = user.Gender;

                DbUser.Name = new()
                {
                    Title = user.Name.Title,
                    First = user.Name.First,
                    Last = user.Name.Last
                };

                DbUser.Location = new()
                {
                    Street = new()
                    {
                        Number = user.Location.Street.Number,
                        Name = user.Location.Street.Name
                    },

                    City = user.Location.City,
                    State = user.Location.State,
                    Country = user.Location.Country,
                    Postcode = user.Location.Postcode,

                    Coordinates = new()
                    {
                        Latitude = user.Location.Coordinates.Latitude,
                        Longitude = user.Location.Coordinates.Longitude
                    },

                    Timezone = new()
                    {
                        Offset = user.Location.Timezone.Offset,
                        Description = user.Location.Timezone.Description
                    }
                };

                DbUser.Email = user.Email;

                DbUser.Login = new()
                {
                    Uuid = user.Login.Uuid,
                    Username = user.Login.Username,
                    Password = user.Login.Password,
                    Salt = user.Login.Salt,
                    Md5 = user.Login.Md5,
                    Sha1 = user.Login.Sha1,
                    Sha256 = user.Login.Sha256
                };

                DbUser.DoB = new()
                {
                    Date = user.DoB.Date,
                    Age = user.DoB.Age
                };

                DbUser.Registered = new()
                {
                    Date = user.Registered.Date,
                    Age = user.Registered.Age
                };

                DbUser.Phone = user.Phone;
                DbUser.Cell = user.Cell;

                DbUser.UserId = new()
                {
                    Name = user.UserId.Name,
                    Value = user.UserId.Value
                };

                DbUser.Picture = new()
                {
                    Large = new()
                    {
                        Url = user.Picture.Large,
                        Image = RandomUserService.GetImage(user.Picture.Large).Result
                    },

                    Medium = new()
                    {
                        Url = user.Picture.Medium
                    },

                    Thumbnail = new()
                    {
                        Url = user.Picture.Thumbnail
                    }
                };

                DbUser.Nat = user.Nat;
            }

            return DbUser;
        }
    }
}
