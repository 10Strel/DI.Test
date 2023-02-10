using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class UserId
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
