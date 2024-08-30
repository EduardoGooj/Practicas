using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
[ApiController]
[Route("Api/[controller]")]
public class UserController: ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();
        return users;


    }
    [HttpGet("{id}")]
    public ActionResult<AppUser> GetUsersBy(int id)
    {
        var user = _context.Users.Find(id);
        
        if(user==null)return NotFound();
        return user;


    }
}