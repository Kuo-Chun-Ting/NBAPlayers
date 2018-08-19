using Microsoft.EntityFrameworkCore;
using NBA.Repository.Model;
using System;

namespace NBA.Repository.OfficialMysql
{
    public class PlayerContext : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=nba_official;user=root;password=lillard1611005");
            //optionsBuilder.UseMySql("server=localhost;database=nba_pomelo;uid=root;pwd=lillard1611005");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerModel>(entity =>
            {
                entity.HasKey(p => p.id);
                entity.Property(p => p.name).IsRequired();
            });
        }
    }
}
