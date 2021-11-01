
using FGCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGCore.Repositorio
{
    public class TimeContext : DbContext
    {
        public TimeContext(DbContextOptions<TimeContext> options):base(options)
        {

        }
        public DbSet<Time> Times { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Time>()
                .HasIndex(u => u.Nome)
                .IsUnique();
        }
    }
}
