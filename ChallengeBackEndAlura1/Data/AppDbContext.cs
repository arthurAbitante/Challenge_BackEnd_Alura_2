using ChallengeBackEndAlura1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBackEndAlura1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Depoimento> Depoimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depoimento>().Property(p => p.depoimento);
            modelBuilder.Entity<Depoimento>().Property(p => p.nome).HasMaxLength(255);
            modelBuilder.Entity<Depoimento>().Property(p => p.foto).HasMaxLength(255);


        }

    }
}
