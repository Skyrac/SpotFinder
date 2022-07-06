namespace Xibix.Services.Models
{
    public class Triangle
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Triangle> Neighbours { get; set; }
    }
}
