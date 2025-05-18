using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    public class Game
    {   
        // Первичный ключ
        [Key]
        public int Id { get; set; }

        // Название игры
        [Required(ErrorMessage = "Название игры обязательно.")]
        [StringLength(255, ErrorMessage = "Название не должно превышать 255 символов.")]
        public string Title { get; set; }

        // Описание игры
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Дата выпуска
        [DataType(DataType.Date)]
        [Display(Name = "Дата выпуска")]
        public DateTime? ReleaseDate { get; set; }

        // Среднне время прохождения в часах (необязательный параметр)
        [Display(Name = "Продолжительность часах")]
        public int? Duration { get; set; }

        // Режиссер
        [StringLength(100, ErrorMessage = "Имя режиссера не должно превышать 100 символов.")]
        public string Director { get; set; }

        // Жанр игры
        [StringLength(100, ErrorMessage = "Жанр не должен превышать 100 символов.")]
        public string Genre { get; set; }

        // Рейтинг игры
        [Range(0, 10, ErrorMessage = "Рейтинг должен быть от 0 до 10.")]
        public double? Rating { get; set; }

        // Постер игры (URL изображения)
        [Url(ErrorMessage = "Введите корректный URL для постера.")]
        [Display(Name = "Постер")]
        public string PosterUrl { get; set; }

        // Страна производства
        [StringLength(100, ErrorMessage = "Страна не должна превышать 100 символов.")]
        public string Country { get; set; }

        // Язык оригинала
        [StringLength(50, ErrorMessage = "Язык не должен превышать 50 символов.")]
        public string Language { get; set; }

        // Возрастное ограничение
        [StringLength(10, ErrorMessage = "Возрастное ограничение не должно превышать 10 символов.")]
        public string AgeRating { get; set; }

        // Бюджет игры (в долларах)
        [Range(0, double.MaxValue, ErrorMessage = "Бюджет должен быть положительным числом.")]
        public decimal? Budget { get; set; }

        // Кассовые сборы (в долларах)
        [Range(0, double.MaxValue, ErrorMessage = "Кассовые сборы должны быть положительным числом.")]
        public decimal? BoxOffice { get; set; }
        
        public ICollection<CharacterPerson> CharacterPersons { get; set; }
        public ICollection<GamePerson> GamePersons { get; set; }
    }
}
