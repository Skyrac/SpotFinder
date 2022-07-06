using Microsoft.AspNetCore.Mvc;
using Xibix.Services;

namespace Xibix.Controllers;

[Route("api/[controller]")]
public class PathController : ControllerBase
{
    private readonly PathFinder _pathFinder;
    public PathController(PathFinder pathFinder)
    {
        _pathFinder = pathFinder;
    }
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{amount}")]
    public string Get(int amount)
    {
        _pathFinder.FindPath(1);
        return "value";
    }
}