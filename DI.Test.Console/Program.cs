using DI.Test.Console;
using DI.Test.Console.Models;
using DI.Test.Data;

public class Program
{
    private static readonly MsSqlDbContext dbContext;
    private static readonly int countUsers = 1000;

    static Program()
    {
        dbContext = new MsSqlDbContext();
    }

    public static void Main()
    {
        try
        {
            WriteLine("DI.Test\r\n");

            WriteLine("Старт процедуры загрузки данных..\r\n");

            List<User> users = RandomUserService.GetRandomUsers(countUsers);

            WriteLine($"Загрузка данных завершена. Количество аккаунтов пользователей: {users?.Count ?? 0}\r\n");

            if (users != null && users.Count > 0)
            {
                WriteLine("Старт процедуры обработки данных..\r\n");

                List<DI.Test.Data.Entities.User> DbUsers = new();

                foreach (var user in users)
                {
                    DI.Test.Data.Entities.User DbUser = GetDbUser(user);

                    if (DbUser != null)
                        DbUsers.Add(DbUser);
                }

                dbContext.AddRange(DbUsers);
                dbContext.SaveChanges();
                dbContext.DetachAllEntities();

                WriteLine($"Обработка данных завершена. Количество сохраненных аккаунтов: {DbUsers.Count}\r\n");
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error: {ex.Message}");            
        }
    }

    private static DI.Test.Data.Entities.User GetDbUser(User user)
    {
        if (user == null)
            return null;

        DI.Test.Data.Entities.User DbUser = new()
        {
            Gender = user.Gender,

            Name = new()
            {
                Title = user.Name.Title,
                First = user.Name.First,
                Last = user.Name.Last
            },

            Location = new()
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
            },

            Email = user.Email,

            Login = new()
            {
                Uuid = user.Login.Uuid,
                Username = user.Login.Username,
                Password = user.Login.Password,
                Salt = user.Login.Salt,
                Md5 = user.Login.Md5,
                Sha1 = user.Login.Sha1,
                Sha256 = user.Login.Sha256
            },

            DoB = new()
            {
                Date = user.DoB.Date,
                Age = user.DoB.Age
            },

            Registered = new()
            {
                Date = user.Registered.Date,
                Age = user.Registered.Age
            },

            Phone = user.Phone,
            Cell = user.Cell,

            UserId = new()
            {
                Name = user.UserId.Name,
                Value = user.UserId.Value
            },

            Picture = new()
            {
                Large = new()
                {
                    Url = user.Picture.Large,
                    Image = RandomUserService.GetImage(user.Picture.Large).Result
                },

                Medium = new()
                {
                    Url = user.Picture.Medium,
                    Image = RandomUserService.GetImage(user.Picture.Medium).Result
                },

                Thumbnail = new()
                {
                    Url = user.Picture.Thumbnail,
                    Image = RandomUserService.GetImage(user.Picture.Thumbnail).Result
                }
            },

            Nat = user.Nat
        };

        return DbUser;
    }

    private static void WriteLine(string msg)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss,fff}\t{msg}");
    }
}
