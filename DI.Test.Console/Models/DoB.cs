using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class DoB
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
