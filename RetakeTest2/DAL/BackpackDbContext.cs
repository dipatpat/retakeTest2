using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using RetakeTest2.Models;

namespace RetakeTest2.DAL;

public class BackpackDbContext : DbContext
{
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    protected BackpackDbContext()
    {
    }

    public BackpackDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Backpack>() 
            .HasKey(b => new { BackpackId = b.CharacterId, b.ItemId });
        
        modelBuilder.Entity<CharacterTitle>() 
            .HasKey(ct => new { CharacterTitleId = ct.CharacterId, ct.TitleId });
        
        
        
        modelBuilder.Entity<Item>().HasData(
            new Item { ItemId = 1, Name = "Groszek", Weight = 2 },
            new Item { ItemId = 2, Name = "Pomidor", Weight = 3 },
            new Item { ItemId = 3, Name = "Kapusta", Weight = 4 }
        );
        
        modelBuilder.Entity<Character>().HasData(
            new Character { CharacterId = 1, FirstName = "Adam", LastName = "Mickiewicz", CurrentWeight = 10, MaxWeight = 30},
            new Character { CharacterId = 2, FirstName = "Jan", LastName = "Brzechwa", CurrentWeight = 50, MaxWeight = 130},
            new Character { CharacterId = 3, FirstName = "Cyprian", LastName = "Norwid", CurrentWeight = 40, MaxWeight = 190}
        );
        
        modelBuilder.Entity<Backpack>().HasData(
            new Backpack { CharacterId = 1, ItemId = 1, Amount = 1},
            new Backpack { CharacterId = 2, ItemId = 2, Amount = 1},
            new Backpack { CharacterId = 3, ItemId = 3, Amount = 1}
        );
        
        modelBuilder.Entity<Title>().HasData(
            new Title { TitleId = 1, Name = "Zielony"},
            new Title { TitleId = 2, Name = "Niebieski"},
            new Title { TitleId = 3, Name = "Czerwony"}
        );
        
        modelBuilder.Entity<CharacterTitle>().HasData(
            new CharacterTitle {CharacterId = 1, TitleId = 1, AquiredAt = new DateTime(2024, 8, 10)},
            new CharacterTitle {CharacterId = 2, TitleId = 2, AquiredAt = new DateTime(2024, 8, 11)},
            new CharacterTitle {CharacterId = 3, TitleId = 3, AquiredAt = new DateTime(2024, 8, 12)}
            
        );
        
    }
}