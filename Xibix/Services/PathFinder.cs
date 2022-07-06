using Xibix.Services.Models;
using System.Linq;
namespace Xibix.Services
{
    public class PathFinder
    {
        public SpotPath FindPath(int numberOfSpots = 1)
        {
            var mesh = MeshReader.GetMesh();
            var triangles = GenerateTrianglesFromMesh(mesh);
            
            return new SpotPath();
        }

        private List<Triangle> GenerateTrianglesFromMesh(Mesh mesh)
        {
            var triangles = new List<Triangle>(mesh.Elements.Count);
            foreach (var element in mesh.Elements)
            {
                var triangle = ConvertElementToTriangle(mesh, element);
                triangles.Add(triangle);
            }

            MapTriangleNeighboursToTriangle(ref triangles);
            return triangles;
        }

        private void MapTriangleNeighboursToTriangle(ref List<Triangle> triangles)
        {
            foreach(var triangle in triangles)
            {
                triangle.Neighbours = FindNeighboursOfTriangle(triangle, triangles);
            }
        }

        private List<Triangle> FindNeighboursOfTriangle(Triangle sourceTriangle, List<Triangle> triangles)
        {
            var neighbours = triangles.Where(triangle => !triangle.Id.Equals(sourceTriangle.Id) 
            && triangle.Nodes.Any(node => sourceTriangle.Nodes.Contains(node)))
                .ToList();
            return neighbours;
        }

        private Triangle ConvertElementToTriangle(Mesh mesh, Element element)
        {
            var nodes = element.NodeIds.Select(nodeId => mesh.Nodes.FirstOrDefault(node => node.Id.Equals(nodeId))).ToList();
            var height = mesh.Heights.First(mesh => mesh.Id.Equals(element.Id)).Value;
            return new Triangle() { Id = element.Id, Nodes = nodes, Height = height};
        }
    }
}
