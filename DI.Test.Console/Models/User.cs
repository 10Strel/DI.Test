using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class User
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public Login Login { get; set; }

        [JsonProperty("dob")]
        public DoB DoB { get; set; }

        [JsonProperty("registered")]
        public Registered Registered { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("id")]
        public UserId UserId { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("nat")]
        public string Nat { get; set; }
    }
}
