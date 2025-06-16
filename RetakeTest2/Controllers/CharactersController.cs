using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerPurchasesByIdAsync(int id, CancellationToken cancellationToken)
    {
        var response = await _context.Characters
            .Where(c => c.CharacterId == id)
            .Select(c => new
            {
                firstName = c.FirstName,
                lastName = c.LastName,
                currentWeight = c.CurrentWeight,
                maxWeight = c.MaxWeight,
                backPackItems = c.Backpacks.Select(b => new
                {
                    itemName = b.Item.Name,
                    itemWeight = b.Item.Weight,
                    amount = b.Amount,
                })
            }).FirstOrDefaultAsync(cancellationToken);
        
        if (response == null)
        {
            return NotFound($"We couldn't find anything with the id {id}");
        }
        return Ok(response);
    }
}