using Newtonsoft.Json;

namespace Xibix.Services.Models
{
    public class Mesh
    {
        public List<Node> Nodes { get; set; }
        public List<Element> Elements { get; set; }
        [JsonProperty("Values")]
        public List<Spot> Heights { get; set; }
    }
}
