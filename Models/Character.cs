using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя персонажа обязательно.")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Описание не должно превышать 255 символов.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Введите корректный URL для изображения.")]
        public string ImageUrl { get; set; }

        // Возраст (может быть null)
        public int? Age { get; set; }
        
        // Навигационное свойство для связи
        public ICollection<CharacterPerson> CharacterPersons { get; set; }
    }
}