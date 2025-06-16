using Microsoft.AspNetCore.Mvc;
using RetakeTest2.DAL;

namespace RetakeTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private BackpackDbContext _context;

    public CharactersController(BackpackDbContext context)
    {
        _context = context;
    }
}