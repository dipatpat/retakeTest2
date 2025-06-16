using System.ComponentModel.DataAnnotations.Schema;

namespace RetakeTest2.Models;

public class CharacterTitle
{
    public int CharacterId { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
    
    public int TitleId { get; set; }

    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; }
    
    public DateTime AquiredAt { get; set; }
    
    
}