using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI.Test.Data.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        public Location Location { get; set; }

        public string Email { get; set; }

        public Login Login { get; set; }

        public DateValue Dob { get; set; }

        public DateValue Registered { get; set; }

        public string Phone { get; set; }

        public string Cell { get; set; }

        public IdValue UserId { get; set; }

        public Picture Picture { get; set; }

        public string Nat { get; set; }
    }
}
