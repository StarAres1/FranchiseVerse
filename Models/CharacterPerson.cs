namespace FranchiseVerse.Models;
using System.ComponentModel.DataAnnotations;

public class CharacterPerson
{
    public int Id { get; set; } // Единственный первичный ключ

    public int GameId { get; set; }
    public Game Game { get; set; }

    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

    [Required]
    [StringLength(50)]
    public string RoleType { get; set; } // Например: "Actor", "VoiceActor"
}