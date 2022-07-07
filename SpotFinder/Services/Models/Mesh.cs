using Newtonsoft.Json;

namespace SpotFinder.Services.Models
{
    public class Mesh
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Element> Elements { get; set; } = new List<Element>();
        public List<Spot> Values { get; set; } = new List<Spot>();
    }
}
