using GestionDeNote.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDeNote.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Etudiant>? Etudiants { get; set; }
    public DbSet<Classe>? Classes { get; set; }
    public DbSet<Serie>? Series { get; set; }
    public DbSet<Note>? Notes { get; set; }
    public DbSet<Trimestre>? Trimestres { get; set; }
    public DbSet<Matiere>? Matieres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Etudiant>().HasKey(e => new { e.matricule });
        modelBuilder.Entity<Note>().HasKey(n => new { n.idNote });
        modelBuilder.Entity<Matiere>().HasKey(m => new { m.idMatiere });
        modelBuilder.Entity<Classe>().HasKey(c => new { c.idClasse });
        modelBuilder.Entity<Serie>().HasKey(s => new { s.numSerie });
        modelBuilder.Entity<Trimestre>().HasKey(t => new { t.numTrimestre });
    }
}


