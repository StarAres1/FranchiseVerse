using Microsoft.EntityFrameworkCore;
using FranchiseVerse.Models;


namespace FranchiseVerse.Data
{
    public class AppDbContext : DbContext
    {
        // Конструктор для конфигурации
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        // Связываем модели с соответсвующими таблицами в БД
        public DbSet<Franchise> franchise { get; set; }
        public DbSet<Book> book { get; set; }
        public DbSet<Game> game { get; set; }
        public DbSet<Movie> movie { get; set; }
        public DbSet<TVseries> tvseries { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Character> character { get; set; }
    }
}
