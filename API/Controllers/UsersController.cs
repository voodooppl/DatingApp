using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync(){
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<AppUser> GetUser(string id)
    {
        return await _context.Users.FindAsync(id);
    }
}

