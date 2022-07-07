using Newtonsoft.Json;

namespace SpotFinder.Services.Models
{
    public class Element
    {
        public int Id { get; set; }
        public List<int> Nodes { get; set; }
    }
}
