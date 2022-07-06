using Newtonsoft.Json;

namespace Xibix.Services.Models
{
    public class Element
    {
        public int Id { get; set; }
        [JsonProperty("Nodes")]
        public List<int> NodeIds { get; set; }
    }
}
