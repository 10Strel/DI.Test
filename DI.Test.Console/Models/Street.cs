using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class Street
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
