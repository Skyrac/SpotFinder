using SpotFinder.Services;
using SpotFinder.Services.Models;
using Xunit;

namespace SpotFinder.Tests;

public class PathFinderTests
{


    [Fact()]
    public void TestElementShouldBeValidIfNoEntryNodeInInvalidEntries()
    {
        var entryNodeIds = new List<int>() { 5, 3, 1 };
        var invalidEntryNodes = new List<int>() { 17, 11, 12 };

        var result = PathFinder.IsElementValidToBeVisitedAsSpot(entryNodeIds, invalidEntryNodes);

        Assert.True(result);
    }

    [Fact()]
    public void TestElementShouldBeInvalidIfAnyEntryNodeInInvalidEntries()
    {
        var entryNodeIds = new List<int>() { 5, 3, 1 };
        var invalidEntryNodes = new List<int>() { 5, 11, 12 };

        var result = PathFinder.IsElementValidToBeVisitedAsSpot(entryNodeIds, invalidEntryNodes);

        Assert.False(result);
    }

    [Fact()]
    public void TestElementShouldBeValidIfNoEntryNodeInInvalidEntriesAndInvalidEntriesEmpty()
    {
        var entryNodeIds = new List<int>() { 5, 3, 1 };
        var invalidEntryNodes = new List<int>() {  };

        var result = PathFinder.IsElementValidToBeVisitedAsSpot(entryNodeIds, invalidEntryNodes);

        Assert.True(result);
    }

    [Fact()]
    public void ShouldReturnElementOfSpotFromListOfElements()
    {
        var spot = GenerateSpot(1, 0);

        var elements = new List<Element>() {
            GenerateElement(0),
            GenerateElement(17),
            GenerateElement(1)
        };

        var result = PathFinder.GetElementRelatedToSpot(spot, elements);

        Assert.NotNull(result);
        Assert.True(result.Id == 1);
    }

    [Fact()]
    public void ShouldThrowExceptionIfSpotIsNotInListOfElements()
    {
        var spot = GenerateSpot(1, 0);

        var elements = new List<Element>() {
            GenerateElement(0),
            GenerateElement(17),
            GenerateElement(5)
        };

        Assert.Throws<InvalidOperationException>(() => PathFinder.GetElementRelatedToSpot(spot, elements));
    }

    [Fact()]
    public void ShouldReturnFirstHighestValidSpot()
    {
        var numberOfSpots = 1;
        var spots = new List<Spot>() { GenerateSpot(0, 1.1), GenerateSpot(1, 1.2), GenerateSpot(2, 2.252) }
        .OrderByDescending(spot => spot.Value);

        var elements = new List<Element>() {
            GenerateElement(0),
            GenerateElement(1),
            GenerateElement(2)
        };

        var result = PathFinder.FindValidSpots(numberOfSpots, spots, elements);

        Assert.Equal(numberOfSpots, result.Count);
        Assert.Equal(2, result[0].Element_Id);
        Assert.Equal(2.252, result[0].Value);
    }

    [Fact()]
    public void ShouldReturnTwoHighestValidSpotAndSkipNeighbour()
    {
        var numberOfSpots = 2;
        var spots = new List<Spot>() { GenerateSpot(0, 1.1), GenerateSpot(1, 1.2), GenerateSpot(2, 2.252) }
        .OrderByDescending(spot => spot.Value);

        var elements = new List<Element>() {
            GenerateElement(0, 1, 2, 3),
            GenerateElement(1, 4, 5, 6),
            GenerateElement(2, 5, 7, 8)
        };

        var result = PathFinder.FindValidSpots(numberOfSpots, spots, elements);

        Assert.Equal(numberOfSpots, result.Count);
        Assert.Equal(2, result[0].Element_Id);
        Assert.Equal(2.252, result[0].Value);
        Assert.Equal(0, result[1].Element_Id);
        Assert.Equal(1.1, result[1].Value);
    }

    [Fact()]
    public void ShouldReturnOnlyTwoValidSpotAndSkipNeighbour()
    {
        var numberOfSpots = 3;
        var spots = new List<Spot>() { GenerateSpot(0, 1.1), GenerateSpot(1, 1.2), GenerateSpot(2, 2.252) }
        .OrderByDescending(spot => spot.Value);

        var elements = new List<Element>() {
            GenerateElement(0, 1, 2, 3),
            GenerateElement(1, 4, 5, 6),
            GenerateElement(2, 5, 7, 8)
        };

        var result = PathFinder.FindValidSpots(numberOfSpots, spots, elements);

        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[0].Element_Id);
        Assert.Equal(2.252, result[0].Value);
        Assert.Equal(0, result[1].Element_Id);
        Assert.Equal(1.1, result[1].Value);
    }

    private Element GenerateElement(int id, params int[] nodeIds)
    {
        return new Element
        {
            Id = id,
            Nodes = nodeIds.ToList()
        };
    }

    private Node GenerateNode(int id, int x, int y)
    {
        return new Node
        {
            Id = id,
            X = x,
            Y = y
        };
    }

    private Spot GenerateSpot(int id, double value)
    {
        return new Spot
        {
            Element_Id = id,
            Value = value
        };
    }


}