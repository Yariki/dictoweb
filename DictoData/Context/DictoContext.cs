using DictoData.Model;
using Microsoft.EntityFrameworkCore;

namespace DictoData.Context
{
    public class DictoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dictodb.db");
        }
    }
}