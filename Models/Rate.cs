using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    public class Rate
    {
        [Key]
        public uint Id { get; set; }

        // Внешний ключ на User
        public uint UserId { get; set; }

        // Внешний ключ на Movie
        public uint MovieId { get; set; }

        // Оценка фильма
        [Range(0, 10, ErrorMessage = "Оценка должен быть от 0 до 10.")]
        public int? Rating { get; set; }

        // Навигационное свойство
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}