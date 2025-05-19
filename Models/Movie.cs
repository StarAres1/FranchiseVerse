using System.ComponentModel.DataAnnotations;

namespace FranchiseVerse.Models
{
    public class Movie
    {
        // Первичный ключ
        [Key]
        public int Id { get; set; }

        // Название фильма
        [Required(ErrorMessage = "Название фильма обязательно.")]
        [StringLength(255, ErrorMessage = "Название не должно превышать 255 символов.")]
        public string Title { get; set; }

        // Описание фильма
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Дата выпуска
        [DataType(DataType.Date)]
        [Display(Name = "Дата выпуска")]
        public DateTime? ReleaseDate { get; set; }

        // Продолжительность фильма (в минутах)
        [Range(1, 500, ErrorMessage = "Продолжительность должна быть от 1 до 500 минут.")]
        [Display(Name = "Продолжительность (мин)")]
        public int? Duration { get; set; }

        // Режиссер
        [StringLength(100, ErrorMessage = "Имя режиссера не должно превышать 100 символов.")]
        public string Director { get; set; }

        // Жанр фильма
        [StringLength(100, ErrorMessage = "Жанр не должен превышать 100 символов.")]
        public string Genre { get; set; }

        // Рейтинг фильма (например, IMDb или другой рейтинг)
        [Range(0, 10, ErrorMessage = "Рейтинг должен быть от 0 до 10.")]
        public double? Rating { get; set; }

        //количество оценок
        [Range(0, int.MaxValue, ErrorMessage = "Количство оценок должно быть положительным числом.")]
        public int RateCount { get; set;}

        // Постер фильма (URL изображения)
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

        // Бюджет фильма (в долларах)
        [Range(0, double.MaxValue, ErrorMessage = "Бюджет должен быть положительным числом.")]
        public decimal? Budget { get; set; }

        // Кассовые сборы (в долларах)
        [Range(0, double.MaxValue, ErrorMessage = "Кассовые сборы должны быть положительным числом.")]
        public decimal? BoxOffice { get; set; }
    }
}
