using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Note
{
    [Key]
    public int idNote { get; set; }
    public double note { get; set; }
    public int coeff { get; set; }
    public String matricule { get; set; }
    public int idMatiere { get; set; }
    
    [ForeignKey("matricule")]
    public Etudiant? Etudiant { get; set; }
    
    [ForeignKey("idMatiere")]
    public Matiere? Matiere { get; set; }
    
}