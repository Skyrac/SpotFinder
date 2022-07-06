using Xibix.Services.Models;
using System.Linq;

namespace Xibix.Services
{
    public class PathFinder
    {
        public SpotPath FindPath(int numberOfSpots = 1)
        {
            var mesh = MeshReader.GetMesh();

            var spotsSortedByHeight = mesh.Heights.OrderByDescending(height => height.Height);

            return new SpotPath()
            {
                Spots = FindValidSpots(numberOfSpots, spotsSortedByHeight, mesh.Elements)
            };
        }

        private List<Spot> FindValidSpots(int numberOfSpots, IOrderedEnumerable<Spot> sortedSpots, List<Element> elements)
        {
            var spots = new List<Spot>(numberOfSpots);
            var invalidNeighbours = new List<int>();
            foreach (var spot in sortedSpots)
            {
                var element = GetElementRelatedToSpot(spot, elements);
                if (IsElementValidToBeVisitedAsSpot(element.NodeIds, invalidNeighbours))
                {
                    invalidNeighbours.AddRange(element.NodeIds);

                    spots.Add(spot);

                    if (spots.Count == numberOfSpots)
                    {
                        break;
                    }
                }
            }
            return spots;
        }

        private Element GetElementRelatedToSpot(Spot spot, List<Element> elements)
        {
            return elements.First(element => element.Id.Equals(spot.Id)); 
        }

        private bool IsElementValidToBeVisitedAsSpot(List<int> entryNodeIds, List<int> invalidEntryNodes)
        {
            return !entryNodeIds.Any(id => invalidEntryNodes.Contains(id));
        }
    }
}
