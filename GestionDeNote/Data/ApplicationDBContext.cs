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
    public DbSet<Note>? Posseders { get; set; }
    public DbSet<Trimestre>? Trimestres { get; set; }
    public DbSet<Matiere>? Matieres { get; set; }
}


