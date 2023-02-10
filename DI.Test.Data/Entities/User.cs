using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI.Test.Data.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Gender { get; set; }

        public Name Name { get; set; }

        public Location Location { get; set; }

        public string Email { get; set; }

        public Login Login { get; set; }

        public DateValue DoB { get; set; }

        public DateValue Registered { get; set; }

        public string? Phone { get; set; }

        public string? Cell { get; set; }

        public IdValue UserId { get; set; }

        public Picture Picture { get; set; }

        public string? Nat { get; set; }
    }
}
