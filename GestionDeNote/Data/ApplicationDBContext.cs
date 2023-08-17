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
    public DbSet<Annee>? Annees { get; set; }
    public DbSet<Periode>? Periodes { get; set; }
    public DbSet<Coefficient>? Coefficient { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Etudiant>().HasKey(e => new { e.matricule });
        modelBuilder.Entity<Note>().HasKey(n => new { n.idNote });
        modelBuilder.Entity<Matiere>().HasKey(m => new { m.idMatiere });
        modelBuilder.Entity<Classe>().HasKey(c => new { c.idClasse });
        modelBuilder.Entity<Serie>().HasKey(s => new { s.idSerie });
        modelBuilder.Entity<Trimestre>().HasKey(t => new { t.idTrimestre });
        modelBuilder.Entity<Periode>().HasKey(t => new { t.idPeriode });
        modelBuilder.Entity<Annee>().HasKey(t => new { t.idAnnee });
        modelBuilder.Entity<Coefficient>().HasKey(t => new { t.idCoeff });
    }
}


