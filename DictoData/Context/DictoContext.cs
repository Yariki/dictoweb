using DictoData.Model;
using Microsoft.EntityFrameworkCore;

namespace DictoData.Context
{
    public class DictoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<SuperMemory> SuperMemories { get; set; }

        public DbSet<Translate> Translates { get; set; }

        public DbSet<Transcription> Transcriptions { get; set; }

        public DbSet<Deck> Decks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dictodb;Persist Security Info=True;User ID=sa;Password=123");
            optionsBuilder.UseSqlServer("server=localhost,1434; user id = sa; password=8jkGh47hnDw89Haq8LN2; database=dictodb;");
            
        }
    }
}