using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EP_Borda.Models;


namespace EP_Borda.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Restricción: un jugador no puede estar dos veces en el mismo equipo
        modelBuilder.Entity<Assignment>()
            .HasIndex(a => new { a.PlayerId, a.TeamId })
            .IsUnique();
    }

    
}
