using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetakeTest2.DAL;
using RetakeTest2.Models;

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
    
    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddNewItemsToCharacter(int id, List<int> items, CancellationToken token)
    {
        
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.CharacterId == id, token);
        if (character == null)
            return BadRequest($"There's no character with id {id}");
        
        var characterCapacity = character.MaxWeight;

        var totalWeight = 0;
        
        foreach (var item in items)
        {
            var existsItem = await _context.Items
                .FirstOrDefaultAsync(i => i.ItemId == item, token);

            if (existsItem == null)
            {
                return NotFound($"There is no match with id: {item}");

            }
            totalWeight += existsItem.Weight;
        }

        if (characterCapacity < totalWeight)
        {
            return Conflict($"The maximum weight of {characterCapacity} is reached");
        }
        
        foreach (var item in items)
        {
            var existItem = await _context.Items
                .FirstOrDefaultAsync(i => i.ItemId == item, token);
            
            var existingBackpack = await _context.Backpacks
                .FirstOrDefaultAsync(b => b.ItemId == item && b.CharacterId == character.CharacterId, token);            
            
            var amount = existingBackpack.Amount;

            var newBackpack = new Backpack
            {
                CharacterId = character.CharacterId,
                ItemId = item,
                Amount = amount + 1
            };
            
            _context.Backpacks.Add(newBackpack);
            await _context.SaveChangesAsync(token);
            
            var newWeight = character.CurrentWeight + existItem.Weight;
            character.CurrentWeight = newWeight;
            await _context.SaveChangesAsync(token);
            
        }
        
        return CreatedAtAction(nameof(AddNewItemsToCharacter), new { id = character.CharacterId }, 
            $"Items added to Character's with {id} backpack");
    }
}