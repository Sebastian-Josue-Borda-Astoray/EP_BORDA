using Microsoft.EntityFrameworkCore;
using EP_Borda.Models;

namespace EP_Borda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 👇 Estas son las líneas que te están faltando:
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restricción para evitar duplicado de jugador-equipo
            modelBuilder.Entity<Assignment>()
                .HasIndex(a => new { a.PlayerId, a.TeamId })
                .IsUnique();
        }
    }
}
