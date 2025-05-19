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
        public DbSet<Person> person { get; set; }
        
        public DbSet<CharacterPerson> characterPerson { get; set; }
        public DbSet<GamePerson> gamePerson { get; set; }
        public DbSet<RandomGames> RandomGames { get; set; }
        public DbSet<RandomMovies> RandomMovies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterPerson>()
                .HasOne(cp => cp.Game)
                .WithMany(g => g.CharacterPersons)
                .HasForeignKey(cp => cp.GameId);

            modelBuilder.Entity<CharacterPerson>()
                .HasOne(cp => cp.Character)
                .WithMany(c => c.CharacterPersons)
                .HasForeignKey(cp => cp.CharacterId);

            modelBuilder.Entity<CharacterPerson>()
                .HasOne(cp => cp.Person)
                .WithMany(p => p.CharacterPersons)
                .HasForeignKey(cp => cp.PersonId);

            // GamePerson
            modelBuilder.Entity<GamePerson>()
                .HasOne(gp => gp.Game)
                .WithMany(g => g.GamePersons)
                .HasForeignKey(gp => gp.GameId);

            modelBuilder.Entity<GamePerson>()
                .HasOne(gp => gp.Person)
                .WithMany(p => p.GamePersons)
                .HasForeignKey(gp => gp.PersonId);
            
            // View1
            modelBuilder.Entity<RandomGames>(entity =>
            {
                entity.ToView("random_games");
                entity.HasNoKey(); // Представления обычно не имеют первичного ключа
            });
            
            // View2
            modelBuilder.Entity<RandomMovies>(entity =>
            {
                entity.ToView("random_movies");
                entity.HasNoKey(); // Представления обычно не имеют первичного ключа
            });
            
            // Регистрация функции PostgreSQL
            modelBuilder.HasDbFunction(
                typeof(AppDbContext).GetMethod(nameof(GetGamesByGenre), new[] { typeof(string) })!,
                dbFunction => dbFunction.HasName("get_games_by_genre")
            );
            
        }
        
        // Метод для вызова функции PostgreSQL
        public IQueryable<Game> GetGamesByGenre(string genre)
        {
            return FromExpression(() => GetGamesByGenre(genre));
        }
        
        public async Task DeleteUserById(uint userId)
        {
            await Database.ExecuteSqlInterpolatedAsync(
                $"SELECT delete_user_by_id({userId})"
            );
        }
    }
    
}
