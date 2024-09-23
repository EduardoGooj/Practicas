using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Authorize]
// [ApiController]
// [Route("api/v1/[controller]")]
public class UserController: BaseApiController
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }


    [AllowAnonymous]
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
    [Authorize]
    [HttpGet("{id:int}")]// api/v1/users
    public async Task<ActionResult<AppUser>> GetUsersByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if(user==null)return NotFound();
        return user;
    }

    [HttpGet("{name}")]
    public ActionResult<string> ready(string name)
    {
        return $"Hi {name}";
    }
}