using Newtonsoft.Json;
using Xibix.Services.Models;

namespace Xibix.Services
{
    public class PathFinder
    {
        public static List<Spot> FindPath(int numberOfSpots = 1)
        {
            return FindPath(MeshReader.GetMesh(), numberOfSpots);
        }

        public static List<Spot> FindPath(Mesh mesh, int numberOfSpots = 1)
        {
            var spotsSortedByHeight = mesh.Values.OrderByDescending(height => height.Value);

            return FindValidSpots(numberOfSpots, spotsSortedByHeight, mesh.Elements);
        }

        public static void WritePathToConsole(string jsonPath, int amountOfSpots)
        {
            Console.WriteLine(JsonConvert.SerializeObject(FindPath(MeshReader.GetMesh(jsonPath), amountOfSpots), Formatting.Indented));
        }

        public static List<Spot> FindValidSpots(int numberOfSpots, IOrderedEnumerable<Spot> sortedSpots, List<Element> elements)
        {
            var spots = new List<Spot>(numberOfSpots);
            var invalidNeighbours = new List<int>();
            foreach (var spot in sortedSpots)
            {
                var element = GetElementRelatedToSpot(spot, elements);
                if (IsElementValidToBeVisitedAsSpot(element.Nodes, invalidNeighbours))
                {
                    invalidNeighbours.AddRange(element.Nodes);

                    spots.Add(spot);

                    if (spots.Count == numberOfSpots)
                    {
                        break;
                    }
                }
            }
            return spots;
        }

        public static Element GetElementRelatedToSpot(Spot spot, List<Element> elements)
        {
            return elements.First(element => element.Id.Equals(spot.Element_Id)); 
        }

        public static bool IsElementValidToBeVisitedAsSpot(List<int> entryNodeIds, List<int> invalidEntryNodes)
        {
            return !entryNodeIds.Any(id => invalidEntryNodes.Contains(id));
        }
    }
}
