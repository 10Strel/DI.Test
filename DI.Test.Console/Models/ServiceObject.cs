using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class ServiceObject
    {
        [JsonProperty("results")]
        public List<User> Users { get; set; }

        [JsonProperty("info")]
        public ServiceInfo Info { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
