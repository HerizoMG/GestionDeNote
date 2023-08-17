using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Note
{
    [Key]
    public string id_note { get; set; }
    public string num_matricule { get; set; }
    public string num_matiere { get; set; }
    public string num_trimestre { get; set; }
    public string note { get; set; }

    [ForeignKey("num_matricule")]
    
    public Etudiant etudiant { get; set; }
    
    [ForeignKey("num_matiere")]
    
    public Matiere matiere { get; set; }
    
    [ForeignKey("num_trimestre")]
    
    public Trimestre trimestres { get; set; }

}