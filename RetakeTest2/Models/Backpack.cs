using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetakeTest2.Models;

public class Backpack
{
    public int CharacterId { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
    
    public int ItemId { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
    
    public int Amount { get; set; }
}