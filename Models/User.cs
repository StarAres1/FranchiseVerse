using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    [Index(nameof(UserName), IsUnique = true)] // Уникальный индекс для UserName
    [Index(nameof(Email), IsUnique = true)]   // Уникальный индекс для Email
    public class User
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surename {  get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
