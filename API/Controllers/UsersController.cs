using Abstractions;
using Microsoft.AspNetCore.Mvc;
using Service.DataServices;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAppUsersService _appUsersService;

    public UsersController(
        IAppUsersService appUsersService)
    {
        _appUsersService = appUsersService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUserDto>>> GetUsers()
    {
        var users = await _appUsersService.GetAllAsync(HttpContext.RequestAborted);
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUserDto>> GetUser([FromRoute] int id)
    {
        var user = await _appUsersService.GetByIdAsync(id, HttpContext.RequestAborted);

        return user is not null
            ? Ok(user)
            : NotFound();
    }
}
