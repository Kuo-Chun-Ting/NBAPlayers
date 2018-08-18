using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.EFCore.OfficialProvider
{
    public class TestContext : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=test;user=root;password=lillard1611005");
            //optionsBuilder.UseMySql("server=localhost;database=nba;uid=root;pwd=lillard1611005");
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
