using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "This", "is", "hard", "coded" };
    }
}