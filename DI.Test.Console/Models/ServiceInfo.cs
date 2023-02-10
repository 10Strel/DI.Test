using Newtonsoft.Json;

namespace DI.Test.Console.Models
{
    public class ServiceInfo
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
