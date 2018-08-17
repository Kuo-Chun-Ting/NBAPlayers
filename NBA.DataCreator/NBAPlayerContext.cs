using Microsoft.EntityFrameworkCore;
using NBA.Model;
using System;

namespace NBA.DataCreator
{
    public class NBAPlayerContext : DbContext
    {
        public DbSet<Player> Player { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=nba;user=root;password=lillard1611005");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.name).IsRequired();
            });
        }
    }
}
