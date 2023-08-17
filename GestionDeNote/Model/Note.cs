using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Note
{
    [Key]
    public int idNote { get; set; }
    public string matricule { get; set; }
    public int num_matiere { get; set; }
    
    [ForeignKey("numTrimestre")]
    public int numTrimestre { get; set; }
    public double note { get; set; }

    [ForeignKey("num_matricule")]
    
    public Etudiant etudiant { get; set; }
    
    [ForeignKey("num_matiere")]
    
    public Matiere matiere { get; set; }
    
    [ForeignKey("num_trimestre")]
    
    public Trimestre trimestres { get; set; }

}