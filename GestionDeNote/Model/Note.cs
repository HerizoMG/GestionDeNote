using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Note
{
    [Key]
    public int idNote { get; set; }
    public string matricule { get; set; }
    public int idMatiere { get; set; }
    
    public int coefficient { get; set; }
    public double note { get; set; }
    
    public int idAnneeScolaire { get; set; }

    [ForeignKey("matricule")]
    public Etudiant? Etudiant { get; set; }
    
    [ForeignKey("idMatiere")]
    public Matiere? Matiere { get; set; }
    
    [ForeignKey("idAnneeScolaire")]
    public Periode? AnneeScolaire { get; set; }

}