using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно.")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов.")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Профессия не должна превышать 100 символов.")]
        public string Profession { get; set; } // Актёр озвучки, режиссёр, продюсер и т.д.

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(100, ErrorMessage = "Страна рождения не должна превышать 100 символов.")]
        public string Nationality { get; set; }

        [Url(ErrorMessage = "Введите корректный URL для фотографии.")]
        public string PhotoUrl { get; set; }

        [StringLength(255, ErrorMessage = "Краткая биография не должна превышать 255 символов.")]
        public string Bio { get; set; }
        
        public ICollection<CharacterPerson> CharacterPersons { get; set; }
        public ICollection<GamePerson> GamePersons { get; set; }
    }
}