using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Coefficient
{
    [Key]
    public int idCoeff { get; set; }
    public int coeff { get; set; }
    public int idSerie { get; set; }
    public int idMatiere { get; set; }


    [ForeignKey("idSerie")]
    public Serie? Serie { get; set; }

    [ForeignKey("idMatiere")]
    public Matiere? Matiere { get; set; }
    
    
}