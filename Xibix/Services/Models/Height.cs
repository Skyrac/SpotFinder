using Newtonsoft.Json;

namespace Xibix.Services.Models
{
    public class Height
    {
        [JsonProperty("element_id")]
        public int Id { get; set; }
        public double Value { get; set; }
    }
}
