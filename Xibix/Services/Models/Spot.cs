using Newtonsoft.Json;

namespace Xibix.Services.Models
{
    public class Spot
    {
        [JsonProperty("element_id")]
        public int Id { get; set; }
        [JsonProperty("value")]
        public double Height { get; set; }
    }
}
