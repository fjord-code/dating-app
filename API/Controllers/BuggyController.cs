using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public async Task<ActionResult<string>> GetAuth()
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public async Task<ActionResult<AppUser>> GetNotFound()
    {
        var user = await context.Users.FindAsync(-1);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpGet("server-error")]
    public async Task<ActionResult<AppUser>> GetServerError()
    {
        var user = await context.Users.FindAsync(-1);

        if (user is null)
        {
            throw new Exception("A bad thing has happened.");
        }

        return user;
    }

    [HttpGet("bad-request")]
    public async Task<ActionResult<AppUser>> GetBadRequest()
    {
        return BadRequest("This was not a good request.");
    }
}
