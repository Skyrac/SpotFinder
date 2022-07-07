using Microsoft.AspNetCore.Mvc;
using SpotFinder.Services;
using SpotFinder.Services.Models;

namespace SpotFinder.Controllers;

[Route("api/[controller]")]
public class PathController : ControllerBase
{
    // GET api/values
    [HttpPost("{amount}")]
    public ActionResult Get(int amount, [FromBody] Mesh mesh)
    {
        return Ok(PathFinder.FindPath(mesh, amount));
    }

    // GET api/values/5
    [HttpGet("{amount}")]
    public ActionResult Get(int amount)
    {
        return Ok(PathFinder.FindPath(amount));
    }
}